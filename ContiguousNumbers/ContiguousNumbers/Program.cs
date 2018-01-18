using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// this console app is intentionally, rediculously, and needlessly contrived (as opposed to the .simple project) and robust and is what is being referenced in the unit test project
        /// soley exists to demonstrate knowledge in more advanced concepts (solid, fp, tdd, etc). If you can write it, you can read it ;)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                do
                {
                    stringBuilder.Clear();
                    IIntegerFilter contiguousIntegerFilter = new IntegerFilter(new ErrorHandler());
                    Console.Write(Environment.NewLine + "Enter numbers as CSV: ");
                    var result = contiguousIntegerFilter.GetHighestSummedContinguousCombination(Console.ReadLine());
                    if (inputHasErrors(result.ErrorMessages))
                    {
                        PrintErrorMessages(stringBuilder, result.ErrorMessages);
                    }
                    else
                    {
                        PrintSuccessfulResults(stringBuilder, result.HighestSummedCombination);
                    }
                    Console.Write(stringBuilder.ToString() + Environment.NewLine);
                    Console.WriteLine("Press C to close the application, or any other key to retry...");
                } while (Console.ReadKey().KeyChar != 'c' && Console.ReadKey().KeyChar != 'C');
            }
            catch (Exception)
            {
                Console.WriteLine("Something went seriously wrong :( Please close the application and try again.");
                throw;
            }
        }

        #region helpers
        private static void PrintSuccessfulResults(StringBuilder stringBuilder, (int[] Integers, int Sum) HighestSummedCombination)
        {
            int numberCount = HighestSummedCombination.Integers.Length;
            stringBuilder.Append("The integers: ");
            Array.ForEach(HighestSummedCombination.Integers, (number) =>
            {
                if (--numberCount != 0)
                {
                    stringBuilder.Append(number + ", ");
                }
                else
                {
                    stringBuilder.Append(number + $" will produce the result: { HighestSummedCombination.Integers.Sum() }");
                }
            });
        }

        private static void PrintErrorMessages(StringBuilder stringBuilder, List<string> ErrorMessages)
        {
            string plural = ErrorMessages.Count > 1 ? "s were" : " was";
            stringBuilder.AppendLine($"The following error{ plural } thrown:");
            ErrorMessages.ForEach((message) => { stringBuilder.AppendLine(message); });
        }

        private static bool inputHasErrors(List<string> ErrorMessages)
        {
            return ErrorMessages.Count > 0;
        }
        #endregion
    }
}
