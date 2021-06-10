using Homework_Theme_04.ClassHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    public class Ex1
    {
        #region Задание
        // Задание 1.
        // Заказчик просит вас написать приложение по учёту финансов
        // и продемонстрировать его работу.
        // Суть задачи в следующем: 
        // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
        // За год получены два массива – расходов и поступлений.
        // Определить прибыли по месяцам
        // Количество месяцев с положительной прибылью.
        // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
        // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
        // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

        // Пример
        //       
        // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
        //     1              100 000             80 000                 20 000
        //     2              120 000             90 000                 30 000
        //     3               80 000             70 000                 10 000
        //     4               70 000             70 000                      0
        //     5              100 000             80 000                 20 000
        //     6              200 000            120 000                 80 000
        //     7              130 000            140 000                -10 000
        //     8              150 000             65 000                 85 000
        //     9              190 000             90 000                100 000
        //    10              110 000             70 000                 40 000
        //    11              150 000            120 000                 30 000
        //    12              100 000             80 000                 20 000
        // 
        // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
        // Месяцев с положительной прибылью: 10
        #endregion
        public Ex1()
        {
            List<Month> MonthsRevenue = new List<Month>();
            for (int i = 1; i <= 12; i++)
            {
                MonthsRevenue.Add(NewMonth(i));
            }
            Console.WriteLine("{0,10}   |   {1,10}  |   {2,10}  |   {3,10}", "Месяц", "Доход, руб.", "Расход, руб.", "Прибыль, руб.");
            foreach (var m in MonthsRevenue)
                Console.WriteLine("{0,10}   |   {1,10}   |   {2,10}   |   {3,10}", m.NumMonth, m.Income, m.Consumption, m.Profit);
            List<int>  WorstMonths= MonthsRevenue.OrderByDescending(x => x.Profit).Take(3).Select(x => x.NumMonth).ToList();
            Console.WriteLine("Худшая прибыль в месяцах: " + String.Join(", ",WorstMonths));
            Console.WriteLine("Месяцев с положительной прибылью: " + MonthsRevenue.Where(x => x.Profit > 0).Count());
            Console.ReadLine();

            //Вопрос по заданию: Во время отладки генерация массива проходит успешно. Однако, при запуске генерация работает некорректно. Числа дохода/расхода в иттерациях имеют идентичное значение. Вы не могли бы подсказать в чем проблема?
        }
        private Month NewMonth(int NumMonth)
        {
            Random random = new Random();
            Month AddedMont = new Month()
            {
                NumMonth = NumMonth,
                Income = Math.Round(random.NextDouble() * 100000,2),
                Consumption = Math.Round(random.NextDouble() * 100000,2),
            };
            //Как правильно реализовать это?
            AddedMont.Profit = AddedMont.Income - AddedMont.Consumption;
            return AddedMont;
        }

    }
}
