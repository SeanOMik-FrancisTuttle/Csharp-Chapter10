using System;

namespace PackageDemo {
    class Package {
        protected double Weight;
        public Package(int id, string name, double weight) {
            this.id = id;
            this.name = name;
            this.weight = weight;
        }
        public int id { get; set; }
        public string name { get; set; }
        public virtual double weight {
            get {
                return Weight;
            }
            set {
                Weight = value;
                cost = (value > 32) ? value - 32 * 0.12 : 5;
            }
        }
        public double cost { get; set; }
        public override string ToString() {
            return String.Format("ID: {0} - For: {1} - Weight: {2} - Cost: {3}", id, name, weight, cost.ToString("C"));
        }
    }

    class InsuredPackage : Package {
        public InsuredPackage(int id, string name, double weight) : base (id, name, weight) {
            this.id = id;
            this.name = name;
            this.weight = weight;
        }
        public override double weight {
            get {
                return Weight;
            }
            set {
                Weight = value;
                cost = (value > 32) ? value - 32 * 0.12 : 5;
                cost = (cost < 20) ? cost + 1 : cost + 2.50;
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            Package package = new Package(0001, "Anti-Vax Karen", 14);
            Package package2 = new Package(0002, "Anti-Vax Karen Again", 84);
            InsuredPackage insuredPackage = new InsuredPackage(0003, "What's with these Karens?", 129);
            InsuredPackage insuredPackage2 = new InsuredPackage(0004, "Wow, its like there's an army!", 843);

            Console.WriteLine("Package 1: {0}", package.ToString());
            Console.WriteLine("Package 2: {0}", package2.ToString());
            Console.WriteLine("InsuredPackage 1: {0}", insuredPackage.ToString());
            Console.WriteLine("InsuredPackage 2: {0}", insuredPackage2.ToString());

        }
    }
}