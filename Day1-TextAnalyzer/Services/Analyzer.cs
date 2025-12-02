using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextAnalyzer.Models;

namespace TextAnalyzer.Services;

public class Analyzer {
	public List<WordCount> AnalyzeFile(string filePath) {
		string text = File.ReadAllText(filePath);

		if (string.IsNullOrWhiteSpace(text)) {
			throw new InvalidDataException("The file is empty.");
		}

		List<string> words = SplitIntoWords(text);

		if (words.Count == 0) {
			throw new InvalidDataException("The file does not contain any valid words.");
		}

		List<WordCount> topWords = GetTopWords(words, 5);

		return topWords;
	}

	private static List<string> SplitIntoWords(string text) {
		string lower = text.ToLowerInvariant();

		char[] separators = {
			' ', '\n', '\r', '\t',
			'.', ',', '!', '?', ':', ';',
			'"', '\'', '(', ')', '[', ']', '{', '}'
		};

		return lower
			.Split(separators, StringSplitOptions.RemoveEmptyEntries)
			.ToList();
	}

	private static List<WordCount> GetTopWords(List<string> words, int amount) {
		return words
			.GroupBy(w => w)
			.Select(g => new WordCount(g.Key, g.Count()))
			.OrderByDescending(wc => wc.Count)
			.ThenBy(wc => wc.Word)
			.Take(amount)
			.ToList();
	}
}
