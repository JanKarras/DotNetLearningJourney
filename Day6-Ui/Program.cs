using Avalonia;
using System;

using Day6_Ui.Services;
using Day6_Ui.Models;
using Day6_Ui.Utils;

namespace Day6_Ui;

internal class Program {
	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.LogToTrace();

	[STAThread]
	public static void Main(string[] args) {
		BuildAvaloniaApp()
			.StartWithClassicDesktopLifetime(args);
	}
}
