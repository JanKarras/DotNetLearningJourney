using System;
using TextAnalyzer.Utils;
using TextAnalyzer.Services;

namespace TextAnalyzer;

public class Program {
	public static void Main(string[] args) {
		try {
			var filePath = ArgsValidator.Validate(args);

			var analyzer = new Analyzer();

			var result = analyzer.AnalyzeFile(filePath);

			Console.WriteLine("\nTop 5 most frequent words:");
			foreach (var entry in result) {
				Console.WriteLine($"- {entry.Word}: {entry.Count}x");
			}
		}
		catch (Exception ex) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"❌ Error: {ex.Message}");
			Console.ResetColor();

			Environment.ExitCode = 1;
		}
	}
}
