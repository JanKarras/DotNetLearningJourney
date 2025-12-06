using TimeTrackerETL.Models;
using Microsoft.Data.Sqlite;

namespace TimeTrackerETL.Services;

public class TimeEntryImporter {
	private readonly string _connectionString;

	public TimeEntryImporter(string connectionString) {
		_connectionString = connectionString;
	}

	public void Import(IEnumerable<TimeEntry> entries) {
		using var connection = new SqliteConnection(_connectionString);
		connection.Open();

		using var transaction = connection.BeginTransaction();

		foreach (var entry in entries) {
			using var cmd = connection.CreateCommand();
			cmd.CommandText = @"
				INSERT INTO time_entries (id, employee_name, entry_date, hours_worked, project_name)
				VALUES ($id, $employee_name, $entry_date, $hours_worked, $project_name)
				ON CONFLICT(id) DO UPDATE SET
					employee_name = excluded.employee_name,
					entry_date = excluded.entry_date,
					hours_worked = excluded.hours_worked,
					project_name = excluded.project_name;
			";

			cmd.Parameters.AddWithValue("$id", entry.Id);
			cmd.Parameters.AddWithValue("$employee_name", entry.EmployeeName);
			cmd.Parameters.AddWithValue("$entry_date", entry.Date.ToString("yyyy-MM-dd"));
			cmd.Parameters.AddWithValue("$hours_worked", entry.HoursWorked);
			cmd.Parameters.AddWithValue("$project_name", entry.ProjectName);

			cmd.ExecuteNonQuery();
		}

		transaction.Commit();
	}
}