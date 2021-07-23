using Homework_Theme_04.ClassHelpers;
using OfficeDevPnP.Core.Diagnostics.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Homework_Theme_04
{

    //  В общем, смотрите: допустим у нас есть матрицы A1, A2, ..., AN соответствующих размеров, что определено их матричное произведение

    //A1 x A2 x...х AN

    //Нужно найти такой порядок их перемножения, чтобы количество скалярных произведений, которые нужно посчитать, было минимальным.

    //Рассмотрим конкретный пример. Допустим, нам даны 3 матрицы A1, A2, A3 размерами соответственно 10×100, 100×5 и 5×50. Существует 2 способа их перемножения (расстановки скобок): (A1 х A2) х A3 и A1 х(A2 х A3). В первом случае нам потребуется 10·100·5 + 10·5·50 = 7500 скалярных умножений, а во втором случае 100·5·50 + 10·100·50 = 75000 умножений — разница налицо.Поэтому может быть выгоднее потратить некоторое время на предобработку, решив, в каком порядке лучше всего умножать, чем умножать сразу в лоб.

    // В ответе программа должна правильно расставлять скобки, чтобы количество перемножений было минимальным.
    class Ex4
    {
        int Columns;
        int Rows;
        int N;
        List<Matrix> matrices = new List<Matrix>();
        List<MultiplOrderClassHelper> MultiplOrder = new List<MultiplOrderClassHelper>();
        public Ex4()
        {
            WriteLine("Определение оптимального порядка для перемножения матриц");
            WriteLine("Ввод Количества матриц для перемножений");
            N = Convert.ToInt32(ReadLine());
            for (int i = 0; i < N; i++)
            {
                WriteLine($"Ввод размерности матрицы {N + 1}:");
                WriteLine("Размерность по x:");
                Rows = Convert.ToInt32(ReadLine());
                WriteLine("Размерность по y:");
                Columns = Convert.ToInt32(ReadLine());
                matrices.Add(new Matrix(Rows, Columns));
            }
            СombinationStart();
            ReadLine();

        }
        private void СombinationStart()
        {
            //Получаем индексы первых возможных множетелей и добавляем их в в список возможного решения
            for (int i = 0; i < N - 1; i++)
            {
                MultiplOrderClassHelper multiplOrderClass = new MultiplOrderClassHelper();
                multiplOrderClass.Priority.Add(i);
                multiplOrderClass.Intermediate = matrices[i];
                multiplOrderClass.Index = i;
                MultiplOrder.Add(multiplOrderClass);
            }
            for (int index=0;index< MultiplOrder.Count;index++)
            {
                Combination(MultiplOrder[index]);
            }
        }
        //Реализация основной логики
        private void Combination(MultiplOrderClassHelper obj)
        {
            //определяем количество возможных множителей.
            //Балуюсь списками, т.к. мы здесь не можем заранее знать сколько множителей у того или иного сочетания может быть:D
            List<int> PossibleMultipl = new List<int>();
            //Выбор следующего множителя
            for (int a = 0; a < N; a++)
            {
                //Проверка на задвоение матриц при перемножении
                if (obj.Priority.Contains(a))
                    continue;
                else
                {
                    //проверка на возможность умножения выбранного элемента
                    if (MatricesMultipl(obj.Intermediate, matrices[a]) is null)
                        continue;
                    else
                        PossibleMultipl.Add(a);
                }
            }
            //Условие для добавления следующего "Нода"(условно)
            if (PossibleMultipl.Count > 1)
            {
                for (int IndexMultipl = 1; IndexMultipl < PossibleMultipl.Count; IndexMultipl++)
                {
                    MultiplOrderClassHelper multiplOrder = new MultiplOrderClassHelper();
                    multiplOrder = obj;
                    multiplOrder.Index = MultiplOrder.Last().Index + 1;
                    multiplOrder.Priority.Add(PossibleMultipl[IndexMultipl]);
                    MultiplOrder.Add(multiplOrder);
                }
            }
            if (PossibleMultipl.Count == 0)
                return;
            obj.Intermediate = MatricesMultipl(obj.Intermediate, matrices[PossibleMultipl[0]]);
            obj.Priority.Add(PossibleMultipl[0]);
            //Конечно, здесь можно почистить, но мне лень=D
            MultiplOrder.Find(x => x.Index == obj.Index).Intermediate = obj.Intermediate;
            MultiplOrder.Find(x => x.Index == obj.Index).Priority = obj.Priority;
            MultiplOrder.Find(x => x.Index == obj.Index).NumbOfMultipl = obj.NumbOfMultipl;

        }

        //Вспомогательный метод для определения размерности после перемножения
        public Matrix MatricesMultipl(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns == matrix2.Rows)
                return new Matrix { Columns = matrix1.Rows, Rows = matrix2.Columns };
            return null;
        }

    }
}
