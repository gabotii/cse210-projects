class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4.0),
            new Rectangle("Blue", 3.0, 6.0),
            new Circle("Green", 5.0)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
        }
    }
}
