using System;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContiguousNumbers.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IIntegerFilter intFilter;

        [TestInitialize]
        public void init()
        {
            intFilter = new IntegerFilter(new ErrorHandler());
        }

        [TestMethod]
        public void validInput1()
        {
            string mockInput = "1,2,3,4,5,6,7";
            var result = intFilter.GetHighestSummedContinguousCombination(mockInput);
            Assert.IsTrue(
                Array.IndexOf(result.HighestSummedCombination.Integers, 5) > -1 &&
                Array.IndexOf(result.HighestSummedCombination.Integers, 6) > -1 &&
                Array.IndexOf(result.HighestSummedCombination.Integers, 7) > -1
            );
        }

        [TestMethod]
        public void validInput2()
        {
            string mockInput = "1,2,3,4,5,6,7";
            var result = intFilter.GetHighestSummedContinguousCombination(mockInput);
            Assert.IsTrue(
                Array.IndexOf(result.HighestSummedCombination.Integers, 1) == -1 &&
                Array.IndexOf(result.HighestSummedCombination.Integers, 2) == -1 &&
                Array.IndexOf(result.HighestSummedCombination.Integers, 3) == -1
            );
        }

        [TestMethod]
        public void hasInvalidInteger()
        {
            string mockInput = "abc,2,3,4,5,6,7";
            Assert.IsTrue(intFilter.GetHighestSummedContinguousCombination(mockInput).ErrorMessages.Count == 1);
        }

        [TestMethod]
        public void doesNotMeetMinimumValueLength()
        {
            string mockInput = "1,2";
            Assert.IsTrue(intFilter.GetHighestSummedContinguousCombination(mockInput).ErrorMessages.Count == 1);
        }

        [TestMethod]
        public void doesMeetMinimumValueLength()
        {
            intFilter = new IntegerFilter(new ErrorHandler(), 2);
            string mockInput = "1,2";
            Assert.IsTrue(intFilter.GetHighestSummedContinguousCombination(mockInput).ErrorMessages.Count == 0);
        }

        [TestMethod]
        public void returnsFirstMatchingInstance()
        {
            intFilter = new IntegerFilter(new ErrorHandler());
            string mockInput = "1,2,3,1";
            var result = intFilter.GetHighestSummedContinguousCombination(mockInput);
            Assert.IsTrue(
                result.HighestSummedCombination.Integers[0] == 1 && 
                result.HighestSummedCombination.Integers[1] == 2 &&
                result.HighestSummedCombination.Integers[2] == 3 &&
                result.HighestSummedCombination.Integers[0] != 2
            );
        }
    }
}
