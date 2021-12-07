using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code
{
    class DayFour
    {
        public static int[,,] createArrayOfMatrixs(string[] valuesTable, int arraySize)
        {
            int[,,] matrices = new int[arraySize, 5, 5];

            int lineToIgnoreCount = 2;
            for (int matrixIndex = 0; matrixIndex < arraySize; matrixIndex++)
            {
                for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                {
                    List<string> row = createMatrixRow(valuesTable[matrixIndex * 5 + rowIndex + lineToIgnoreCount]);
                    int columnIndex = 0;
                    foreach (string rowElement in row)
                    {
                        matrices[matrixIndex, rowIndex, columnIndex] = Int32.Parse(rowElement);
                        columnIndex++;
                    }
                }

                lineToIgnoreCount++;
            }

            return matrices;
        }

        public static int[] convertPickedNumber(string pickedNumbers)
        {
            string[] pickedNumbersArray = pickedNumbers.Split(',');
            int[] convertedArray = new int[pickedNumbersArray.Length];
            for (int index = 0; index < pickedNumbersArray.Length; index++)
            {
                convertedArray[index] = Int32.Parse(pickedNumbersArray[index]);
            }
            return convertedArray;
        }

        public static int countFirstBingoMultiple(int[,,] matrices, int[] pickedNumbers, Boolean firstPart)
        {
            int minPickedNumbersTillBingo = 0;
            int maxPickedNumbersTillBingo = 0;
            int minSum = 0;
            int maxSum = 0;
            int lastDrawMinNumber = 0;
            int lastDrawMaxNumber = 0;
            for (int matrixIndex = 0; matrixIndex < matrices.Length / 25; matrixIndex++)
            {
                int[,,] checkArray = (int[,,])matrices.Clone();
                int currentPickedNumbersCount = 0;
                foreach (int pickedNumber in pickedNumbers)
                {
                    currentPickedNumbersCount++;
                    for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                        {
                            if (matrices[matrixIndex, rowIndex, columnIndex] == pickedNumber) checkArray[matrixIndex, rowIndex, columnIndex] = -1;
                        }
                    }
                    //int[] bingoRow = this.checkBingo(checkArray, matrixIndex, matrices);
                    int bingoSum = checkBingoSum(checkArray, matrixIndex);
                    if(bingoSum != 0)
                    {
                        if (currentPickedNumbersCount < minPickedNumbersTillBingo || minPickedNumbersTillBingo == 0) 
                        {
                            minPickedNumbersTillBingo = currentPickedNumbersCount;
                            lastDrawMinNumber = pickedNumber;
                            minSum = bingoSum;
                        }

                        if (currentPickedNumbersCount > maxPickedNumbersTillBingo || maxPickedNumbersTillBingo == 0)
                        {
                            maxPickedNumbersTillBingo = currentPickedNumbersCount;
                            lastDrawMaxNumber = pickedNumber;
                            maxSum = bingoSum;
                        }

                        break;
                    }
                  
                   

                }
            }
            if (firstPart) return lastDrawMinNumber * minSum;
            else return lastDrawMaxNumber * maxSum;
        }

        private static List<string>  createMatrixRow(string rowValue)
        {
            char[] rowArray = rowValue.ToCharArray();
            var rowList = new List<string> { };
            for (int index = 0; index < rowArray.Length; index += 3)
            {
                rowList.Add(rowArray[index].ToString() + rowArray[index + 1].ToString());
            }
            return rowList;
        }

        private static int checkBingoSum(int[,,] checkArray, int matrixIndex)
        {
            int[,] rowBingoCount = new int[5, 1];
            int[,] columnBingoCount = new int[5, 1];

            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    if (checkArray[matrixIndex, rowIndex, columnIndex] == -1)
                    {
                        rowBingoCount[rowIndex, 0]++;
                        columnBingoCount[columnIndex, 0]++;
                        if (rowBingoCount[rowIndex, 0] == 5 || columnBingoCount[columnIndex, 0] == 5)
                        {
                            return calculateSum(checkArray, matrixIndex);
                        }


                    }
                }
            }
            return 0;
        }

        private static int calculateSum(int[,,] checkArray, int matrixIndex)
        {
            int calculateSum = 0;
            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    if (checkArray[matrixIndex, rowIndex, columnIndex] != -1)
                    {
                        calculateSum += checkArray[matrixIndex, rowIndex, columnIndex];
                    }
                }
            }
            return calculateSum;
        }

        private static int[] checkBingo(int[,,] checkArray, int matrixIndex, int[,,] matrices)
        {
            int[,] rowBingoCount = new int[5, 1];
            int[,] columnBingoCount = new int[5, 1];

            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    if (checkArray[matrixIndex, rowIndex, columnIndex] == -1)
                    {
                        rowBingoCount[rowIndex, 0]++;
                        columnBingoCount[columnIndex, 0]++;
                        if (rowBingoCount[rowIndex, 0] == 5) return getBingoMultiplyRow(matrixIndex, rowIndex, matrices);
                        if (columnBingoCount[columnIndex, 0] == 5) return getBingoMultiplyColumn(matrixIndex, columnIndex, matrices);

                    }
                }
            }
            return null;
        }

        private static int[] getBingoMultiplyRow(int matrixIndex, int rowIndex, int[,,] matrices)
        {
            int[] tmpRow = new int[5];
            for (int index = 0; index < 5; index++)
            {
                tmpRow[index] = matrices[matrixIndex, rowIndex, index];
            }
            return tmpRow;
        }

        private static int[] getBingoMultiplyColumn(int matrixIndex, int columnIndex, int[,,] matrices)
        {
            int[] tmpRow = new int[5];
            for (int index = 0; index < 5; index++)
            {
                tmpRow[index] = matrices[matrixIndex, index, columnIndex];
            }
            return tmpRow;
        }
        
    }
}
