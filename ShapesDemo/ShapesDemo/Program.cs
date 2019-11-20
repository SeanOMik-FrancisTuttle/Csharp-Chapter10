using System;

namespace ShapesDemo {
    abstract class GeometricFigure {
        protected double Width, Height;
        public GeometricFigure(double height, double width) {
            this.height = height;
            this.width = width;
        }
        public virtual double height { get; set; }
        public virtual double width { get; set; }
        public virtual double area { get; set; }
        public abstract void ComputeArea();
        public abstract override string ToString();
    }
    class Rectangle : GeometricFigure {
        public Rectangle(double height, double width) : base(height, width) {

        }
        public override double height {
            get {
                return Height;
            }
            set {
                Height = value;
                area = height * width;
            }
        }
        public override double width {
            get {
                return Width;
            }
            set {
                Width = value;
                area = height * width;
            }
        }
        public override void ComputeArea() {
            area = height * width;
        }

        public override string ToString() {
            return String.Format("Rectangle: Width: {0} - Height: {1} - Area: {2}", width, height, area);
        }
    }
    class Square : GeometricFigure {
        public Square(double side) : base(side, side) {

        }
        public override double height {
            get {
                return Height;
            }
            set {
                Height = value;
                Width = value;
            }
        }
        public override double width {
            get {
                return Width;
            }
            set {
                Height = value;
                Width = value;
            }
        }
        public override void ComputeArea() {
            area = height * width;
        }
        public override string ToString() {
            return String.Format("Square: Width: {0} - Height: {1} - Area: {2}", width, height, area);
        }
    }
    class Triangle : GeometricFigure {
        public Triangle(double height, double width) : base(height, width) {

        }
        public override void ComputeArea() {
            area = height * 0.5 * width;
        }
        public override string ToString() {
            return String.Format("Triangle: Width: {0} - Height: {1} - Area: {2}", width, height, area);
        }
    }
    class Program {
        static void displayFigure(GeometricFigure figure) {
            Console.WriteLine(figure.ToString());
        }
        static void Main(string[] args) {
            Rectangle rect = new Rectangle(15, 30);
            rect.ComputeArea();
            displayFigure(rect);
            rect.width = 58;
            rect.ComputeArea();
            displayFigure(rect);

            Square square = new Square(15);
            square.ComputeArea();
            displayFigure(square);
            square.width = 93;
            square.ComputeArea();
            displayFigure(square);

            Triangle tri = new Triangle(24, 51);
            tri.ComputeArea();
            displayFigure(tri);
            tri.width = 38;
            tri.height = 85;
            tri.ComputeArea();
            displayFigure(tri);
        }
    }
}