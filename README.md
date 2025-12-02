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
| **Day 2** | OOP, Classes, Interfaces, Architecture | ⏳ Planned |
| **Day 3** | SQL + Simple ETL with C# | ⏳ Planned |
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

## ⚙️ Features

✔ Validates CLI arguments  
✔ Checks permissions and directory misuse  
✔ Only accepts `.txt` files  
✔ Detects empty or invalid files  
✔ Splits text into words using custom separators  
✔ Uses LINQ to calculate word frequencies  
✔ Returns the top 5 most frequent words  
✔ Includes Good/Bad automated test scripts  

---

## 🧪 Running Tests

### ✔ Good input tests

```bash
cd Day1-TextAnalyzer/TestFiles
./good.sh
### ✔ Bad input tests (expected errors)

```bash
./bad.sh
```

### The bad tests cover:

- Missing argument  
- File does not exist  
- Wrong file extension  
- No read permission  
- Directory path instead of a file  
- Empty file  
- Files that contain no valid words  

---

## 📊 Example Output

```
📊 Top 5 most frequent words:
- the: 6x
- dog: 3x
- fox: 3x
- lazy: 3x
- quick: 3x
```

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
