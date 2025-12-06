namespace ShapeCalculator.Models;

public class Rectangle : IShape {
	public double Width { get; }
	public double Height { get; }

	public Rectangle(double width, double height) {
		if (width <= 0 || height <= 0) {
			throw new ArgumentException("Width and Height must be greater than zero.");
		}
		Width = width;
		Height = height;
	}

	public double GetArea(){
		return Width * Height;
	}

	public double GetPerimeter() {
		return 2 * (Width + Height);
	}
}