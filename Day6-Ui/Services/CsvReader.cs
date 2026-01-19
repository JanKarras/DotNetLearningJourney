using System;
using System.Collections.Generic;
using System.IO;
using Day6_Ui.Models;

namespace Day6_Ui.Services;

public class CsvReader
{
	public List<TimeEntry> ReadTimeEntries(string filePath)
	{
		string text = File.ReadAllText(filePath);

		if (string.IsNullOrWhiteSpace(text)) {
			throw new InvalidDataException("The CSV file is empty.");
		}

		string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

		if (lines.Length <= 1) {
			throw new InvalidDataException("The CSV file does not contain any data rows.");
		}

		List<TimeEntry> timeEntries = new List<TimeEntry>();

		for (int i = 1; i < lines.Length; i++) {
			string line = lines[i].Trim();
			if (string.IsNullOrWhiteSpace(line)) {
				continue;
			}

			string[] columns = line.Split(',');
			if (columns.Length != 5) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"⚠️  Line {i + 1} skipped: Expected 5 columns, got {columns.Length}");
				Console.ResetColor();
				continue;
			}

			for (int c = 0; c < columns.Length; c++) {
				columns[c] = columns[c].Trim();
			}

			if (string.IsNullOrWhiteSpace(columns[0]) ||
				string.IsNullOrWhiteSpace(columns[1]) ||
				string.IsNullOrWhiteSpace(columns[2]) ||
				string.IsNullOrWhiteSpace(columns[3]) ||
				string.IsNullOrWhiteSpace(columns[4])) {

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"⚠️  Line {i + 1} skipped: contains empty fields.");
				Console.ResetColor();
				continue;
			}

			if (!int.TryParse(columns[0], out int id)) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"⚠️  Line {i + 1} skipped: invalid id '{columns[0]}'");
				Console.ResetColor();
				continue;
			}

			if (!DateTime.TryParse(columns[2], out DateTime date)) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"⚠️  Line {i + 1} skipped: invalid date '{columns[2]}'");
				Console.ResetColor();
				continue;
			}

			if (!decimal.TryParse(columns[3], out decimal hoursWorked)) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"⚠️  Line {i + 1} skipped: invalid hours '{columns[3]}'");
				Console.ResetColor();
				continue;
			}

			timeEntries.Add(new TimeEntry(
				id: id,
				employeeName: columns[1],
				date: date,
				hoursWorked: hoursWorked,
				projectName: columns[4]
			));
		}

		return timeEntries;
	}
}
