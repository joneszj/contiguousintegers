using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContiguousNumbers.Simple
{
    class Program
    {
        /// <summary>
        /// this console app simply follows the instructions more directly
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Enter numbers as CSV: ");
            // Read the entry using the Console.ReadLine() method
            string input = Console.ReadLine();
            // Convert the entry into an array of strings. 
            // Use the name "entries" for the variable that stores the string 
            // array object.
            string[] entities = input.Split(',');
            // Use a LINQ-to-Object statement to convert the string array to 
            // an integer array.
            // Use the name "numbers" for the variable that stores the integer 
            // array object.
            // The following line exists so that this program will compile.
            //int[] numbers = { 1, 2, 6, 2, -20, 5, 9, 3, -10, 3, 5, 1 };
            int[] numbers = entities.Select((e)=> { return int.TryParse(e, out int x) ? (int?)x : null; }).Where(e=>e != null).Cast<int>().ToArray();
            // zjj: "The user must enter at least three numbers." - from word doc
            if (numbers.Length < 3)
            {
                Console.WriteLine("Must enter at least 3 valid integers. Press any key to close application...");
                Console.ReadKey();
                return;
            }
            // Use another LINQ statement to get sets of three consecutive integer.
            // Hint 1: You will have to generate a collection of indices that 
            // exists in the integer array. 
            // The Enumerable class has a Range method that can do that task for you.
            // Hint 2: This latter LINQ statement makes use of the following 
            // operators:
            // Select, Skip, Take, Sum, OrderByDescending, ThenBy, First.
            // Store the result of the latter LINQ query in a variable called 
            // "result".
            // This variable is an anonymous type. However, it will require that it 
            // has a integer property called "Index". That property tells you what 
            // index to use
            // in the original integer array. 
            // The following line exists so that this program will compile.
            // var result = new { Index = 5, Sum = 17 };
            // zjj: Select builds anonymous type
            // zjj: Skip && Take && Sum iterate over collection taking the first 3 values into an enumerable to call Sum
            // zjj: OrderByDescending && First usage: to pull set of greatest sum
            // zjj: ThenBy usage: "If more than one set of numbers produce the same sum, then provide the first set as the answer." from word doc
            var result = Enumerable.Range(0, numbers.Length).Select(e => new { Index = e, Sum = numbers.Skip(e).Take(3).Sum() }).OrderByDescending(e=>e.Sum).ThenBy(e=>e.Index).First();
            //Your final statements are written below.
            Console.WriteLine
            (
                "The numbers {0}, {1}, and {2} will yield the maximum sum of {3}.",
                numbers[result.Index],
                numbers[result.Index + 1],
                numbers[result.Index + 2],
                result.Sum
            );
            Console.ReadKey();
        }

    }
}
