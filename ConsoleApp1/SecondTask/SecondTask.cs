namespace ConsoleApp1.SecondTask;

public class SecondTask(int[] data, int k)
{
    private int[] data = data;
    private int k = k;

    public void Execute(Program.DlgForSecondTask function)
    {
        Console.WriteLine("First Task Results:");
        int[] firstArray = function.Invoke(data, k); 
        foreach (var el in firstArray)
        {
            Console.WriteLine(el);
        }

        Console.WriteLine("----------");

        Console.WriteLine("Second Task Results:");
        int[] secondArray = function.Invoke(data, k); 
        foreach (var el in secondArray)
        {
            Console.WriteLine(el); 
        }
    }
}