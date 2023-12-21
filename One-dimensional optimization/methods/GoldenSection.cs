using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_dimensional_optimization.methods
{
    internal class GoldenSection
    {
        private double a;
        private double b;
        private double e;
        private int functionEvaluations;

        private const double goldenRatio = 0.618033988749895;

        public GoldenSection(double a, double b, double e)
        {
            this.a = a;
            this.b = b;
            this.e = e;
            functionEvaluations = 0;
        }

        public double Calculate(out double x)
        {
            double d = a + (b - a) * ((Math.Sqrt(5) - 1) / 2);
            double c = b - (b - a) * ((Math.Sqrt(5) - 1) / 2);            

            double f1 = EvaluateFunction(c);
            double f2 = EvaluateFunction(d);

            Console.WriteLine("{0, 4}\t{1, 16}\t{2, 16}\t{3, 16}\t{4, 16}\t{5, 16}\t{6, 16}", "Iter", "a", "b", "x1", "x2", "f(x1)", "f(x2)");

            while (Math.Abs(b - a) > e)
            {
                Console.WriteLine("{0, 4}\t{1, 16}\t{2, 16}\t{3, 16}\t{4, 16}\t{5, 16}\t{6, 16}", functionEvaluations, a, b, c, d, f1, f2);

                if (f1 < f2)
                {
                    a = c;
                    c = d;
                    d = b - (b - a) * ((Math.Sqrt(5) - 1) / 2);
                    f1 = f2;
                    f2 = EvaluateFunction(d);
                }
                else
                {
                    b = d;
                    d = c;                    
                    c = a + (b - a) * ((Math.Sqrt(5) - 1) / 2);
                    f2 = f1;
                    f1 = EvaluateFunction(c);                    
                }

                functionEvaluations++;
            }

            Console.WriteLine("Function evaluations: {0}", functionEvaluations);
            if (f1 > f2)
            {
                x = c;
                return f1;
            }
            else
            {
                x = d;
                return f2;
            }           
        }

        private double EvaluateFunction(double x)
        {
             return x * Math.Exp(-0.5 * x * x);
        }
    }
}
