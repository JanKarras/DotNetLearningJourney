using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimeTrackerETL.Models;

namespace TimeTrackerETL.Services;

public class CsvReader {
	public List<TimeEntry> ReadTimeEntries(string filePath) {
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
			string[] columns = line.Split(',');
			if (columns.Length != 5) {
				throw new InvalidDataException($"Invalid number of columns in line {i + 1}. Expected 5 but got {columns.Length}.");
			}
			
			for (int c = 0; c < columns.Length; c++) {
				columns[c] = columns[c].Trim();
			}

			if (string.IsNullOrWhiteSpace(columns[0]) ||
				string.IsNullOrWhiteSpace(columns[1]) ||
				string.IsNullOrWhiteSpace(columns[2]) ||
				string.IsNullOrWhiteSpace(columns[3]) ||
				string.IsNullOrWhiteSpace(columns[4])) {
				throw new InvalidDataException($"Line {i + 1} contains empty fields.");
			}
			
			if (!int.TryParse(columns[0], out int id)) {
				throw new InvalidDataException($"Invalid id in line {i + 1}: '{columns[0]}'");
			}
			if (!DateTime.TryParse(columns[2], out DateTime date)) {
				throw new InvalidDataException($"Invalid date in line {i + 1}: '{columns[2]}'");
			}
			if (!decimal.TryParse(columns[3], out decimal hoursWorked)) {
				throw new InvalidDataException($"Invalid hours worked in line {i + 1}: '{columns[3]}'");
			}

			timeEntries.Add(new TimeEntry(
				id: int.Parse(columns[0]),
				employeeName: columns[1],
				date: DateTime.Parse(columns[2]),
				hoursWorked: decimal.Parse(columns[3]),
				projectName: columns[4]
			));
		}

		return timeEntries;
	}
}