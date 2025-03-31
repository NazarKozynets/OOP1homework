using System;
using ConsoleApp1.FourthTask;
using ConsoleApp1.Functions;
using ConsoleApp1.SecondTask;
using ConsoleApp1.ThirdTask;
using Timer = ConsoleApp1.TaskOne.Timer;

public class Program
{
    public delegate void DlgConsoleWrite(string text);
    public delegate int[] DlgForSecondTask(int[] data, int k);
    
    private Functions _functions = new Functions();
    
    static void Main(string[] args)
    {
        Program p = new Program();
        // p.Task1();
        // p.Task2();
        // p.Task3();
        p.Task4();
        Console.ReadLine();
    }
    
    private void Task1()
    {
        string[] arr = new[]
        {
            "timer", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        Timer timer = new Timer();
        DlgConsoleWrite dlgConsoleWrite = _functions.ConsoleWrite;
        timer.Run(dlgConsoleWrite, 1000, arr);
    }

    private void Task2()
    {
        int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int k = 3;
        
        SecondTask secondTask = new SecondTask(data: arr, k);
        var dlg = new DlgForSecondTask(_functions.SecondTaskFirst);
        dlg += _functions.SecondTaskSecond;
        
        secondTask.Execute(dlg);
    }

    private void Task3()
    {
        var thirdTask = new ThirdTask();
        thirdTask.CalculateAndDisplaySums();
    }

    private void Task4()
    {
        var fourthTask = new FourthTask();
    }
}