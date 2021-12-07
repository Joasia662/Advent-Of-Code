using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class DayTwo
    {
        public static int getSubmarinePosition(string[] valuesTable, string variant)
        {

            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            for (int index = 0; index < valuesTable.Length; index++)
            {
                if (!String.IsNullOrEmpty(valuesTable[index]))
                {
                    string[] fullValue = valuesTable[index].Split(' ');

                    string direction = fullValue[0];
                    int shiftValue = Int32.Parse(fullValue[1]);
                    calculateNewPositon(ref horizontal, ref depth, ref aim, direction, shiftValue, variant);
                }
            }
            return horizontal * depth;
        }

        private static void calculateNewPositon(ref int horizontal, ref int depth, ref int aim, string changedPositionDirection, int changedShiftValue, string variant)
        {
            switch (changedPositionDirection)
            {
                case "forward":
                    horizontal += changedShiftValue;
                    if (variant == "part2") depth += aim * changedShiftValue;
                    break;
                case "down":
                    if (variant == "part2") aim += changedShiftValue;
                    else depth += changedShiftValue;
                    break;
                case "up":
                    if (variant == "part2") aim -= changedShiftValue;
                    else depth -= changedShiftValue;
                    break;
                default:
                    Console.WriteLine("The direction is not recognizable");
                    break;
            }
        }
    }
}
