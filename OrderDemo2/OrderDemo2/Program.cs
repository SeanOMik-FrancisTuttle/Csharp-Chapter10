using System;
using System.Threading;

using static System.Console;

namespace OrderDemo2 {
    class Order : IEquatable<Order>{
        private int Amount;
        public Order (int orderNum, string customerName, int amount) {
            this.orderNum = orderNum;
            this.customerName = customerName;
            this.amount = amount;
        }
        public int orderNum { get; set; }
        public string customerName { get; set; }
        public int amount { 
            get {
                return Amount;
            }
            set {
                Amount = value;
                totalPrice = value * 19.95;
            }
        }
        public double totalPrice { get; protected set; }
        public override bool Equals(object order) {
            return Equals(order as Order);
        }
        public bool Equals(Order order) {
            if (order.orderNum == orderNum) {
                return true;
            }
            return false;
        }
        public override int GetHashCode() {
            return orderNum;
        }
        public override string ToString() {
            return String.Format("Order Num: {0} - Customer: {1} - Quantity: {2} - Price: {3}", orderNum, customerName, amount, totalPrice.ToString("C"));
        }
    }
    class Program {
        static bool areEqual(Order a, Order b) {
            return a.Equals(b);
        }
        static void Main(string[] args) {
            bool auto = true;
            string autoConferenceName = "John Doe - ";
            Random random = new Random();
            int msWait = 10;
            if (auto) WriteLine("RUNNING AUTO, DON'T TYPE ANYTHING!");
            int[] orderNumbers = new int[5];

            Order[] orders = new Order[5];
            int firstOrders = 632;
            for (int i = 0; i < 5; ++i) {
                int orderNumber;
                bool validOrderNumber = false;
                do {
                    Write("Enter Order #{0} Order number: ", i + 1);
                    if (auto) {
                        validOrderNumber = true;
                        Thread.Sleep(msWait);
                        //orderNumber = (i == 0 || i == 1) ? firstOrders : random.Next(100, 999);
                        orderNumber = random.Next(100, 999);
                        WriteLine("{0}", orderNumber);
                        if (Array.IndexOf(orderNumbers, orderNumber) > -1) {
                            WriteLine("There is already an order with that number, please enter something else.");
                            validOrderNumber = false;
                        } else orderNumbers[i] = orderNumber;
                    }
                    else {
                        validOrderNumber = int.TryParse(ReadLine(), out orderNumber);
                    }
                } while (!validOrderNumber);

                string customer;
                Write("Enter Order #{0} Customer Name: ", i + 1);
                if (auto) {
                    Thread.Sleep(msWait);
                    customer = autoConferenceName + (i + 1);
                    WriteLine("{0}", customer);
                }
                else {
                    customer = ReadLine();
                }

                int amount;
                bool validAmount = false;
                do {
                    Write("Enter Order #{0} Quantity of Product: ", i + 1);
                    if (auto) {
                        validAmount = true;
                        Thread.Sleep(msWait);
                        amount = random.Next(1, 15);
                        WriteLine("{0}", amount);
                    }
                    else {
                        validAmount = int.TryParse(ReadLine(), out amount);
                    }
                } while (!validAmount);

                Order order = new Order(orderNumber, customer, amount);
                orders[i] = order;
            }

            foreach (Order order in orders) WriteLine(order.ToString());
        }
    }
}
