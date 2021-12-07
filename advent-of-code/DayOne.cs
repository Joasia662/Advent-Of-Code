using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class DayOne
    {
        public static int calculateDepthIncreases(string[] valuesTable)
        {
            int growCount = 0;
            for (int index = 0; index < valuesTable.Length - 2; index++)
            {
                if (Int32.Parse(valuesTable[index]) < Int32.Parse(valuesTable[index + 1])) growCount++;
            }

            return growCount;
        }
        public static int calculateDepthIncreasesOfSums(string[] valuesTable)
        {
            int[] sumArray = new int[valuesTable.Length];
            sumArray = fillSumArray(valuesTable);
            int growCount = 0;

            for (int index = 0; index < sumArray.Length - 1; index++)
            {
                if (sumArray[index] < sumArray[index + 1]) growCount++;
            }

            return growCount;

        }

        private static int[] fillSumArray(string[] valuesTable)
        {
            int[] tmp = new int[valuesTable.Length];
            for (int index = 0; index < valuesTable.Length - 3; index++)
            {
                int sum = Int32.Parse(valuesTable[index]);
                sum += Int32.Parse(valuesTable[index + 1]);
                sum += Int32.Parse(valuesTable[index + 2]);
                tmp[index] = sum;
            }
            return tmp;
        }
    }
}
