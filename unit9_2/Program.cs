using System;
using System.Collections.Generic;

namespace SortingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Иванов", "Петров", "Сидоров", "Кузнецов", "Попов" };

            SortNames(names, SortType.AscendingOrder);

            Console.WriteLine("Введите 1 для сортровки от А к Я или 2 для сортровки от Я к А.");
            string input = Console.ReadLine();

            try
            {
                int sortType = Int32.Parse(input);

                if (sortType == 1)
                {
                    SortNames(names, SortType.AscendingOrder);
                }
                else if (sortType == 2)
                {
                    SortNames(names, SortType.DescendingOrder);
                }
                else
                {
                    throw new InvalidInputException("Неверный Ввод. Введите 1 или 2.");
                }
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный Ввод. Введите число.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Names: {0}", string.Join(", ", names));
            }

            Console.ReadKey();
        }

        public static void SortNames(List<string> names, SortType sortType)
        {
            if (sortType == SortType.AscendingOrder)
            {
                names.Sort();
            }
            else
            {
                names.Sort((x, y) => y.CompareTo(x));
            }
        }
    }

    public enum SortType
    {
        AscendingOrder,
        DescendingOrder
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}