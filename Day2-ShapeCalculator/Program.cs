using ShapeCalculator.Models;
using ShapeCalculator.Services;
using System;
namespace ShapeCalculator;

public class Program {
	public static int Main() {
		try {
			ShapeService shapeService = new ShapeService();
			List<IShape> shapes = new List<IShape> {
				new Circle(5),
				new Rectangle(4, 6),
				new Triangle(3, 4, 5)
			};

			foreach (var shape in shapes) {
				shapeService.PrintShapeInfo(shape);
				Console.WriteLine();
			}

			return 0;
		}
		catch (Exception ex) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"❌ Error: {ex.Message}");
			Console.ResetColor();

			return 1;
		}
	}
}