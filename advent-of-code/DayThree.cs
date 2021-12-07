using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class DayThree
    {
        public static int getPowerConsumption(string[] valuesTable)
        {
            int gammaRate;
            int epsilonRate;

            int[] gamma = new int[valuesTable[0].Length];
            int[] epsilon = new int[valuesTable[0].Length];
            int[] columnValueCounter = countValueInTableColumns(valuesTable);

           fillGammaElipsonValue(ref gamma, ref epsilon, columnValueCounter, valuesTable.Length);
            gammaRate = Convert.ToInt32(string.Join("", gamma), 2);
            epsilonRate = Convert.ToInt32(string.Join("", epsilon), 2);

            return epsilonRate * gammaRate;
        }

        public static int getLifeSupportRating(string[] valuesTable)
        {
            int ratingOxygenGenerator = 0;
            int ratingCo2Scruber = 0;

            List<string> oxygenToKeep = new List<string>();
            List<string> co2ToKeep = new List<string>();

            string[] tmpOxygenValuesTable = valuesTable;
            string[] tmpCO2ValuesTable = valuesTable;

            for (int counterIndex = 0; counterIndex < valuesTable[0].Length; counterIndex++)
            {
                if (tmpOxygenValuesTable.Length > 1)
                {
                    int columnValueCounterOxygen = countValueInTableColumn(tmpOxygenValuesTable, counterIndex);
                    int lookedValueOxygen = checkValue(columnValueCounterOxygen, tmpOxygenValuesTable.Length, true);

                    for (int tableIndex = 0; tableIndex < tmpOxygenValuesTable.Length; tableIndex++)
                    {
                        string tmpCharValue = tmpOxygenValuesTable[tableIndex][counterIndex].ToString();
                        if (Int32.Parse(tmpCharValue) == lookedValueOxygen) oxygenToKeep.Add(tmpOxygenValuesTable[tableIndex]);
                    }

                    string[] tmpNumbersArrayOxygen = new string[oxygenToKeep.Count()];
                    int numbersArrayIndex = 0;
                    foreach (string element in oxygenToKeep)
                    {
                        tmpNumbersArrayOxygen[numbersArrayIndex] = element;
                        numbersArrayIndex++;
                    }
                    oxygenToKeep.Clear();
                    tmpOxygenValuesTable = tmpNumbersArrayOxygen;
                }

                if (tmpCO2ValuesTable.Length > 1)
                {
                    int columnValueCounterCO2 = countValueInTableColumn(tmpCO2ValuesTable, counterIndex);
                    int lookedValueCO2 = checkValue(columnValueCounterCO2, tmpCO2ValuesTable.Length, false);

                    for (int tableIndex = 0; tableIndex < tmpCO2ValuesTable.Length; tableIndex++)
                    {
                        string tmpCharValue = tmpCO2ValuesTable[tableIndex][counterIndex].ToString();
                        if (Int32.Parse(tmpCharValue) == lookedValueCO2) co2ToKeep.Add(tmpCO2ValuesTable[tableIndex]);
                    }

                    string[] tmpNumbersArrayCO2 = new string[co2ToKeep.Count()];
                    int numbersArrayIndex = 0;
                    foreach (string element in co2ToKeep)
                    {
                        tmpNumbersArrayCO2[numbersArrayIndex] = element;
                        numbersArrayIndex++;
                    }
                    co2ToKeep.Clear();
                    tmpCO2ValuesTable = tmpNumbersArrayCO2;

                }

                if (tmpOxygenValuesTable.Length == 1 && tmpCO2ValuesTable.Length == 1) break;
            }

            ratingOxygenGenerator = Convert.ToInt32(string.Join("", tmpOxygenValuesTable), 2);
            ratingCo2Scruber = Convert.ToInt32(string.Join("", tmpCO2ValuesTable), 2);
            return ratingOxygenGenerator * ratingCo2Scruber;
        }

        private static int[] countValueInTableColumns(string[] valuesTable)
        {
            int[] counter = new int[valuesTable[0].Length];
            for (int elementIndex = 0; elementIndex < valuesTable.Length; elementIndex++)
            {
                for (int charIndex = 0; charIndex < valuesTable[elementIndex].Length; charIndex++)
                {
                    string tmpChar = valuesTable[elementIndex][charIndex].ToString();
                    counter[charIndex] += Int32.Parse(tmpChar);
                }

            }
            return counter;
        }

        private static int countValueInTableColumn(string[] valuesTable, int charIndex)
        {
            int counter = 0;
            for (int elementIndex = 0; elementIndex < valuesTable.Length; elementIndex++)
            {
                if (!string.IsNullOrEmpty(valuesTable[elementIndex]))
                {
                    string tmpChar = valuesTable[elementIndex][charIndex].ToString();
                    counter += Int32.Parse(tmpChar);
                }

            }
            return counter;
        }

        private static void fillGammaElipsonValue(ref int[] gamma, ref int[] epsilon, int[] columnValueCounter, int maxValue)
        {
            for (int index = 0; index < columnValueCounter.Length; index++)
            {
                if (columnValueCounter[index] > maxValue / 2)
                {
                    gamma[index] = 1;
                    epsilon[index] = 0;
                }
                else
                {
                    gamma[index] = 0;
                    epsilon[index] = 1;
                }
            }
        }

        private static int checkValue(int columnValueCounter, int maxValue, bool oxygen)
        {
            if (2* columnValueCounter >= maxValue)
            {
                if (oxygen == true) return 1;
                else return 0;
            }
            else
            {
                if (oxygen == true) return 0;
                else return 1;
            }
        }
    }
}
