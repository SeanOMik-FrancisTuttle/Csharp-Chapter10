using System;

using static System.Console;

namespace DemoCarLoan2 {
    class Loan {
        public const double MINIMUM_LOAN = 500;
        protected double loanAmount;
        public int LoanNumber { get; set; }
        public string LastName { get; set; }
        public double LoanAmount {
            set {
                if (value < MINIMUM_LOAN) {
                    loanAmount = MINIMUM_LOAN;
                } else {
                    loanAmount = value;
                }
            } 
            get {
                return loanAmount;
            }
        }
    }

    class CarLoan : Loan {
        private const int EARLIEST_YEAR = 2006;
        private const int LOWEST_INVALID_NUM = 1000;
        private int year;
        public int Year { set {
                if (value < EARLIEST_YEAR) {
                    year = value;
                    loanAmount = 0;
                } else {
                    year = value;
                }
            }
            get {
                return year;
            }
        }
        public new int LoanNumber {
            get {
                return base.LoanNumber;
            }
            set {
                if (value < LOWEST_INVALID_NUM) {
                    base.LoanNumber = value;
                } else {
                    base.LoanNumber = value % LOWEST_INVALID_NUM;
                }
            }
        }
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
