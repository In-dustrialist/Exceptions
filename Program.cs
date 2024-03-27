using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    ///Module 9.6.1 (HW-03) - Task 1
    internal class Program
    {
        public class CustomException : Exception
        {
            public CustomException(string message) : base(message)
            {
            }
        }
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[]
            {
                new IndexOutOfRangeException(),
                new DivideByZeroException(),
                new ArgumentNullException(),
                new InvalidTimeZoneException(),
                new CustomException("Custom Exception occurred")
            };

            foreach (var ex in exceptions)
            {
                try
                {
                    throw ex;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("IndexOutOfRangeException occurred");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("DivideByZeroException occurred");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException occurred");
                }
                catch (InvalidTimeZoneException)
                {
                    Console.WriteLine("InvalidTimeZoneException occurred");
                }
                catch (CustomException customEx)
                {
                    Console.WriteLine(customEx.Message);
                }
            }
        }
    }
}