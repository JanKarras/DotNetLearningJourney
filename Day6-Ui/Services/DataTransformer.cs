using System;
using System.Collections.Generic;
using System.Linq;
using Day6_Ui.Models;

namespace Day6_Ui.Services;

public class DataTransformer {
	public List<TimeEntry> Transform(IEnumerable<TimeEntry> rawEntries) {
		if (rawEntries == null) {
			throw new ArgumentNullException(nameof(rawEntries));
		}

		var result = new List<TimeEntry>();

		foreach (var entry in rawEntries) {
			if (!IsValid(entry)) {
				PrintSkip(entry, "Invalid data (empty employee/project or non-positive hours).");
				continue;
			}

			var normalized = Normalize(entry);
			result.Add(normalized);
		}
		return result;
	}

	private static bool IsValid(TimeEntry entry) {
		if (string.IsNullOrWhiteSpace(entry.EmployeeName)) return false;
		if (string.IsNullOrWhiteSpace(entry.ProjectName)) return false;

		if (entry.HoursWorked <= 0) return false;

		if (entry.HoursWorked > 24) return false;

		if (entry.Date > DateTime.UtcNow.AddDays(1)) return false;

		return true;
	}

	private static TimeEntry Normalize(TimeEntry entry) {
		string employee = NormalizeName(entry.EmployeeName);
		string project = NormalizeProjectName(entry.ProjectName);

		var dateOnly = entry.Date.Date;

		return new TimeEntry(
			entry.Id,
			employee,
			dateOnly,
			entry.HoursWorked,
			project
		);
	}

	private static string NormalizeName(string name) {
		if (string.IsNullOrWhiteSpace(name)) {
			return name;
		}

		var trimmed = name.Trim();

		if (trimmed.Length >= 2 && trimmed[0] == '"' && trimmed[^1] == '"') {
			trimmed = trimmed.Substring(1, trimmed.Length - 2).Trim();
		}

		var parts = trimmed.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		return string.Join(' ', parts);
	}


	private static string NormalizeProjectName(string project) {
		if (string.IsNullOrWhiteSpace(project)) {
			return project;
		}

		var trimmed = project.Trim();

		if (trimmed.Length >= 2 && trimmed[0] == '"' && trimmed[^1] == '"') {
			trimmed = trimmed.Substring(1, trimmed.Length - 2).Trim();
		}
	
		var parts = trimmed.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		return string.Join(' ', parts);
	}

	private static void PrintSkip(TimeEntry entry, string reason) {
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine($"⚠️ Skipping entry {entry.Id}: {reason}");
		Console.ResetColor();
	}
}