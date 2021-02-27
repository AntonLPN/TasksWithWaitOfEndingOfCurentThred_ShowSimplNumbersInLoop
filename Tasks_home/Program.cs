using System;
using System.Threading.Tasks;

namespace Tasks_home
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;

            do
            {
                Console.WriteLine("1 - Task1");
                Console.WriteLine("2 - Task2");
                Console.WriteLine("0 - EXIT");
                Int32.TryParse(Console.ReadLine(), out menu);




                switch (menu)
                {


//                    Тема: Параллельное программирование
//Задание №1
//Приложение должно отображать все простые числа от 0 до 1000.Для
//отображения чисел необходимо использовать класс Task. Основной поток должен
//ожидать завершения задачи.
                    case 1:
                        {
                            Task task = new Task(()=>ShowSimpleNumbers());
                            task.Start();
                          task.Wait();
                            Console.WriteLine("Завершение метода Main");

                        }
                        break;
//                        Задание №2
//Модифицируйте первое задание.Необходимо передать задаче границы для
//генерации простых чисел. Основной поток должен ожидать завершения задачи.
//После завершения задачи основной поток выводит количество простых чисел.
                    case 2:
                        {
                            int begin = 0;
                            int end = 0;
                            try
                            {
                                Console.Write("Enter the start of the loop boundary >>");
                                Int32.TryParse(Console.ReadLine(), out begin);
                                Console.Write("Enter the end of the loop boundary >>");
                                Int32.TryParse(Console.ReadLine(), out end);
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }


                            try
                            {
                                Task task = new Task(() => ShowSimpleNumbers2(begin, end));
                                task.Start();
                                task.Wait();
                                Console.WriteLine("Завершение метода Main");
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                           
                        }
                        break;
                }

            } while (menu!=0);

           
        }
        /// <summary>
        /// метод отображает все простые числа
        /// </summary>
        private static void ShowSimpleNumbers()
        {
            Console.WriteLine($"MyTask() №{Task.CurrentId} запущен" );
            for (int i = 0; i < 1000; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " |");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"MyTask() #{Task.CurrentId} завершен");
        }

        /// <summary>
        /// метод отображает все простые числа принимает аргументом границы начала и конца границ
        /// </summary>
        private static void ShowSimpleNumbers2(int star, int end)
        {
            Console.WriteLine($"MyTask() №{Task.CurrentId} запущен");
            for (int i = star; i < end; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " |");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"MyTask() #{Task.CurrentId} завершен");
        }


        /// <summary>
        /// Метод проверки является ли число простым
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPrime(int x)
        {
            if (x <= 1)
            {
                return false;
            }


            for (int i = 2; i <= x / 2; i++)
            {
                if ((x % i) == 0)
                    return false;
            }              
            return true;
        }
    }
}
