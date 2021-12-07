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

        private void btnFirstTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');

                int solution1 = DayOne.calculateDepthIncreases(valuesTable);
                int solution2 = DayOne.calculateDepthIncreasesOfSums(valuesTable);
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
                int solution1 = DayTwo.getSubmarinePosition(valuesTable, "part1");
                int solution2 = DayTwo.getSubmarinePosition(valuesTable, "part2");

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
 
                int solution1 = DayThree.getPowerConsumption(valuesTable);
                this.txtResultPart1.Text = solution1.ToString();

                int solution2 = DayThree.getLifeSupportRating(valuesTable);
                this.txtResultPart2.Text = solution2.ToString();
            }
        }

        private void btnFourthTask_Click(object sender, EventArgs e)
        {
            var fileContent = this.openInputFile();
            if (fileContent != null)
            {
                string[] valuesTable = fileContent.Split('\n');
                int[] pickedNumbers = DayFour.convertPickedNumber(valuesTable[0]);
                var valueList = new List<string>(valuesTable);
                int emptyLinesCount= valueList.Where(s => s != null && s=="").Count();
                int matrixCount = emptyLinesCount - 1;

                int[,,] matrices = DayFour.createArrayOfMatrixs(valuesTable, matrixCount);
                int solution1 = DayFour.countFirstBingoMultiple(matrices, pickedNumbers);
                this.txtResultPart1.Text = solution1.ToString();
                this.txtResultPart2.Text = " ";
            }
        }
      
        private string getInputFolder()
        {
            return Directory.GetCurrentDirectory() + "\\inputs";
        }

        private string openInputFile() 
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
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

    }
}
