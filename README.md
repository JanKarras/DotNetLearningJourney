# SevenDayDotNet  
*A structured 7-day C#/.NET learning journey with real-world projects and hands-on exercises.*

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Language](https://img.shields.io/badge/language-C%23-blue)
![Platform](https://img.shields.io/badge/platform-.NET%208-purple)
![Progress](https://img.shields.io/badge/progress-Day%201%20of%207-brightgreen)

---

## 📚 Overview

This repository documents my **7-day deep-dive into C# and .NET**, designed to build real-world engineering skills through practical and testable mini-projects.

Each day focuses on a specific topic, starting with fundamentals and ending with data processing, SQL usage, services, and optional UI development.

The goal of this learning journey is to strengthen my engineering skillset and prepare for roles requiring C#, .NET, SQL, data workflows, and application architecture.

---

# 🗓️ Progress Schedule

| Day | Topic | Status |
|-----|--------|---------|
| **Day 1** | C# Basics, File Handling, LINQ, Text Analyzer | ✅ Completed |
| **Day 2** | OOP, Classes, Interfaces, Architecture | ✅ Completed |
| **Day 3** | SQL + Simple ETL with C# | ✅ Completed |
| **Day 4** | Data Pipelines & Transformation Services | ⏳ Planned |
| **Day 5** | Dictionaries, Records, Advanced LINQ | ⏳ Planned |
| **Day 6** | Optional UI: WPF/WinUI Prototype | ⏳ Planned |
| **Day 7** | Final Mini-Project | ⏳ Planned |

---

# 🔥 Day 1 — TextAnalyzer

A C# console application that reads a `.txt` file and prints the **Top 5 most frequent words**.

### What I learned on Day 1:

- Basics of C# and .NET  
- Entry point structure (`Main`)  
- Namespaces and clean project organization  
- File I/O with `File.ReadAllText`  
- Argument validation and exception handling  
- Custom utility classes and services  
- LINQ operations (`GroupBy`, `Select`, `OrderByDescending`, `Take`)  
- Writing Bash scripts to automate tests  

---

# 🔥 Day 2 — ShapeCalculator

A C# console application focused on object-oriented programming, interfaces and polymorphism.

### What I learned on Day 2:

- Creating and implementing interfaces (`IShape`)  
- Building multiple shape classes (Circle, Rectangle, Triangle)  
- Encapsulation & constructor validation  
- Understanding polymorphism and shared behaviour  
- Using a service to calculate & print results cleanly  
- Improved folder and architecture structure (Models + Services)

---

# 🔥 Day 3 — TimeTracker ETL

A C# ETL-style application that imports time-tracking data from CSV files into a SQLite database and generates analytical reports.

### What I learned on Day 3:

- Parsing CSV files and validating column structure  
- Designing a SQLite schema & creating tables programmatically  
- Inserting data using parameterized SQL commands  
- Using transactions for consistent multi-row inserts  
- Aggregating work hours using SQL `GROUP BY` queries  
- End-to-end workflow: `CSV → Model → Database → Report`

---

# 🔥 Day 4 — Data Transformation Services

A C# service layer for transforming, filtering and enriching imported time-tracking data before reporting or saving.

### What I learned on Day 4:

- Building reusable transformation methods for `List<TimeEntry>`  
- Filtering by employee, project or date range  
- Calculating totals, averages & derived metrics in C#  
- Designing clean service layers for data processing  
- Preparing intermediate results for analytics & UI integration  
- Strengthening architecture for scalable ETL workflows  

---

# 🔥 Day 5 — Advanced LINQ, Records & Dictionary Aggregation

A C# deep dive into powerful data processing patterns using LINQ, immutable records and dictionary-based aggregation strategies.

### What I learned on Day 5:

- Refactoring models using C# `record` types for immutability  
- Efficient data grouping using `Dictionary<TKey, TValue>`  
- Advanced LINQ: `GroupBy`, `ToDictionary`, `SelectMany`, `OrderByDescending`  
- Splitting processing steps into pipelines for clarity & performance  
- Benchmarking differences between SQL-side vs C#-side aggregation  
- Strategies for scaling ETL workloads using in-memory transforms  

---

# 🔥 Day 6 — Optional UI Prototype (WPF/WinUI)

A graphical interface prototype to visualize imported time-tracking data, including live aggregation and report rendering.

### What I learned on Day 6:

- Building a desktop UI with WPF/WinUI using C#  
- Data binding concepts (`ObservableCollection`, MVVM-Grundlagen)  
- Displaying CSV/DB data in tables and live updating views  
- Integrating backend services into a UI layer  
- Visualizing analytics (hours per employee/project)  
- UI/UX considerations for desktop-based time-tracking tools  

---

# 🔥 Day 7 — Final Project (Full ETL + Reporting Dashboard)

A complete end-to-end ETL solution combining CSV import, transformation logic, SQLite storage and visual reporting.

### What I learned on Day 7:

- Designing a full data processing pipeline in C#  
- Automating import → transform → load workflows  
- Combining SQL + LINQ analytics for hybrid reporting  
- Building reusable services and clean architecture layers  
- Implementing a dashboard (CLI or UI) for final report output  
- Turning raw data into meaningful metrics and insights  

---



## 🚀 Technologies Used

- C#  
- .NET 8  
- LINQ  
- Bash scripting  
- Linux (Ubuntu VM)  

---

## 🧠 Purpose of the Project

A structured self-learning challenge to build skills in:

- C# and .NET  
- SQL and data handling  
- ETL processes  
- Clean code & software architecture  
- Automated testing  
- Real-world engineering workflows  

Each day introduces new concepts and includes a focused hands-on task.

---

## 📬 Contact & Feedback

Feel free to open issues or pull requests to contribute or improve this repository.

---

## 📄 License

This project is licensed under the **MIT License**.
