namespace ShapeCalculator.Models;

public class Circle : IShape {
	public double Radius { get; }

	public Circle(double radius) {
		if (radius <= 0) {
			throw new ArgumentException("Radius must be greater than zero.", nameof(radius));
		}
		Radius = radius;
	}

	public double GetArea(){
		return System.Math.PI * Radius * Radius;
	}

	public double GetPerimeter() {
		return 2 * System.Math.PI * Radius;
	}
}