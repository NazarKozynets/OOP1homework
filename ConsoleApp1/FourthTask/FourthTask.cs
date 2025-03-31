using System;

namespace ConsoleApp1.FourthTask
{
    public class FourthTask
    {
        private delegate double MyDelegate(int x);

        public FourthTask()
        {
            MyDelegate[] myDelegates = new MyDelegate[]
            {
                x => Math.Sqrt(Math.Abs(x)), 
                x => Math.Pow(x, 3), 
                x => x + 3.5 
            };

            while (true)
            {
                try
                {
                    Console.WriteLine("Вводьте рядки послідовно один за одним у форматі '0 x', '1 x', '2 x'");

                    string line = Console.ReadLine().Trim();

                    if (line.Length < 3 || !int.TryParse(line[0].ToString(), out int selectedFunc) ||
                        !int.TryParse(line[2].ToString(), out int selectedParam))
                    {
                        throw new FormatException("Невірний формат вводу.");
                    }

                    if (selectedFunc < 0 || selectedFunc > 2)
                    {
                        throw new ArgumentOutOfRangeException("Невірний номер функції.");
                    }

                    double result = myDelegates[selectedFunc](selectedParam);

                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Сталася помилка: {e.Message}. Натисніть будь-яку кнопку для виходу.");
                    break;
                }
            }
        }
    }
}