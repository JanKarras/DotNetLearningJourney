using System;
using Day4_DataPipeline.Services;
using Day4_DataPipeline.Models;
using Day4_DataPipeline.Utils;

namespace Day4_DataPipeline;

public class Program {
	public static void Main(string[] args) {
		const string dbPath = "./Data/DataBase/time-tracking.db";
		const string connectionString = $"Data Source={dbPath}";
		try {
			var filePath = ArgsValidator.Validate(args);

			List<TimeEntry> timeEntries = new CsvReader().ReadTimeEntries(filePath);

			var transformer = new DataTransformer();
			List<TimeEntry> cleanedEntries = transformer.Transform(timeEntries);

			var exporter = new DataExporter();
			exporter.ExportCleandDataResult(cleanedEntries);

			var dbInitializer = new DatabaseInitializer(dbPath);
			dbInitializer.Initialize();

			var importer = new TimeEntryImporter(connectionString);
			importer.Import(cleanedEntries);

			var reporter = new TimeEntryReporter(connectionString);
			reporter.ReportTotalHoursPerEmployee();
		}
		catch (Exception ex) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"❌ Error: {ex.Message}");
			Console.ResetColor();

			Environment.ExitCode = 1;
		}
	}
}