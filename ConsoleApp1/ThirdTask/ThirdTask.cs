namespace ConsoleApp1.ThirdTask;

public class ThirdTask()
{
    public delegate double SeriesTermDelegate(int n);

    private Functions.Functions _functions = new Functions.Functions();
    
    // Універсальний метод для обчислення суми ряду
    public double CalculateSum(SeriesTermDelegate termFormula, double precision)
    {
        double sum = 0;
        int n = 0;
        double term;

        // Поки поточний член ряду більший за задану точність
        do
        {
            term = termFormula(n); // Обчислення поточного члена ряду
            sum += term; // Додавання його до суми
            n++;
        } while (Math.Abs(term) > precision);

        return sum;
    }

    // Формула для першого ряду: 1 + 1/2 + 1/4 + 1/8 + ...
    public double Term1(int n)
    {
        return 1.0 / Math.Pow(2, n);
    }

    public double Term2(int n)
    {
        // Починаємо з 1 і додаємо додаткові члени через факторіал.
        if (n == 0)
        {
            return 1;  // Перший член ряду = 1
        }
        return 1.0 / _functions.Factorial(n + 1); // Додаємо з 1/2!
    }

    // Формула для третього ряду: -1 + 1/2 - 1/4 + 1/8 - 1/16 + ...
    public double Term3(int n)
    {
        return Math.Pow(-1, n) / Math.Pow(2, n); // Починаємо з -1
    }

    // Загальний метод, який викликає всі ряди і виводить їх суми
    public void CalculateAndDisplaySums()
    {
        // Обчислення і виведення результатів для трьох рядів
        double sum1 = CalculateSum(Term1, 1e-6);
        Console.WriteLine("Сума першого ряду: " + sum1);

        double sum2 = CalculateSum(Term2, 1e-6);
        Console.WriteLine("Сума другого ряду: " + sum2);

        double sum3 = CalculateSum(Term3, 1e-6);
        Console.WriteLine("Сума третього ряду: " + sum3);
    }
}