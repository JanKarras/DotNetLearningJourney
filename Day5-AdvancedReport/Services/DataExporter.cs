using System.Globalization;
using System.IO;
using Day4_DataPipeline.Models;

namespace Day4_DataPipeline.Services;

public class DataExporter{
	public void ExportCleandDataResult(List<TimeEntry> CleanedEntries){ 
		if (CleanedEntries == null) {
			throw new ArgumentNullException(nameof(CleanedEntries));
		}

		const string exportPath = "Data/OutputCsv/CleanedData.csv";

		if (string.IsNullOrWhiteSpace(exportPath)) {
			throw new ArgumentException("Output path cannot be empty.", nameof(exportPath));
		}

		string? directory = Path.GetDirectoryName(exportPath);
		if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) {
			Directory.CreateDirectory(directory);
		}

		using var writer = new StreamWriter(exportPath);

		writer.WriteLine("id,employee,date,hours,project");

		foreach (var entry in CleanedEntries) {
			string line = string.Join(",",
				entry.Id.ToString(),
				Escape(entry.EmployeeName),
				entry.Date.ToString("yyyy-MM-dd"),
				entry.HoursWorked.ToString(CultureInfo.InvariantCulture),
				Escape(entry.ProjectName)
			);

			writer.WriteLine(line);
		}
	}

	private static string Escape(string? value)
	{
		if (string.IsNullOrEmpty(value)) {
			return "";
		}

		if (!value.Contains(',') && !value.Contains('"')) {
			return value;
		}

		string escaped = value.Replace("\"", "\"\"");
		return $"\"{escaped}\"";
	}
}