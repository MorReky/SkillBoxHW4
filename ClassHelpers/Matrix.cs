using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Homework_Theme_04.ClassHelpers
{
    public class Matrix
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[,] matrix { get; set; }

        public Matrix()
        {
            WriteLine("Введите количество столбцов матрицы:");
            Columns = Convert.ToInt32(ReadLine());
            WriteLine("Введите количество строк матрицы:");
            Rows = Convert.ToInt32(ReadLine());
            matrix = FillingMatrix();
        }

        public Matrix(int rows,int columns)
        {
            Rows = rows;
            Columns = columns;
            matrix = FillingMatrix(0);
        }

        internal void PrintMatrixOnConsole()
        {
            for (int i = 0; i < Rows; i++)
            {
                WriteLine();
                for (int a = 0; a < Columns; a++)
                {
                    if (a == 0) Write("|");
                    Write("{0,4}", matrix[i, a]);
                    if (a == Columns - 1) Write(" |\n");
                }
            }
        }

        /// <summary>
        /// Функция заполнения экземпляра матрицы случайными числами
        /// </summary>
        /// <returns></returns>
        internal int[,] FillingMatrix()
        {
            Random random = new Random();
            int[,] Matrix = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int a = 0; a < Columns; a++)
                    Matrix[i, a] = random.Next(0, 10);
            }
            return Matrix;
        }

        /// <summary>
        /// Функция заполнения экземпляра матрицы конкретным значением
        /// </summary>
        /// <returns></returns>
        internal int[,] FillingMatrix(int num)
        {
            int[,] Matrix = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int a = 0; a < Columns; a++)
                    Matrix[i, a] = num;
            }
            return Matrix;
        }

        /// <summary>
        /// Определение оператора для определения суммы матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows ||
                matrix1.Columns != matrix2.Columns)
                return null;
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int a = 0; a < matrix1.Columns; a++)
                    matrix1.matrix[i, a] = matrix1.matrix[i, a] + matrix2.matrix[i, a];
            }
            return matrix1;

        }
    }
}
