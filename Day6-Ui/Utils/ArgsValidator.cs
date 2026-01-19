using System;
using System.IO;

namespace Day6_Ui.Utils;

public static class ArgsValidator
{
	public static string Validate(string args)
	{
		if (args.Length == 0) {
			throw new ArgumentException("You must provide a file path.");
		}

		string path = args;

		if (string.IsNullOrWhiteSpace(path)) {
			throw new ArgumentException("File path cannot be empty.");
		}

		if (!File.Exists(path)) {
			throw new FileNotFoundException($"File not found: {path}");
		}

		FileAttributes attr = File.GetAttributes(path);
		if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
			throw new IOException("The provided path is a directory, not a file.");
		}

		try {
			using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
		}
		catch (UnauthorizedAccessException) {
			throw new UnauthorizedAccessException("You do not have permission to read this file.");
		}

		if (!string.Equals(Path.GetExtension(path), ".csv", StringComparison.OrdinalIgnoreCase)) {
			throw new ArgumentException("Only .csv files are supported.");
		}

		var fileInfo = new FileInfo(path);
		if (fileInfo.Length > 100 * 1024 * 1024) {
			throw new ArgumentException("File is too large (>100 MB).");
		}

		return path;
	}
}
