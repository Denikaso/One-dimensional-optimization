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

        public double Calculate()
        {
            double max = a * Math.Exp(-0.5 * a * a);

            Console.WriteLine("Iteration\t\t\tx\t\t\t\t\tf(x)");

            for (int i = 0; i <= steps; i++)
            {
                double x = a + e * i;
                double cur = EvaluateFunction(x);

                Console.WriteLine("{0}\t\t\t{1}\t\t\t\t\t{2}", i, x, cur);
                functionEvaluations++;

                if (max < cur)
                {
                    max = cur;
                }
            }

            Console.WriteLine("Function evaluations: {0}", functionEvaluations);
            return max;
        }

        public double CalculateWithVariableStep(int n)
        {
            double h = Math.Abs(b - a) / n;
            double max = a * Math.Exp(-0.5 * a * a);

            Console.WriteLine("Iteration\t\t\tx\t\t\t\tf(x)");

            while (h > e)
            {
                for (int i = 0; i <= n; i++)
                {
                    double x = a + h * i;
                    double cur = EvaluateFunction(x);

                    Console.WriteLine("{0}\t\t\t{1}\t\t\t\t{2}", functionEvaluations, x, cur);
                    functionEvaluations++;

                    if (max <= cur)
                    {
                        max = cur;
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
                    b = a + h * (Array.IndexOf(Enumerable.Range(0, n + 1).ToArray(), Array.Find(Enumerable.Range(0, n + 1).ToArray(), el => el * h == EvaluateFunction(el * h))) + 1);
                    a = a + h * (Array.IndexOf(Enumerable.Range(0, n + 1).ToArray(), Array.Find(Enumerable.Range(0, n + 1).ToArray(), el => el * h == EvaluateFunction(el * h))) - 1);
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
