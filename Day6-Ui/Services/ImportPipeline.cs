using System.Collections.Generic;
using Day6_Ui.Models;

namespace Day6_Ui.Services;

public class ImportPipeline {
	public List<TimeEntry> LoadAndTransform(string csvPath) {
		var reader = new CsvReader();
		var raw = reader.ReadTimeEntries(csvPath);

		var transformer = new DataTransformer();
		return transformer.Transform(raw);
	}
}
