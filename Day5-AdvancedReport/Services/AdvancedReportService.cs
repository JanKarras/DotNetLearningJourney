using System;
using System.Collections.Generic;
using System.Linq;
using Day4_DataPipeline.Models;

namespace Day4_DataPipeline.Services;

public class AdvancedReportService {
	private readonly List<TimeEntry> _entries;

	public AdvancedReportService(IEnumerable<TimeEntry> entries)
	{
		if (entries == null) {
			throw new ArgumentNullException(nameof(entries));
		}

		_entries = entries.ToList();
	}

	public Dictionary<string, decimal> GetTotalHoursPerEmployee()
	{
		return _entries
			.GroupBy(e => e.EmployeeName)
			.ToDictionary(
				g => g.Key,
				g => g.Sum(e => e.HoursWorked)
			);
	}

	public Dictionary<string, decimal> GetTotalHoursPerProject()
	{
		return _entries
			.GroupBy(e => e.ProjectName)
			.ToDictionary(
				g => g.Key,
				g => g.Sum(e => e.HoursWorked)
			);
	}

	public decimal GetAverageHoursPerDay()
	{
		var groupedByDay = _entries
			.GroupBy(e => e.Date.Date)
			.Select(g => g.Sum(e => e.HoursWorked))
			.ToList();

		if (groupedByDay.Count == 0) {
			return 0;
		}

		return groupedByDay.Average();
	}

	public Dictionary<string, Dictionary<string, decimal>> GetHoursPerEmployeePerProject()
	{
		return _entries
			.GroupBy(e => e.EmployeeName)
			.ToDictionary(
				empGroup => empGroup.Key,
				empGroup => empGroup
					.GroupBy(e => e.ProjectName)
					.ToDictionary(
						projGroup => projGroup.Key,
						projGroup => projGroup.Sum(e => e.HoursWorked)
					)
			);
	}

	public void PrintTotalHoursPerEmployee()
	{
		Console.WriteLine("Total Hours Worked Per Employee (C#):");

		var totals = GetTotalHoursPerEmployee()
			.OrderByDescending(kv => kv.Value)
			.ThenBy(kv => kv.Key);

		foreach (var (employee, totalHours) in totals) {
			Console.WriteLine($"{employee}: {totalHours} hours");
		}
	}

	public void PrintTotalHoursPerProject()
	{
		Console.WriteLine("Total Hours Worked Per Project (C#):");

		var totals = GetTotalHoursPerProject()
			.OrderByDescending(kv => kv.Value)
			.ThenBy(kv => kv.Key);

		foreach (var (project, totalHours) in totals) {
			Console.WriteLine($"{project}: {totalHours} hours");
		}
	}

	public void PrintTopEmployees(int n)
	{
		if (n <= 0) {
			throw new ArgumentException("n must be greater than 0.", nameof(n));
		}
	
		Console.WriteLine($"Top {n} Employees (C#):");
	
		var top = GetTotalHoursPerEmployee()
			.OrderByDescending(kv => kv.Value)
			.ThenBy(kv => kv.Key)
			.Take(n)
			.ToList();
	
		for (int i = 0; i < top.Count; i++) {
			Console.WriteLine($"{i + 1}. {top[i].Key}: {top[i].Value} hours");
		}
	}

	public void PrintAverageHoursPerDay()
	{
		var avg = GetAverageHoursPerDay();
		Console.WriteLine($"Average Hours Per Day (C#): {avg:F2} hours");
	}

	public void PrintHoursPerEmployeePerProject()
	{
		Console.WriteLine("Hours Per Employee Per Project (C#):");

		var matrix = GetHoursPerEmployeePerProject()
			.OrderBy(kv => kv.Key); // employees alphabetisch

		foreach (var (employee, projects) in matrix) {
			Console.WriteLine($"\n{employee}:");

			foreach (var proj in projects.OrderByDescending(p => p.Value).ThenBy(p => p.Key)) {
				Console.WriteLine($"  - {proj.Key}: {proj.Value} hours");
			}
		}
	}
}