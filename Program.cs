using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int Command;
            Console.WriteLine("Введите номер задания. Для выхода нажмите 0");
            Command = Convert.ToInt32(Console.ReadLine());
            switch (Command)
            {
                case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                case 1:
                    {
                        Ex1 ex1 = new Ex1();                        
                        break;
                    }
                case 2:
                    {
                        Ex2 ex2 = new Ex2();
                        break;
                    }
                case 3:
                    {
                        Ex3 ex3 = new Ex3();
                        break;
                    }
            }
        }
    }
}
