using One_dimensional_optimization.methods;

System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

Console.WriteLine("One-Dimensional Optimization Methods");
Console.WriteLine("-----------------------------------");

// Ввод параметров
double a, b, e;
Console.Write("Enter the interval [a]: ");
while (!double.TryParse(Console.ReadLine(), out a))
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}

Console.Write("Enter the interval [b]: ");
while (!double.TryParse(Console.ReadLine(), out b))
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}

Console.Write("Enter the precision [E]: ");
while (!double.TryParse(Console.ReadLine(), out e) || e <= 0)
{
    Console.WriteLine("Invalid input. Please enter a valid positive number.");
}

// Тестирование метода сканирования
Console.WriteLine("\nTesting Scanning Method:");
Scanning scanning = new Scanning(a, b, e);
double maxScanning = scanning.Calculate();
Console.WriteLine($"Maximum value found: {maxScanning}\n");

// Тестирование метода сканирования с переменным шагом
Console.WriteLine("\nTesting Scanning with Variable Step Method:");
Console.Write("Enter the number of parts to divide the interval [n]: ");
int n;
while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
{
    Console.WriteLine("Invalid input. Please enter a valid positive integer.");
}

Scanning variableStepScanning = new Scanning(a, b, e);
double maxVariableStepScanning = variableStepScanning.CalculateWithVariableStep(n);
Console.WriteLine($"Maximum value found: {maxVariableStepScanning}\n");

// Тестирование метода золотого сечения
Console.WriteLine("\nTesting Golden Section Method:");
GoldenSection goldenSection = new GoldenSection(a, b, e);
double goldenSectionResult = goldenSection.Calculate();
Console.WriteLine($"Maximum value found: {goldenSectionResult}\n");

// Тестирование метода половинного деления
Console.WriteLine("\nTesting Bisection Method:");
Bisection bisection = new Bisection(a, b, e);
double bisectionResult = bisection.Calculate();
Console.WriteLine($"Maximum value found: {bisectionResult}\n");