namespace WinFormsApp2
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using Microsoft.Office.Interop.Excel;
    using ClosedXML.Excel;



    public partial class Form1 : Form
    {
        private string inputFilePath;
        private string outputFilePath;
        private System.Data.DataTable dataTable = new System.Data.DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = openFileDialog.FileName;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void outputDeli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputFileForamat.SelectedItem != null && outputFileForamat.SelectedItem.ToString() == "EXCEL")
            {
                outputDeli.Enabled = false;
            }
            else
            {

                outputDeli.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFilePath = folderDialog.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath) || string.IsNullOrEmpty(outputFilePath))
            {
                MessageBox.Show("Please select both input file and output folder.");
                return;
            }

            string inputFileType = inputFileFormat.SelectedItem?.ToString();
            string outputFileType = outputFileForamat.SelectedItem?.ToString();
            string inputDelimiter = imputDeli.SelectedItem?.ToString();
            string outputDelimiter = outputDeli.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(inputFileType) || string.IsNullOrEmpty(outputFileType))
            {
                MessageBox.Show("Please select both input and output file formats.");
                return;
            }

            try
            {
                if (inputFileType == "EXCEL")
                {
                    ReadExcelFile(inputFilePath);
                }
                else
                {
                    ReadDelimitedFile(inputFilePath, inputDelimiter);
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputFilePath) + "_converted";
                string outputFileExtension;

                switch (outputFileType)
                {
                    case "EXCEL":
                        outputFileExtension = ".xlsx";
                        break;
                    case "CSV":
                        outputFileExtension = ".csv";
                        break;
                    case "DELI":
                        outputFileExtension = ".txt";
                        break;
                    default:
                        throw new ArgumentException("Invalid output file type selected.");
                }

                string fullOutputPath = Path.Combine(outputFilePath, outputFileName + outputFileExtension);

                if (outputFileType == "Excel")
                {
                    WriteExcelFile(fullOutputPath);
                }
                else
                {
                    WriteDelimitedFile(fullOutputPath, outputDelimiter);
                }

                MessageBox.Show($"File processed successfully! Saved to: {fullOutputPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void ReadExcelFile(string filePath)   
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1); // This is the correct way to get the first worksheet in ClosedXML
                var rows = worksheet.RowsUsed();

                // Add columns
                foreach (var cell in worksheet.Row(1).CellsUsed())
                {
                    dataTable.Columns.Add(cell.Value.ToString());
                }

                // Add data
                foreach (var row in rows.Skip(1)) // Skip the header row
                {
                    DataRow dataRow = dataTable.NewRow();
                    int columnIndex = 0;
                    foreach (var cell in row.CellsUsed())
                    {
                        dataRow[columnIndex] = cell.Value.ToString();
                        columnIndex++;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
        }

        private void ReadDelimitedFile(string filePath, string delimiter)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split(delimiter);
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(delimiter);
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataRow[i] = rows[i];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
        }
        private void WriteExcelFile(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Add headers
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
                }

                // Add data
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        worksheet.Cell(row + 2, col + 1).Value = dataTable.Rows[row][col].ToString();
                    }
                }

                workbook.SaveAs(filePath);
            }
        }

        private void WriteDelimitedFile(string filePath, string delimiter)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    writer.Write(dataTable.Columns[i]);
                    if (i < dataTable.Columns.Count - 1)
                    {
                        writer.Write(delimiter);
                    }
                }
                writer.WriteLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        writer.Write(row[i]);
                        if (i < dataTable.Columns.Count - 1)
                        {
                            writer.Write(delimiter);
                        }
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}

