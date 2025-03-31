namespace ConsoleApp1.TaskOne;

public class Timer
{
    public void Run(Program.DlgConsoleWrite function, int t, string[] array)
    {
        Thread thread = new Thread(() =>
        {
            DateTime startTime = DateTime.Now; 
            int counter = 0;
                
            while ((DateTime.Now - startTime).TotalSeconds < 10 && counter < array.Length) 
            {
                function.Invoke(array[counter]);
                Thread.Sleep(t);
                counter++;
            }
        });

        thread.IsBackground = true; // завершгшити потік при закритті програми
        thread.Start();
    }
}