/*
3.13.	 Дана таблица из 10 строк и 5 столбцов. Определить:
1)   в какой строке находится значение с порядковым номером 
n, если нумерацию вести построчно сверху вниз, а в каждой 
строке – слева направо;
2)  в какой строке находится это значение.

*/

using System.Data;

namespace Practice_ConsoleApps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte rows = 10, columns = 5, n = 0;
            CheckInput("Введите порядковый номер от 1 до 50: ", ref n);
            GetPositionInTable(n, rows, columns, out byte row, out byte col);

            Console.WriteLine($"Значение с порядковым номером {n} " +
                $"находится в {row} строке и в {col} столбце");

            //testing
            for (byte i = 1; i <= 50; i++)
            {
                GetPositionInTable(i, rows, columns, out row, out col);
                Console.WriteLine($"Значение с порядковым номером {i} " +
                    $"находится в {row} строке и в {col} столбце");
            }
        }
        static void CheckInput(string message, ref byte var)
        {
            while (true)
            {
                Console.Write(message);
                if (!byte.TryParse(Console.ReadLine(), out var) || var < 1 || var > 50)
                {
                    Console.WriteLine("Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                break;
            }
        }

        static void GetPositionInTable(byte numberInTable, byte rows, byte columns, out byte row, out byte col)
        {
            row = (byte)Math.Ceiling((double)numberInTable / columns);
            col = (byte)(numberInTable - (row - 1) * columns);
        }
    }
}
