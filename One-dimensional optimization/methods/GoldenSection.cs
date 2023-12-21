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

        public double Calculate()
        {
            double x1 = b - goldenRatio * (b - a);
            double x2 = a + goldenRatio * (b - a);

            double f1 = EvaluateFunction(x1);
            double f2 = EvaluateFunction(x2);

            Console.WriteLine("Iteration\ta\t\tb\t\tx1\t\tx2\t\tf(x1)\t\tf(x2)");

            while (Math.Abs(b - a) > e)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}", functionEvaluations, a, b, x1, x2, f1, f2);

                if (f1 < f2)
                {
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = b - goldenRatio * (b - a);
                    f1 = EvaluateFunction(x1);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    x2 = a + goldenRatio * (b - a);
                    f2 = EvaluateFunction(x2);
                }

                functionEvaluations++;
            }

            Console.WriteLine("Function evaluations: {0}", functionEvaluations);
            return (a + b) / 2;
        }

        private double EvaluateFunction(double x)
        {
             return x * Math.Exp(-0.5 * x * x);
        }
    }
}
