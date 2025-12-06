using System.IO;
using Microsoft.Data.Sqlite;


namespace TimeTrackerETL.Services;

public class DatabaseInitializer {
	private readonly string _dbPath;

	public DatabaseInitializer(string dbPath) {
		_dbPath = dbPath;
	}

	public void Initialize(){
		string? directory = Path.GetDirectoryName(_dbPath);
		if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) {
			Directory.CreateDirectory(directory);
		}

		var connectionString = $"Data Source={_dbPath}";
		using var connection = new SqliteConnection(connectionString);
		connection.Open();

		string createTableSql = @"
			CREATE TABLE IF NOT EXISTS time_entries (
				id INTEGER PRIMARY KEY,
				employee_name TEXT NOT NULL,
				entry_date TEXT NOT NULL,
				hours_worked REAL NOT NULL,
				project_name TEXT NOT NULL
			);
		";

		using var command = connection.CreateCommand();
		command.CommandText = createTableSql;
		command.ExecuteNonQuery();
	}
}