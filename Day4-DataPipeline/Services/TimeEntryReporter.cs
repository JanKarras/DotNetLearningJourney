using Microsoft.Data.Sqlite;

namespace Day4_DataPipeline.Services;

class TimeEntryReporter {
	private readonly string _connectionString;

	public TimeEntryReporter(string connectionString) {
		_connectionString = connectionString;
	}

	public void ReportTotalHoursPerEmployee() {
		using var connection = new SqliteConnection(_connectionString);
		connection.Open();

		using var command = connection.CreateCommand();
		command.CommandText = @"
			SELECT employee_name, SUM(hours_worked) AS total_hours
			FROM time_entries
			GROUP BY employee_name;
		";

		using var reader = command.ExecuteReader();
		Console.WriteLine("Total Hours Worked Per Employee:");
		while (reader.Read()) {
			string employeeName = reader.GetString(0);
			decimal totalHours = reader.GetDecimal(1);
			Console.WriteLine($"{employeeName}: {totalHours} hours");
		}
	}
}