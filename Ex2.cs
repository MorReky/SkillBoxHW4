using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Ex2
    {
        #region Задание
        // * Задание 2
        // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
        // 
        // При N = 9. Треугольник выглядит следующим образом:
        //                                 1
        //                             1       1
        //                         1       2       1
        //                     1       3       3       1
        //                 1       4       6       4       1
        //             1       5      10      10       5       1
        //         1       6      15      20      15       6       1
        //     1       7      21      35      35       21      7       1
        //                                                              
        //                                                              
        // Простое решение:                                                             
        // 1
        // 1       1
        // 1       2       1
        // 1       3       3       1
        // 1       4       6       4       1
        // 1       5      10      10       5       1
        // 1       6      15      20      15       6       1
        // 1       7      21      35      35       21      7       1
        // 
        // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля
        #endregion

        private int _N;
        public int N
        {
            get => _N;
            set => _N = value < 25 ? value : 2;
        }
        public Ex2()
        {
            Console.WriteLine("Треугольник Паскаля");
            Console.WriteLine("Введите количество первых строк для построения: ");
            N = Convert.ToInt32(Console.ReadLine());
            int[][] Arr = new int[N][];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine();
                Arr[i] = new int[i + 1];
                for (int a = 0; a < Arr[i].Length; a++)
                {
                    if (a == 0)
                    {
                        Arr[i][a] = 1;
                        Console.Write("{0}", Arr[i][a]);
                        continue;
                    }
                    if (a == Arr[i].Length - 1)
                    {
                        Arr[i][a] = 1;
                        Console.Write("{0}", Arr[i][a]);
                        continue;
                    }
                    Arr[i][a] = Arr[i - 1][a - 1] + Arr[i - 1][a];
                    Console.Write("{0}", Arr[i][a]);
                }
            }
            Console.ReadLine();

        }
        //public void PrintTab(int Num)
        //{
        //    for (int i = 0; i < Num; i++)
        //        Console.Write("\t");
        //}
    }
}
