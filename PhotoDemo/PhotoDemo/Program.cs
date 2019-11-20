using System;

using static System.Console;

namespace PhotoDemo {
    class Photo {
        protected double price = 9.99;
        public Photo(double width, double height) {
            this.width = width;
            this.height = height;

            if (width == 8 && height == 10) {
                price = 3.99;
            } else if (width == 10 && height == 12) {
                price = 5.99;
            }
        }
        public double width { get; set; }
        public double height { get; set; }
        public double Price {
            get {
                return price;
            } protected set {
                price = value;
            }
        }
        public override string ToString() => "Type: " + GetType() + " - Width: " + width + " - Height: " + height + " - Cost: " + price;
    }

    class MattedPhoto : Photo {
        public MattedPhoto(double width, double height, string color) : base(width, height) {
            this.color = color;
        }

        public string color { get; set; }
        public double Price {
            get {
                return base.Price += 10;
            }
        }
        public override string ToString() => "Type: " + GetType() + " - Width: " + width + " - Height: " + height + " - Color: " + color + " - Cost: " + price;
    }

    class FramedPhoto : Photo {
        public FramedPhoto (double width, double height, string material, string style) : base(width, height) {

        }
        public string material { get; set; }
        public string style { get; set; }
        public double Price {
            get {
                return base.Price += 25;
            }
        }
        public override string ToString() => "Type: " + GetType() + " - Width: " + width + " - Height: " + height + " - Material: " + material + " - Style: " + style + " - Cost: " + price;
    }
    class Program {
        static void Main(string[] args) {
            Photo photo = new Photo(8, 10);
            MattedPhoto mattedphoto = new MattedPhoto(8, 10, "black");
            FramedPhoto framedPhoto = new FramedPhoto(8, 10, "wood", "modern");
            WriteLine(photo.ToString());
            WriteLine(mattedphoto.ToString());
            WriteLine(framedPhoto.ToString());
        }
    }
}
