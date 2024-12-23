using System;

namespace BasicCalculator
{
    class Calculator
    {
       
        public double X { get; set; }
        public double Y { get; set; }

        
        public Calculator(double x, double y)
        {
            X = x;
            Y = y;
        }

      
        public double Add()
        {
            return X + Y;
        }

        
        public double Subtract()
        {
            return X - Y;
        }

        
        public double Multiply()
        {
            return X * Y;
        }

        
        public string Divide()
        {
            if (Y == 0)
            {
                return "Cannot divide by zero";
            }
            return (X / Y).ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Enter the first number (x):");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number (y):");
            double y = Convert.ToDouble(Console.ReadLine());

            
            Calculator calculator = new Calculator(x, y);

         
            Console.WriteLine($"Sum (x + y): {calculator.Add()}");
            Console.WriteLine($"Difference (x - y): {calculator.Subtract()}");
            Console.WriteLine($"Product (x * y): {calculator.Multiply()}");
            Console.WriteLine($"Quotient (x / y): {calculator.Divide()}");
        }
    }
}
