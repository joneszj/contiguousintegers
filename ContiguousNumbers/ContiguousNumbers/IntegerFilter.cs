using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class IntegerFilter : IIntegerFilter
    {
        #region members
        private List<int> parsedIntegers;
        private IErrorHandler ErrorService;
        private int integerCount;
        private char delimeter;
        private string[] entities;
        private List<(int[] Integers, int Sum)> combinations;
        #endregion

        #region ctor
        public IntegerFilter(IErrorHandler errorService, int integerCount = 3, char delimeter = ',')
        {
            parsedIntegers = new List<int>();
            ErrorService = errorService;
            this.integerCount = integerCount;
            this.delimeter = delimeter;
            this.combinations = new List<(int[] Indices, int Sum)>();
        }
        #endregion

        public ((int[] Integers, int Sum) HighestSummedCombination, List<string> ErrorMessages) GetHighestSummedContinguousCombination(string input)
        {
            entities = input.Split(delimeter);
            if (IsValidLength())
            {
                ParseIntegersFromEntities();
                BuildCombinationsList();
            };
            return (GetHighestCombinedSum(), ErrorService.GetErrorMessages());
        }

        #region helpers
        private void BuildCombinationsList()
        {
            for (int i = 0; i < parsedIntegers.Count; i++)
            {
                combinations.Add((Integers: parsedIntegers.Skip(i).Take(this.integerCount).ToArray(), Sum: parsedIntegers.Skip(i).Take(this.integerCount).Sum()));
            }
        }

        private bool IsValidLength()
        {
            bool isValid = entities.Length >= integerCount;
            if (!isValid)
            {
                ErrorService.AddErrorMessage($"{ integerCount } is the minimum integer count required. { entities.Length } supplied.");
            }
            return isValid;
        }

        private (int[] Integers, int Sum) GetHighestCombinedSum()
        {
            return combinations.OrderByDescending(e => e.Sum).FirstOrDefault();
        }

        private void ParseIntegersFromEntities()
        {
            Array.ForEach(entities, ExtractIntegers());
        }

        private Action<string> ExtractIntegers()
        {
            return (entity) =>
            {
                bool isInteger = int.TryParse(entity, out int parsedInt);
                if (!isInteger)
                {
                    ErrorService.AddErrorMessage($"{entity} is not a valid integer");
                }
                else
                {
                    parsedIntegers.Add(parsedInt);
                }
            };
        }
        #endregion
    }
}
