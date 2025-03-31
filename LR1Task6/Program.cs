namespace LR1Task6;

public class Program
{
    public delegate int[] StandardBubbleSort(int[] array);
    public delegate int[] StudentSort(int[] array);
    public delegate int[] GenerateArray(int length);
    public delegate bool IsArraySorted(int[] array);
    
    static void Main(string[] args)
    {
        DefFuncs defFuncs = new DefFuncs();

        var standardBubbleSort = new StandardBubbleSort(defFuncs.StandardBubbleSort);
        var studentSort = new StudentSort(defFuncs.StudentSort);
        var generateArray = new GenerateArray(defFuncs.GenerateRandomArray);
        var isArraySorted = new IsArraySorted(defFuncs.IsArraySorted);
        
        Compare compare = new Compare();
        compare.CompareStandardWithStudent(standardBubbleSort, studentSort, generateArray, isArraySorted);
    }
}