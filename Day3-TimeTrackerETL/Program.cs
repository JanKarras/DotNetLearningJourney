using System;
using TimeTrackerETL.Utils;
using TimeTrackerETL.Services;
using TimeTrackerETL.Models;

namespace TimeTrackerETL;

public class Program {
	public static void Main(string[] args) {
		const string dbPath = "Data Source=Data/DataBase/time-tracking.db";
		const string connectionString = $"Data Source={dbPath}";
		try {
			var filePath = ArgsValidator.Validate(args);

			List<TimeEntry> timeEntries = new CsvReader().ReadTimeEntries(filePath);

			var dbInitializer = new DatabaseInitializer(dbPath);
			dbInitializer.Initialize();

			var importer = new TimeEntryImporter(connectionString);
			importer.Import(timeEntries);

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
