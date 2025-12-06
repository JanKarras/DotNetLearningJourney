namespace ShapeCalculator.Models;

public class Triangle : IShape {
	public double A { get; }
	public double B { get; }
	public double C { get; }

	public Triangle(double a, double b, double c) {
		if (a <= 0 || b <= 0 || c <= 0) {
			throw new ArgumentException("Sides must be greater than zero.");
		}
		if (a + b <= c || a + c <= b || b + c <= a) {
			throw new ArgumentException("The sum of any two sides must be greater than the third side.");
		}
		A = a;
		B = b;
		C = c;
	}

	public double GetArea(){
		double s = (A + B + C) / 2;
		return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
	}

	public double GetPerimeter() {
		return A + B + C;
	}

}