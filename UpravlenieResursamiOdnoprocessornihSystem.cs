using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace UpravlenieResursamiOdnoprocessornihSystem
{
    class Program
    {
        static void Main(string[] args)
        {  // Алгоритм SPT
            int R = 40;
            int LK = 2;
            int L = 5;
            Queue<int> A = new Queue<int>(); //очередь длительностей процессов для 1го алгоритма
            Queue<int> B = new Queue<int>(); //очередь длительностей процессов для 2го алгоритма
            Random rnd = new Random();
            int n = 0, Current; // n - кол-во тактов Current - переменная под текущее значение, взятое из очереди
            int LastSmallWork = 0, SmallWorkCount = 0; // LastSmallWork считает время пребывания маленьких работ в системе, SmallWorkCount считает кол-во этих работ
            for (int i = 0; i < 10; i++)
            {
                if (rnd.Next(100) < R) // с вероятностью R получает заявку на большую работу
                {
                    Current = rnd.Next(LK + 1, L);
                    A.Enqueue(Current);
                    B.Enqueue(Current);
                    Console.WriteLine("Процесс обрабатывается. Большая заявка L = {0}", Current);
                }
                else // С вероятностью (100 - R) приходит заявка на маленькую работу
                {
                    Current = rnd.Next(1, LK);
                    A.Enqueue(Current);
                    B.Enqueue(Current);
                    Console.WriteLine("Процесс обрабатывается. Маленькая заявка S = {0}", Current);
                    SmallWorkCount++; // считает количество маленьких работ 
                    LastSmallWork = i + 1; // определяет, в какой момент закончится обслуживание маленьких работ
                }
            }
            // Алгоритм RR
            while (A.Count != 0)
            {
                Current = A.Dequeue(); // Обрабатывает поступившую заявку
                if (Current > LK) // Если заявка большая то, частично выполняется работа
                {
                    Current -= LK; 
                    A.Enqueue(Current); // оставшееся заносится в очередь на второй круг
                    Console.WriteLine("Процесс обрабатывается. Обрезанная большая заявка C = {0}", Current);
                }
                n++; // Пройден 1 такт
            }
            Console.WriteLine("\nОбщее время ожидания маленьких работ " + LastSmallWork);
            Console.WriteLine("Количество обработанных малых работ " + SmallWorkCount);
            Console.WriteLine("Такты " + n);
            if (SmallWorkCount != 0) //если маленьких работ не было, то не вычисляет эту характеристику
            {
                double middleTimeOfMinimumWorks = (double)LastSmallWork / SmallWorkCount; //среднее время ожидания маленькой заявки в тактах
                Console.WriteLine("Среднее время пребывания в системе маленькой работы в тактах " + middleTimeOfMinimumWorks + "\n\n");
            }
            n = 0; // Обнуление счетчика тактов
            while (B.Count != 0)
            {
                Current = B.Dequeue(); // Обрабатывает поступившую заявку
                if (Current > LK) // Если заявка большая, то вырабатывает её, пока она себя не исчерпает
                {
                    Console.WriteLine("Процесс обрабатывается. Большая заявка L = {0}", Current);
                    n++;
                    do  
                    {
                        n++;
                        Current -= LK;
                        Console.WriteLine("Процесс обрабатывается. Обрезанная большая заявка C = {0}", Current);
                    } while (Current > LK);
                }
                else // если заявка маленькая определяется в какой момент поступит последняя маленькая заявка
                {
                    n++;
                    Console.WriteLine("Процесс обрабатывается. Маленькая заявка S = {0}", Current);
                    LastSmallWork = n;                 
                  }
            }
            Console.WriteLine("\nОбщее время ожидания маленьких работ " + LastSmallWork);
            if (SmallWorkCount != 0) //если маленьких работ не было, то не вычисляет эту характеристику
            {
                double middleTimeOfMinimumWorks = (double)LastSmallWork / SmallWorkCount; //среднее время пребывания в системе маленькой заявки в тактах
                Console.WriteLine("Среднее время пребывания в системе маленькой работы в тактах " + middleTimeOfMinimumWorks);
            }
            Console.ReadKey();
        }
    }
}
