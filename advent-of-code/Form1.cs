using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //open and design task requrements
                var fileContent = string.Empty;
                var filePath = string.Empty;

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        string[] valuesTable = fileContent.Split('\n');
                        int increased = 0;
                        for (int index = 0; index < valuesTable.Length-2; index++) {
                            if (Int32.Parse(valuesTable[index]) < Int32.Parse(valuesTable[index + 1])) increased++;
                        }

                        this.txtResultBox.Text = increased.ToString();

                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtResultBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
