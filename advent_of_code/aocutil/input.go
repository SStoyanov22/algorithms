package aocutil

import (
	"fmt"
	"io"
	"net/http"
	"net/url"
	"os"
	"path/filepath"
	"regexp"
	"strings"
)

// FetchInput downloads the input for a specific day and year from Advent of Code.
// It requires a session cookie to authenticate with the AoC website.
// The session cookie can be obtained by logging in to adventofcode.com and
// inspecting the browser cookies.
func FetchInput(year, day int, sessionCookie string) (string, error) {
	url := fmt.Sprintf("https://adventofcode.com/%d/day/%d/input", year, day)

	req, err := http.NewRequest("GET", url, nil)
	if err != nil {
		return "", fmt.Errorf("failed to create request: %w", err)
	}

	req.Header.Set("Cookie", fmt.Sprintf("session=%s", sessionCookie))
	req.Header.Set("User-Agent", "github.com/SStoyanov22/algorithms/advent_of_code by s.stoyanov")

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		return "", fmt.Errorf("failed to fetch input: %w", err)
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		return "", fmt.Errorf("unexpected status code: %d", resp.StatusCode)
	}

	body, err := io.ReadAll(resp.Body)
	if err != nil {
		return "", fmt.Errorf("failed to read response body: %w", err)
	}

	return string(body), nil
}

// GetInput retrieves the input for a specific day and year.
// It first checks if the input is already cached locally in a file.
// If not found, it fetches the input from the AoC website using the session cookie
// from the AOC_SESSION environment variable and caches it.
func GetInput(year, day int) (string, error) {
	inputFile := "input.txt"

	if content, err := os.ReadFile(inputFile); err == nil {
		return string(content), nil
	}

	sessionCookie := os.Getenv("AOC_SESSION")
	if sessionCookie == "" {
		return "", fmt.Errorf("AOC_SESSION environment variable not set")
	}

	input, err := FetchInput(year, day, sessionCookie)
	if err != nil {
		return "", err
	}

	dir := filepath.Dir(inputFile)
	if err := os.MkdirAll(dir, 0755); err != nil {
		return "", fmt.Errorf("failed to create directory: %w", err)
	}

	if err := os.WriteFile(inputFile, []byte(input), 0644); err != nil {
		return "", fmt.Errorf("failed to write input file: %w", err)
	}

	return input, nil
}

// FetchProblem downloads the problem description for a specific day and year from Advent of Code.
// It converts the HTML to markdown format for easy reading.
func FetchProblem(year, day int, sessionCookie string) (string, error) {
	url := fmt.Sprintf("https://adventofcode.com/%d/day/%d", year, day)

	req, err := http.NewRequest("GET", url, nil)
	if err != nil {
		return "", fmt.Errorf("failed to create request: %w", err)
	}

	req.Header.Set("Cookie", fmt.Sprintf("session=%s", sessionCookie))
	req.Header.Set("User-Agent", "github.com/SStoyanov22/algorithms/advent_of_code by s.stoyanov")

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		return "", fmt.Errorf("failed to fetch problem: %w", err)
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		return "", fmt.Errorf("unexpected status code: %d", resp.StatusCode)
	}

	body, err := io.ReadAll(resp.Body)
	if err != nil {
		return "", fmt.Errorf("failed to read response body: %w", err)
	}

	return convertHTMLToMarkdown(string(body), year, day), nil
}

// convertHTMLToMarkdown converts the AoC HTML problem page to markdown
func convertHTMLToMarkdown(html string, year, day int) string {
	var md strings.Builder

	md.WriteString(fmt.Sprintf("# Advent of Code %d - Day %d\n\n", year, day))
	md.WriteString(fmt.Sprintf("[Problem Link](https://adventofcode.com/%d/day/%d)\n\n", year, day))
	md.WriteString("---\n\n")

	// Extract article content (problem description)
	articleRegex := regexp.MustCompile(`<article class="day-desc">(.*?)</article>`)
	articles := articleRegex.FindAllStringSubmatch(html, -1)

	for i, article := range articles {
		if len(article) > 1 {
			if i > 0 {
				md.WriteString("\n---\n\n")
			}
			md.WriteString(convertArticleToMarkdown(article[1]))
		}
	}

	return md.String()
}

// convertArticleToMarkdown converts a single article section to markdown
func convertArticleToMarkdown(html string) string {
	text := html

	// Extract and convert headers
	h2Regex := regexp.MustCompile(`<h2[^>]*>(.*?)</h2>`)
	text = h2Regex.ReplaceAllString(text, "## $1\n\n")

	// Convert code blocks
	codeRegex := regexp.MustCompile(`<pre><code>(.*?)</code></pre>`)
	text = codeRegex.ReplaceAllStringFunc(text, func(match string) string {
		code := codeRegex.FindStringSubmatch(match)[1]
		code = strings.ReplaceAll(code, "<em>", "**")
		code = strings.ReplaceAll(code, "</em>", "**")
		return "```\n" + code + "\n```\n\n"
	})

	// Convert inline code
	inlineCodeRegex := regexp.MustCompile(`<code>(.*?)</code>`)
	text = inlineCodeRegex.ReplaceAllString(text, "`$1`")

	// Convert em/emphasis
	emRegex := regexp.MustCompile(`<em[^>]*>(.*?)</em>`)
	text = emRegex.ReplaceAllString(text, "**$1**")

	// Convert links
	linkRegex := regexp.MustCompile(`<a href="([^"]+)"[^>]*>(.*?)</a>`)
	text = linkRegex.ReplaceAllString(text, "[$2]($1)")

	// Convert lists
	text = strings.ReplaceAll(text, "<ul>", "\n")
	text = strings.ReplaceAll(text, "</ul>", "\n")
	text = strings.ReplaceAll(text, "<li>", "- ")
	text = strings.ReplaceAll(text, "</li>", "\n")

	// Convert paragraphs
	text = strings.ReplaceAll(text, "<p>", "")
	text = strings.ReplaceAll(text, "</p>", "\n\n")

	// Remove remaining HTML tags
	tagRegex := regexp.MustCompile(`<[^>]+>`)
	text = tagRegex.ReplaceAllString(text, "")

	// Clean up HTML entities
	text = strings.ReplaceAll(text, "&gt;", ">")
	text = strings.ReplaceAll(text, "&lt;", "<")
	text = strings.ReplaceAll(text, "&amp;", "&")
	text = strings.ReplaceAll(text, "&quot;", "\"")

	// Clean up excessive newlines
	multiNewlineRegex := regexp.MustCompile(`\n{3,}`)
	text = multiNewlineRegex.ReplaceAllString(text, "\n\n")

	return strings.TrimSpace(text) + "\n"
}

// GetProblem retrieves the problem description for a specific day and year.
// It first checks if the problem is already cached locally in a file.
// If not found, it fetches the problem from the AoC website and caches it.
func GetProblem(year, day int) (string, error) {
	problemFile := "README.md"

	if content, err := os.ReadFile(problemFile); err == nil {
		return string(content), nil
	}

	sessionCookie := os.Getenv("AOC_SESSION")
	if sessionCookie == "" {
		return "", fmt.Errorf("AOC_SESSION environment variable not set")
	}

	problem, err := FetchProblem(year, day, sessionCookie)
	if err != nil {
		return "", err
	}

	dir := filepath.Dir(problemFile)
	if err := os.MkdirAll(dir, 0755); err != nil {
		return "", fmt.Errorf("failed to create directory: %w", err)
	}

	if err := os.WriteFile(problemFile, []byte(problem), 0644); err != nil {
		return "", fmt.Errorf("failed to write problem file: %w", err)
	}

	return problem, nil
}

// SubmitResponse represents the result of submitting an answer
type SubmitResponse struct {
	Correct bool
	Message string
	Wait    string // If rate-limited, how long to wait
}

// SubmitAnswer submits an answer for a specific day, year, and part (1 or 2).
// It returns a SubmitResponse indicating whether the answer was correct and any message from AoC.
func SubmitAnswer(year, day, part int, answer string) (*SubmitResponse, error) {
	sessionCookie := os.Getenv("AOC_SESSION")
	if sessionCookie == "" {
		return nil, fmt.Errorf("AOC_SESSION environment variable not set")
	}

	submitURL := fmt.Sprintf("https://adventofcode.com/%d/day/%d/answer", year, day)

	formData := url.Values{}
	formData.Set("level", fmt.Sprintf("%d", part))
	formData.Set("answer", answer)

	req, err := http.NewRequest("POST", submitURL, strings.NewReader(formData.Encode()))
	if err != nil {
		return nil, fmt.Errorf("failed to create request: %w", err)
	}

	req.Header.Set("Cookie", fmt.Sprintf("session=%s", sessionCookie))
	req.Header.Set("Content-Type", "application/x-www-form-urlencoded")
	req.Header.Set("User-Agent", "github.com/SStoyanov22/algorithms/advent_of_code by s.stoyanov")

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("failed to submit answer: %w", err)
	}
	defer resp.Body.Close()

	body, err := io.ReadAll(resp.Body)
	if err != nil {
		return nil, fmt.Errorf("failed to read response: %w", err)
	}

	return parseSubmitResponse(string(body))
}

// parseSubmitResponse parses the HTML response from AoC to determine if the answer was correct
func parseSubmitResponse(html string) (*SubmitResponse, error) {
	response := &SubmitResponse{}

	// Extract the main article content
	articleRegex := regexp.MustCompile(`<article>(.*?)</article>`)
	matches := articleRegex.FindStringSubmatch(html)
	if len(matches) < 2 {
		return nil, fmt.Errorf("could not parse response")
	}

	content := matches[1]

	// Check for correct answer
	if strings.Contains(content, "That's the right answer") {
		response.Correct = true
		response.Message = "Correct! ⭐"
		return response, nil
	}

	// Check for incorrect answer
	if strings.Contains(content, "That's not the right answer") {
		response.Correct = false
		if strings.Contains(content, "too high") {
			response.Message = "Incorrect - answer is too high"
		} else if strings.Contains(content, "too low") {
			response.Message = "Incorrect - answer is too low"
		} else {
			response.Message = "Incorrect answer"
		}
		return response, nil
	}

	// Check for rate limiting
	if strings.Contains(content, "You gave an answer too recently") || strings.Contains(content, "please wait") {
		response.Correct = false
		waitRegex := regexp.MustCompile(`you have(?:.*?)(\d+m \d+s|\d+s)`)
		waitMatches := waitRegex.FindStringSubmatch(content)
		if len(waitMatches) > 1 {
			response.Wait = waitMatches[1]
			response.Message = fmt.Sprintf("Rate limited - please wait %s", response.Wait)
		} else {
			response.Message = "Rate limited - please wait before submitting again"
		}
		return response, nil
	}

	// Check if already completed
	if strings.Contains(content, "Did you already complete it") {
		response.Correct = false
		response.Message = "Already completed this part"
		return response, nil
	}

	// Default case
	response.Correct = false
	response.Message = "Unknown response from server"
	return response, nil
}
