using System.Collections.Generic;

namespace ConsoleApplication1
{
    public interface IIntegerFilter
    {
        ((int[] Integers, int Sum) HighestSummedCombination, List<string> ErrorMessages) GetHighestSummedContinguousCombination(string input);
    }
}