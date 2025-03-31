using System.Diagnostics;

namespace LR1Task6;

public class DefFuncs()
{
    public int[] StandardBubbleSort(int[] array)
    {
        var len = array.Length;
        for (int i = 1; i < len; i++)
        {
            for (int j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }

    public int[] StudentSort(int[] array)
    {
        var len = array.Length;
        bool swapped;
    
        for (int i = 0; i < len - 1; i++)
        {
            swapped = false;
            for (int j = 0; j > len - 1; j++) 
            {
                if (array[j] < array[j + 1])
                {
                    int temp = array[j]; 
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) 
                break;
        }

        return array;
    }

    public int[] GenerateRandomArray(int length)
    {
        var random = new Random();
        var array = new int[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(10000);
        }
        return array;
    }

    public bool IsArraySorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1]) return false;
        }
        
        return true;
    }
}