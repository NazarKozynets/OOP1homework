namespace ConsoleApp1.Functions;

public class Functions
{
    public void ConsoleWrite(string text)
    {
        Console.WriteLine(text);
    }

    public int[] SecondTaskFirst(int[] data, int k)
    {
        ConsoleWrite("FIRST");
        return data.Where((int element) => element % k == 0).ToArray();
    }

    public int[] SecondTaskSecond(int[] data, int k)
    {
        ConsoleWrite("SECOND");
        int count = 0;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] % k == 0)
            {
                count++;
            }
        }

        int[] result = new int[count];
        int index = 0;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] % k == 0)
            {
                result[index++] = data[i];
            }
        }

        return result;
    }

    public long Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}