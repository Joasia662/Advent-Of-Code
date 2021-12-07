using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace advent_of_code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent!=null) {
                string[] valuesTable = fileContent.Split('\n');

                int solution1 = this.firstPart(valuesTable);
                int solution2 = this.secondPart(valuesTable);
                this.txtResultPart1.Text = solution1.ToString();
                this.txtResultPart2.Text = solution2.ToString();
            }
        }

        private void btnSecondTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');
                int solution1 = this.getSubmarinePosition(valuesTable, "part1");
                int solution2 = this.getSubmarinePosition(valuesTable, "part2");

                this.txtResultPart1.Text = solution1.ToString();
                this.txtResultPart2.Text = solution2.ToString();
            }
        }


        private void btnThirdTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');
 
                int solution1 = this.getPowerConsumption(valuesTable);
                this.txtResultPart1.Text = solution1.ToString();

                int solution2 = this.getLifeSupportRating(valuesTable);
                this.txtResultPart2.Text = solution2.ToString();
            }
        }

        private void btnFourthTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');
                int[] pickedNumbers = convertPickedNumber(valuesTable[0]);
                var valueList = new List<string>(valuesTable);
                int emptyLinesCount= valueList.Where(s => s != null && s=="").Count();
                int matrixCount = emptyLinesCount - 1;

                int[,,] matrices = this.createArrayOfMatrixs(valuesTable, matrixCount);
                int solution1 = this.countFirstBingoMultiple(matrices, pickedNumbers);
                this.txtResultPart1.Text = solution1.ToString();
            }
        }
        private int countFirstBingoMultiple(int[,,] matrices, int[] pickedNumbers)
        {
            int minPickedNumbersTillBingo = 0;
            int sum = 0;
            int lastDrawNumber = 0;
            for (int matrixIndex = 0; matrixIndex < matrices.Length/25; matrixIndex++)
            {
                int[,,] checkArray = (int[,,]) matrices.Clone();
                int currentPickedNumbersCount = 0;
                foreach (int pickedNumber in pickedNumbers)
                {
                    currentPickedNumbersCount++;
                    for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                        {
                            if (matrices[matrixIndex, rowIndex, columnIndex] == pickedNumber) checkArray[matrixIndex,rowIndex, columnIndex]=-1;
                        }
                    }
                    //int[] bingoRow = this.checkBingo(checkArray, matrixIndex, matrices);
                      int bingoSum = this.checkBingoSum(checkArray, matrixIndex);
                    if (bingoSum != 0 && (currentPickedNumbersCount < minPickedNumbersTillBingo || minPickedNumbersTillBingo==0))
                    {
                        minPickedNumbersTillBingo = currentPickedNumbersCount;
                        lastDrawNumber = pickedNumber;
                        sum = bingoSum;
                    }
                    
                }
            }
           
            return lastDrawNumber * sum;
        }

        int checkBingoSum(int[,,] checkArray, int matrixIndex)
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
                            return this.calculateSum(checkArray,matrixIndex); 
                        }


                    }
                }
            }
            return 0;
        }

        int calculateSum(int[,,] checkArray, int matrixIndex)
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

        int[] checkBingo(int[,,] checkArray, int matrixIndex, int[,,] matrices)
        {
            int[,] rowBingoCount=new int[5,1];
            int[,] columnBingoCount=new int[5, 1];

            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {   
                    if (checkArray[matrixIndex, rowIndex, columnIndex] == -1)
                    {
                        rowBingoCount[rowIndex, 0]++;
                        columnBingoCount[columnIndex, 0]++;
                        if (rowBingoCount[rowIndex, 0] == 5) return this.getBingoMultiplyRow(matrixIndex, rowIndex, matrices);
                        if (columnBingoCount[columnIndex, 0] == 5) return this.getBingoMultiplyColumn(matrixIndex, columnIndex, matrices);

                    }
                }
            }
            return null;
        }

        
        private int[] getBingoMultiplyRow(int matrixIndex, int rowIndex, int[,,] matrices)
        {
            int[] tmpRow = new int[5];
            for(int index =0; index < 5; index++) 
            {
                tmpRow[index] = matrices[matrixIndex, rowIndex, index];
            }
            return tmpRow;
        }

        private int[] getBingoMultiplyColumn(int matrixIndex, int columnIndex, int[,,] matrices)
        {
            int[] tmpRow = new int[5];
            for (int index = 0; index < 5; index++)
            {
                tmpRow[index] = matrices[matrixIndex, index, columnIndex];
            }
            return tmpRow;
        }
        


        private int[] convertPickedNumber(string pickedNumbers)
        {
            string[] pickedNumbersArray = pickedNumbers.Split(',');
            int[] convertedArray = new int[pickedNumbersArray.Length];
            for (int index = 0; index < pickedNumbersArray.Length; index++)
            {
                convertedArray[index] = Int32.Parse(pickedNumbersArray[index]);
            }
            return convertedArray;
        }
        
        private int[,,] createArrayOfMatrixs(string[] valuesTable,int arraySize) 
        {
            int[,,] matrices = new int[arraySize, 5, 5];

            int lineToIgnoreCount = 2;
            for (int matrixIndex = 0; matrixIndex < arraySize; matrixIndex++ )
            {
                for (int rowIndex = 0; rowIndex < 5; rowIndex++) 
                {
                    List<string> row  = this.createMatrixRow(valuesTable[matrixIndex * 5 + rowIndex + lineToIgnoreCount]); 
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

        List<string> createMatrixRow(string rowValue)
        {
            char[] rowArray = rowValue.ToCharArray();
            var rowList = new List<string> { };
            for (int index=0; index < rowArray.Length; index+=3)
            {
                rowList.Add(rowArray[index].ToString()+rowArray[index+1].ToString());
            }
            return rowList;
        }
        


        private int firstPart(string[] valuesTable)
        {
            int growCount = 0;
            for (int index = 0; index < valuesTable.Length - 2; index++)
            {
                if (Int32.Parse(valuesTable[index]) < Int32.Parse(valuesTable[index + 1])) growCount++;
            }

            return growCount;
        }
        private int secondPart(string[] valuesTable)
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
        private int[] fillSumArray(string[] valuesTable)
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

        private string getInputFolder()
        {
            return Directory.GetCurrentDirectory() + "\\inputs";
        }

        private string openInputFile() 
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //open and design task requrements
                var fileContent = string.Empty;
                var filePath = string.Empty;

                openFileDialog.InitialDirectory = this.getInputFolder();
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        return fileContent;
                    }
                }
            }
            return null;
        }

        private int getSubmarinePosition(string[] valuesTable, string variant) {

            int horizontal=0;
            int depth = 0;
            int aim = 0;
            for (int index = 0; index < valuesTable.Length; index ++) {
                if (!String.IsNullOrEmpty(valuesTable[index])) {
                    string[] fullValue = valuesTable[index].Split(' ');

                    string direction = fullValue[0];
                    int shiftValue = Int32.Parse(fullValue[1]);
                    calculateNewPositon(ref horizontal, ref depth, ref aim, direction, shiftValue, variant);
                }
            }
            return horizontal* depth;
        }

        private void calculateNewPositon(ref int horizontal,ref int depth, ref int aim,  string changedPositionDirection, int changedShiftValue,string variant) 
        { 
            switch (changedPositionDirection)
            {
                case "forward":
                    horizontal += changedShiftValue;
                    if(variant=="part2")depth += aim * changedShiftValue;
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

        private int getPowerConsumption(string[] valuesTable)
        {
            int gammaRate;
            int epsilonRate;

            int[] gamma = new int[valuesTable[0].Length];
            int[] epsilon = new int[valuesTable[0].Length];
            int[] columnValueCounter = this.countValueInTableColumns(valuesTable);

            this.fillGammaElipsonValue(ref gamma, ref epsilon, columnValueCounter, valuesTable.Length);
            gammaRate= Convert.ToInt32(string.Join("", gamma), 2);
            epsilonRate = Convert.ToInt32(string.Join("", epsilon), 2);

            return epsilonRate* gammaRate;
        }

        private int[] countValueInTableColumns(string[] valuesTable) 
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

        private int countValueInTableColumn(string[] valuesTable, int charIndex)
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

        private void fillGammaElipsonValue(ref int[] gamma, ref int[] epsilon, int[] columnValueCounter, int maxValue)
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

        private int checkValue(int columnValueCounter, int maxValue, bool oxygen)
        {
                if ( columnValueCounter >= maxValue/2)
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

        private int getLifeSupportRating(string[] valuesTable ) {
            int ratingOxygenGenerator = 0;
            int ratingCo2Scruber=0;

            List<string> oxygenToKeep= new List<string>();
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

                if (tmpOxygenValuesTable.Length == 1 && tmpCO2ValuesTable.Length==1) break;
            }
           
            ratingOxygenGenerator = Convert.ToInt32(string.Join("", tmpOxygenValuesTable), 2);
            ratingCo2Scruber = Convert.ToInt32(string.Join("", tmpCO2ValuesTable), 2);
            return ratingOxygenGenerator * ratingCo2Scruber;
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
    }
}
