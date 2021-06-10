using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_Theme_04.ClassHelpers;

namespace Homework_Theme_04
{
    class Ex3
    {
        #region Задание
        // 
        // * Задание 3.1
        // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
        // Добавить возможность ввода количество строк и столцов матрицы и число,
        // на которое будет производиться умножение.
        // Матрицы заполняются автоматически. 
        // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
        //
        // Пример
        //
        //      |  1  3  5  |   |  5  15  25  |
        //  5 х |  4  5  7  | = | 20  25  35  |
        //      |  5  3  1  |   | 25  15   5  |
        //
        //
        // ** Задание 3.2
        // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
        // Добавить возможность ввода количество строк и столцов матрицы.
        // Матрицы заполняются автоматически
        // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
        //
        // Пример
        //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
        //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
        //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
        //  
        //  
        //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
        //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
        //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
        //
        // *** Задание 3.3
        // Заказчику требуется приложение позволяющщее перемножать математические матрицы
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
        // Добавить возможность ввода количество строк и столцов матрицы.
        // Матрицы заполняются автоматически
        // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
        //  
        //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
        //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
        //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
        //
        //  
        //                  | 4 |   
        //  |  1  2  3  | х | 5 | = | 32 |
        //                  | 6 |  
        //
        #endregion

        delegate void Command();

        public Ex3()
        {
            int Command;
            Console.WriteLine("Введите номер подзадания задания №3.");
            Command = Convert.ToInt32(Console.ReadLine());
            switch (Command)
            {

                case 1:
                    {
                        Ex3_1();
                        break;
                    }
                case 2:
                    {
                        Ex3_2();
                        break;
                    }
                case 3:
                    {
                        Ex3_3();
                        break;
                    }
            }
        }

        public void Ex3_1()
        {
            Matrix matrixObj = new Matrix();
            int N;
            WriteLine("Умножение_матрицы_на_число");

            WriteLine("Сгенерированная матрица:");
            matrixObj.PrintMatrixOnConsole();

            WriteLine("Введите число:");
            N = Convert.ToInt32(ReadLine());

            for (int i = 0; i < matrixObj.Rows; i++)
            {
                for (int a = 0; a < matrixObj.Columns; a++)
                    matrixObj.matrix[i, a] = matrixObj.matrix[i, a] * N;
            }
            WriteLine("Результат перемножения матрицы на число {0}:", N);
            matrixObj.PrintMatrixOnConsole();
            ReadLine();
        }
        public void Ex3_2()
        {
            WriteLine("Сложение_матриц");

            WriteLine("Создание матрицы 1:");
            Matrix matrixObj1 = new Matrix();
            WriteLine("Сгенерированная матрица 1:");
            matrixObj1.PrintMatrixOnConsole();

            WriteLine("Создание матрицы 2:");
            Matrix matrixObj2 = new Matrix();
            WriteLine("Сгенерированная матрица 2:");
            matrixObj2.PrintMatrixOnConsole();

            if (matrixObj1.Rows != matrixObj2.Rows ||
                matrixObj1.Columns != matrixObj2.Columns)
            {
                WriteLine("Размерности матриц не совпадают. Для выполнения сложения размеры генерируемых матриц должны быть равными\nПожалуйстта, повторите попытку.");
                ReadLine();
                Ex3_2();
            }
            WriteLine("Результат сложения двух матриц:");
            (matrixObj1 + matrixObj2).PrintMatrixOnConsole();
            ReadLine();
        }
        public void Ex3_3()
        {
            WriteLine("Умножение_матриц");
            WriteLine("Создание матрицы 1:");
            Matrix matrixObj1 = new Matrix();
            WriteLine("Сгенерированная матрица 1:");
            matrixObj1.PrintMatrixOnConsole();

            WriteLine("Создание матрицы 2:");
            Matrix matrixObj2 = new Matrix();
            WriteLine("Сгенерированная матрица 2:");
            matrixObj2.PrintMatrixOnConsole();

            Matrix matrixObj3 = new Matrix(matrixObj2.Columns, matrixObj2.Rows);

            if (matrixObj1.Columns != matrixObj2.Rows)
            {
                WriteLine("Размерности матриц не совпадают. Для выполнения перемножения количество столбцов в матрице 1 должно равняться количеству строк в матрице 2\nПожалуйстта, повторите попытку.");
                ReadLine();
                Ex3_3();
            }

            for (int i = 0; i < matrixObj2.Columns; i++)
            {
                for (int a = 0; a < matrixObj2.Rows; a++)
                {
                    for (int c = 0; c < matrixObj1.Columns; c++)
                    {
                        matrixObj3.matrix[i, a] += matrixObj1.matrix[i, a] * matrixObj2.matrix[a, c];
                    }
                }
            }
            WriteLine("Результат перемножения матриц:");
            matrixObj3.PrintMatrixOnConsole();
            ReadLine();
        }

    }
}
