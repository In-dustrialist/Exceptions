using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace Task2
{

    ///Module 9.6.1 (HW-03) - Task 2
    public class InvalidNameException : Exception
        {
            public InvalidNameException(string message) : base(message) { }
        }

        class Program
        {
            static void Main(string[] args)
            {
                LastNameSorter sorter = new LastNameSorter();
                sorter.StartProcess += sorter.StartSorting;
                sorter.EnterLastNames();
                sorter.OnStartProcess();
                sorter.PrintArray();
            }
        }

        public delegate void SortRequest();
        public class LastNameSorter
        {
            string[] lastNames = new string[5];

            public event SortRequest StartProcess;

            public void EnterLastNames()
            {
                try
                {
                    Console.WriteLine("Введите 5 фамилий: ");
                    for (int i = 0; i < lastNames.Length; i++)
                    {
                        string input;
                        do
                        {
                            input = Console.ReadLine();
                            if (string.IsNullOrEmpty(input))
                            {
                                Console.WriteLine("Строка не может быть пустой. Повторите ввод:");
                            }
                            else if (!IsLettersOnly(input))
                            {
                                Console.WriteLine("Фамилия должна содержать только буквы. Повторите ввод:");
                            }
                        } while (string.IsNullOrEmpty(input) || !IsLettersOnly(input)); // Повторяем цикл, пока ввод не будет корректным

                        lastNames[i] = input;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            public bool IsLettersOnly(string str)
            {
                return Regex.IsMatch(str, @"^[a-zA-Z]+$");
            }

            public void SortFromAToZ()
            {
                Array.Sort(lastNames);
            }

            public void SortFromZToA()
            {
                Array.Sort(lastNames, (x, y) => String.Compare(y, x));
            }

            public void PrintArray()
            {
                Console.WriteLine("\nОтсортированный массив:");
                foreach (string s in lastNames)
                {
                    Console.WriteLine(s);
                }
            }

            public void OnStartProcess()
            {
                StartProcess?.Invoke(); // Вызываем событие
            }

            public void StartSorting()
            {
                try
                {
                    int n;
                    do
                    {
                        Console.WriteLine("\nНажмите клавишу 1 для сортировки от А до Я или 2 для сортировки от Я до А:");
                    } while (!int.TryParse(Console.ReadLine(), out n) || (n != 1 && n != 2)); // Повторяем цикл, пока не будет введено корректное значение

                    if (n == 1)
                    {
                        SortFromAToZ();
                    }
                    else if (n == 2)
                    {
                        SortFromZToA();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }
        }
    }
