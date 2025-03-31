using System.Diagnostics;

namespace LR1Task6;

public class Compare
{
    public void CompareStandardWithStudent(
        Program.StandardBubbleSort standard,
        Program.StudentSort student,
        Program.GenerateArray generateArray,
        Program.IsArraySorted IsArraySorted
    )
    {
        var arrayToSort = generateArray(10000);

        double standardTime = 0;
        double studentTime = 0;
        int[] arrForStandard = new int[arrayToSort.Length], arrForStudent = new int[arrayToSort.Length];

        using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(7 + 0.1));

        arrayToSort.CopyTo(arrForStandard, 0);
        arrayToSort.CopyTo(arrForStudent, 0);

        try
        {
            var st = Stopwatch.StartNew();
            standard(arrForStandard);
            st.Stop();
            standardTime = st.Elapsed.TotalMilliseconds;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception was caused by the standard method: {ex.Message}");
        }

        try
        {
            var st = Stopwatch.StartNew();

            var studentResult = Task.Run(() => student(arrForStudent), cancellationTokenSource.Token);
            studentResult.Wait(cancellationTokenSource.Token);

            st.Stop();
            studentTime = st.Elapsed.TotalMilliseconds;

            if (!IsArraySorted(studentResult.Result))
            {
                Console.WriteLine($"Student result was not sorted properly: {studentResult.Result}");
                return;
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("The execution time of the student method exceeded 7 seconds.");
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception was caused by the student method: {e.Message}");
            return;
        }

        Console.WriteLine($"standard time: {standardTime} ms");
        Console.WriteLine($"student time: {studentTime} ms");
        
        if (standardTime - 200 <= studentTime && studentTime <= standardTime + 200)
        {
            Console.WriteLine("Algorithms have the same execution time");
        }
        else
        {
            Console.WriteLine("Algorithms have different execution time");
        }
    }
}