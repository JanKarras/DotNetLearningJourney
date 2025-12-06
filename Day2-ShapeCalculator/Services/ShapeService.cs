using ShapeCalculator.Models;
namespace ShapeCalculator.Services;

public class ShapeService {
	public void PrintShapeInfo(IShape shape) {
		Console.WriteLine($"Shape: {shape.GetType().Name}");
		Console.WriteLine($"Area: {shape.GetArea()}");
		Console.WriteLine($"Perimeter: {shape.GetPerimeter()}");
	}
}