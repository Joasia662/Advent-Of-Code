﻿using System;
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

                //int solution = this.firstPart(valuesTable);
                int solution = this.secondPart(valuesTable);
                this.txtResultBox.Text = solution.ToString();
            }
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtResultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSecondTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');
                int solution = this.getSubmarinePosition(valuesTable);
                this.txtResultBox.Text = solution.ToString();
            }

        }
        private int getSubmarinePosition(string[] valuesTable) {

            int horizontal=0;
            int depth = 0;
            int aim = 0;
            for (int index = 0; index < valuesTable.Length; index ++) {
                if (!String.IsNullOrEmpty(valuesTable[index])) {
                    string[] fullValue = valuesTable[index].Split(' ');

                    string direction = fullValue[0];
                    int shiftValue = Int32.Parse(fullValue[1]);
                    calculateNewPositon(ref horizontal, ref depth, ref aim, direction, shiftValue);
                }
            }
            return horizontal* depth;
        }

        private void calculateNewPositon(ref int horizontal,ref int depth, ref int aim,  string changedPositionDirection, int changedShiftValue) 
        { 
            switch (changedPositionDirection)
            {
                case "forward":
                    horizontal += changedShiftValue;
                    depth += aim * changedShiftValue;
                    break;
                case "down":
                  //  depth += changedShiftValue;
                    aim += changedShiftValue;
                    break;
                case "up":
                  //  depth -= changedShiftValue;
                    aim -= changedShiftValue;
                    break;
                default:
                    Console.WriteLine("The direction is not recognizable");
                    break;
            }
        }

        private void btnThirdTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');
                int solution = this.getPowerConsumption(valuesTable);
                this.txtResultBox.Text = solution.ToString();
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
    }
}
