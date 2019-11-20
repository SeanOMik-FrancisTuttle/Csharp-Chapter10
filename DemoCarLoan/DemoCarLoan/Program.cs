using System;

using static System.Console;

namespace DemoCarLoan {
    class Loan {
        public int LoanNumber { get; set; }
        public string LastName { get; set; }
        public double LoanAmount { get; set; }
    }

    class CarLoan : Loan {
        public int Year { get; set; }
        public string Make { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            Loan aLoan = new Loan();
            aLoan.LoanNumber = 2239;
            aLoan.LastName = "Mitchell";
            aLoan.LoanAmount = 1000.00;
            WriteLine("Loan #{0} for {1} is for {2}", aLoan.LoanNumber, aLoan.LastName, aLoan.LoanAmount.ToString("C2"));

            CarLoan carLoan = new CarLoan();
            carLoan.LoanNumber = 3358;
            carLoan.LastName = "Jansen";
            carLoan.LoanAmount = 20000.00;
            carLoan.Make = "Ford";
            carLoan.Year = 2005;
            WriteLine("Car Loan #{0} for {1} is for {2} for a car from: {3}, year: {4}", carLoan.LoanNumber, carLoan.LastName, carLoan.LoanAmount.ToString("C2"), carLoan.Make, carLoan.Year);
        }
    }
}
