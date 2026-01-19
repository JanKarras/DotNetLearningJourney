using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

using System;
using System.IO;
using System.Linq;

using Day6_Ui.Utils;
using Day6_Ui.Services;

namespace Day6_Ui;

public partial class MainWindow : Window {

	private readonly ImportPipeline _pipeline = new();

	public MainWindow() {
		InitializeComponent();
	}

	private void OnLoadClick(object? sender, RoutedEventArgs e) {
		var pathBox = this.GetControl<TextBox>("CsvPathBox");
		var status = this.GetControl<TextBlock>("StatusText");
		var grid = this.GetControl<DataGrid>("EntriesGrid");

		var path = (pathBox.Text ?? "").Trim();

		var ValidFilePath = ArgsValidator.Validate(path);

		try {
			status.Text = "Status: Loading and transforming data...";

			var entries = _pipeline.LoadAndTransform(ValidFilePath);

			grid.ItemsSource = entries;
			status.Text = $"Status: Showing {entries.Count} entries ✅";

		} catch (Exception ex) {
			status.Text = $"Status: Fehler beim Laden der Datei: {ex.Message}";
		}
	}

	private async void OnBrowseClick(object? sender, RoutedEventArgs e) {
		var pathBox = this.GetControl<TextBox>("CsvPathBox");
		var status = this.GetControl<TextBlock>("StatusText");

		try {
			var files = await this.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions {
				Title = "Select CSV file",
				AllowMultiple = false,
				FileTypeFilter = new[]{
					new FilePickerFileType("CSV") { Patterns = new[] { "*.csv" } },
					FilePickerFileTypes.All
				}
			});

			var file = files?.FirstOrDefault();
			if (file is null) {
				status.Text = "Status: No file selected.";
				return;
			}

			pathBox.Text = file.Path.LocalPath;
			status.Text = $"Status: Selected file: {file.Name}";
		} catch (Exception ex) {
			status.Text = $"Status: File picker error: {ex.Message}";
		}
	}

}

//Data/inputCsv/test.csv