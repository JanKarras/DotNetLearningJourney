namespace Day6_Ui.Models;

using System;

public class TimeEntry {
	public int Id { get; }
	public string EmployeeName { get;}

	public DateTime Date { get; }

	public decimal HoursWorked { get; }

	public string ProjectName { get; }

	public TimeEntry(int id, string employeeName, DateTime date, decimal hoursWorked, string projectName) {
		Id = id;
		EmployeeName = employeeName;
		Date = date;
		HoursWorked = hoursWorked;
		ProjectName = projectName;
	}
}