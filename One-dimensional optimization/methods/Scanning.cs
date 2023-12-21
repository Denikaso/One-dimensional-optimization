using System;

namespace One_dimensional_optimization.methods
{
    internal class Scanning
    {
        private double a;
        private double b;
        private double e;
        private double steps;
        private int functionEvaluations;

        public Scanning(double a, double b, double e)
        {
            this.a = a;
            this.b = b;
            this.e = e;
            steps = Math.Abs(b - a) / e;
            functionEvaluations = 0;
        }

        public double Calculate(out double maxx)
        {
            double max = a * Math.Exp(-0.5 * a * a);
            maxx = 0;
            Console.WriteLine("Iteration\t\t\t  x\t\t\t\t\tf(x)");

            for (int i = 0; i <= steps; i++)
            {
                double x = a + e * i;
                double cur = EvaluateFunction(x);

                Console.WriteLine("{0,5}\t\t\t{1,20}\t\t\t{2,20}", i, x, cur);
                functionEvaluations++;

                if (max < cur)
                {
                    max = cur;
                    maxx = x;
                }
            }

            Console.WriteLine("Function evaluations: {0}", functionEvaluations);
            return max;
        }

        public double CalculateWithVariableStep(int n, out double maxx)
        {
            double h = Math.Abs(b - a) / n;
            double max = a * Math.Exp(-0.5 * a * a);
            maxx = 0;

            Console.WriteLine("Iteration\t\t\t  x\t\t\t\t\tf(x)");

            while (h > e)
            {
                for (int i = 0; i <= n; i++)
                {
                    double x = a + h * i;
                    double cur = EvaluateFunction(x);

                    Console.WriteLine("{0,5}\t\t\t{1,20}\t\t\t{2,20}", functionEvaluations, x, cur);
                    functionEvaluations++;

                    if (max <= cur)
                    {
                        max = cur;
                        maxx = x;
                    }
                }

                if (max == EvaluateFunction(a))
                {
                    b = a + h;
                }
                else if (max == EvaluateFunction(a + h * n))
                {
                    a = a + h * (n - 1);
                }
                else
                {
                    int index = Array.IndexOf(Enumerable.Range(0, n + 1).ToArray(), Array.Find(Enumerable.Range(0, n + 1).ToArray(), el => el * h == EvaluateFunction(el * h)));

                    b = a + h * (index + 1);
                    a = a + h * (index - 1);
                }

                h = Math.Abs(b - a) / n;
            }

            Console.WriteLine("Function evaluations: {0}", functionEvaluations - 1);
            return max;
        }

        private double EvaluateFunction(double x)
        {
            return x * Math.Exp(-0.5 * x * x);
        }
    }
}
