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
        //Проверено.
        private void СombinationStart()
        {
            //Получаем первую порций сочетаний. Например, 5 из 2 или 2 из 3
            for (int i = 0; i < N - 1; i++)
            {
                MultiplOrderClassHelper multiplOrderClass = new MultiplOrderClassHelper();
                for (int a = 0; a < N; a++)
                {
                    if (a == i)
                        continue;
                    //Я думаю, что это как-то можно сократить, избавившись от переменной var.
                    //Применяя сокращенные операторы, скрываются операторы выхода из цикла
                    var MatrixVR = MatricesMultipl(matrices[i], matrices[a]);
                    if (MatrixVR is null)
                        continue;
                    multiplOrderClass.Intermediate = MatrixVR;

                    multiplOrderClass.Priority.Add(i);
                    multiplOrderClass.Priority.Add(a);

                    MultiplOrder.Add(multiplOrderClass);
                }
            }
            for (int i = 0; i < MultiplOrder.Count; i++)
            {
                if (MultiplOrder[i].Priority.Count() == N)
                    return;
                Combination(i);
            }
        }
        private void Combination(int index)
        {
            int v = MultiplOrder[index].Priority.Count();
            //перебираем сочетания?
            for (int i = 0; i < v; i++)
            {
                //массив для определения оставшихся вариантов умножения
                //Массив определяется верно. Встает вопрос о рациональности вызова рекурсии
                //и последующего кода, т.к. добавляется значение по порядку
                //а это значит, что может получится повторение матрицы
                List <int> vr = new List<int>(N-v);
                //перечисляем все матрицы для перемножения
                for (int a = 0; a < N; a++)
                {
                    if (a == i)
                        continue;
                    vr.Add(a);
                }
                for(int a=0;a<vr.Count()-1;a++)
                {
                    var MatrixVR = MatricesMultipl(MultiplOrder[index].Intermediate, matrices[a]);
                    if (MatrixVR is null)
                        continue;
                    MultiplOrder[index].Intermediate = MatrixVR;
                    MultiplOrder[index].Priority.Add(vr[a]);
                }
            }
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
