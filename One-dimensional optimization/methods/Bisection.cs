using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_dimensional_optimization.methods
{
    internal class Bisection
    {
        private double a;
        private double b;
        private double e;
        private int functionEvaluations;

        public Bisection(double a, double b, double e)
        {
            this.a = a;
            this.b = b;
            this.e = e;
            functionEvaluations = 0;
        }

        public double Calculate()
        {
            double fa = EvaluateFunction(a);
            double fb = EvaluateFunction(b);

            if (fa * fb > 0)
            {
                Console.WriteLine("Error: The function values at the interval endpoints have the same sign.");
                return double.NaN;
            }

            double c = 0;
            double fcLeft = 0;
            double fcRight = 0;
            int iteration = 0;

            Console.WriteLine("Iteration\t\t\ta\t\t\tb\t\t\tc\t\t\tf(c)");

            do
            {
                c = (a + b) / 2;
                fcLeft = EvaluateFunction(c - e / 2);
                fcRight = EvaluateFunction(c + e / 2);

                Console.WriteLine("{0}\t\t\t{1}\t\t\t{2}\t\t\t{3}\t\t\t{4}\t\t\t{5}", iteration, a, b, c, fcLeft, fcRight);

                if (fcLeft >= fcRight)
                {
                    a = c - e / 2;                    
                }
                else
                {
                    b = c + e / 2;
                } 

                iteration++;
                functionEvaluations++;
            } while (Math.Abs(b - a) > e);

            Console.WriteLine("Function evaluations: {0}", functionEvaluations);
            return c;
        }

        private double EvaluateFunction(double x)
        {
            return x * Math.Exp(-0.5 * x * x);
        }
    }
}
