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

        public double Calculate(out double x)
        {
            double fa = EvaluateFunction(a);
            double fb = EvaluateFunction(b);

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

                Console.WriteLine("{0, 4}\t\t\t{1, 20}\t\t\t{2, 20}\t\t\t{3, 20}\t\t\t{4, 20}\t\t\t{5, 20}", iteration, a, b, c, fcLeft, fcRight);

                if (fcLeft >= fcRight)
                {
                    b = c + e / 2;                    
                }
                else
                {
                    a = c - e / 2;
                } 

                iteration++;
                functionEvaluations++;
            } while ((Math.Abs(b - a) - e) == 1e-9);

            Console.WriteLine("Function evaluations: {0}", functionEvaluations);            
            if(fcLeft > fcRight)
            {
                x = c - e / 2;
                return fcLeft;
            }
            else
            {
                x = c + e / 2;
                return fcRight;
            }            
        }

        private double EvaluateFunction(double x)
        {
            return x * Math.Exp(-0.5 * x * x);
        }
    }
}
