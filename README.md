# SevenDayDotNet  
*A structured 7-day C#/.NET learning journey with real-world projects and hands-on exercises.*

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Language](https://img.shields.io/badge/language-C%23-blue)
![Platform](https://img.shields.io/badge/platform-.NET%208-purple)
![Progress](https://img.shields.io/badge/progress-Day%201%20of%207-brightgreen)

---

## 📚 Overview

This repository documents my **7-day deep-dive into C# and .NET**, designed to build real-world engineering skills through practical, testable mini-projects.

Each day focuses on a specific topic, starting with fundamentals and ending with data processing, SQL usage, services, and optional UI development.

This challenge was created to strengthen my engineering skillset and prepare for roles that require C#, .NET, SQL, data workflows, and architectural understanding.

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

A complete C# console application that reads a `.txt` file and prints the **Top 5 most frequent words**.

This project covers:

- C#/.NET fundamentals  
- Reading files with File I/O  
- Argument validation  
- Exception handling  
- LINQ transformations  
- Creating models, services, and utility classes  
- Building clean folder structures  
- Writing automated Bash tests  

---

## 📂 Project Structure

Day1-TextAnalyzer/
├── Program.cs
├── Models/
│ └── WordCount.cs
├── Utils/
│ └── ArgsValidator.cs
├── Services/
│ └── Analyzer.cs
└── TestFiles/
├── good/
├── bad/
├── test.sh
└── test_bad.sh

yaml
Copy code

---

## ⚙️ Features

✔ Full argument validation  
✔ Permission checks  
✔ Directory checks  
✔ .txt-only validation  
✔ Empty file detection  
✔ Separator-based word splitting  
✔ LINQ aggregation and sorting  
✔ Outputs the 5 most frequent words  
✔ Automated testing scripts (good + bad input)  

---

## 🧪 Running Tests

### Good input tests:

```bash
cd Day1-TextAnalyzer/TestFiles
./test.sh
Bad input tests (expected failures):
bash
Copy code
./test_bad.sh
Supported failure cases:

Missing argument

File does not exist

Wrong file extension

No read permission

Directory instead of file

Empty file

Only separators or invalid content

📊 Example Output
yaml
Copy code
📊 Top 5 most frequent words:
- the: 6x
- dog: 3x
- fox: 3x
- lazy: 3x
- quick: 3x
🚀 Technologies Used
C#

.NET 8

LINQ

Bash testing

Linux (Ubuntu VM)

🧠 Purpose of the Project
This repository represents a structured self-learning challenge to deepen my knowledge in:

C# / .NET

SQL + data handling

ETL processes

Application architecture

Unit testing & clean code

Real-world engineering workflows

Each day will introduce a new concept and a small hands-on project.

📬 Contact & Feedback
Feel free to open issues or pull requests if you'd like to contribute or improve any part of this journey.

📄 License
This project is licensed under the MIT License.

yaml
Copy code

---

# 🎉 Your README is now complete!

You can now:

1. **Copy everything into README.md**  
2. Commit & push it to GitHub  
3. Start adding Day 2 when you're ready  

---

If you want, I can also:

✔ Add a **LICENSE file**  
✔ Generate GitHub **issue templates**  
✔ Create a **Day2 folder structure**  
✔ Add a **CONTRIBUTING.md**  
✔ Add a **banner image**  
✔ Add **shields.io badges** for build, tests, or .NET version  

Just tell me:  
**“Create the full project setup”** or  
**“Continue with Day 2 now”**