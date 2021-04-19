using System;

namespace Calculator
{
    class Calculator
    {
        public enum Operaption
        {
            Plus,
            Minus,
            Mult,
            Divis
        }
        Func<double,double,double> func;
        public void SetOperation(Operaption operation)
        {
            switch (operation)
            {
                case Operaption.Plus:
                    func =  (varF ,varS) => (varF + varS);
                    break;
                case Operaption.Minus:
                    func = (varF, varS) => (varF - varS);

                    break;
                case Operaption.Mult:
                    func = (varF, varS) => (varF * varS);
                    break;
                case Operaption.Divis:
                    func = (varF, varS) => (varF / varS);
                    break;
                default:
                    break;
            }

        }
          public double Calculate(double first,double second)
          {
             return (double)func?.Invoke(first, second);
          }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.SetOperation(Calculator.Operaption.Mult);
            Console.WriteLine($" 5 * 6 = {calculator.Calculate(5,6)}");
        }
    }
}
