namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputFileFormat = new ComboBox();
            imputDeli = new ComboBox();
            textBox1 = new TextBox();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            outputFileForamat = new ComboBox();
            outputDeli = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // inputFileFormat
            // 
            inputFileFormat.FormattingEnabled = true;
            inputFileFormat.Items.AddRange(new object[] { "EXCEL", "DELIMITER" });
            inputFileFormat.Location = new Point(30, 23);
            inputFileFormat.Name = "inputFileFormat";
            inputFileFormat.Size = new Size(121, 23);
            inputFileFormat.TabIndex = 0;
            inputFileFormat.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // imputDeli
            // 
            imputDeli.FormattingEnabled = true;
            imputDeli.Items.AddRange(new object[] { ",", "|", ";", "TAB" });
            imputDeli.Location = new Point(30, 52);
            imputDeli.Name = "imputDeli";
            imputDeli.Size = new Size(121, 23);
            imputDeli.TabIndex = 1;
            imputDeli.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(157, 81);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(374, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(30, 81);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // outputFileForamat
            // 
            outputFileForamat.FormattingEnabled = true;
            outputFileForamat.Items.AddRange(new object[] { "EXCEL", "DELI" });
            outputFileForamat.Location = new Point(587, 23);
            outputFileForamat.Name = "outputFileForamat";
            outputFileForamat.Size = new Size(121, 23);
            outputFileForamat.TabIndex = 4;
            outputFileForamat.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // outputDeli
            // 
            outputDeli.FormattingEnabled = true;
            outputDeli.Items.AddRange(new object[] { ",", "|", "TAB", ";" });
            outputDeli.Location = new Point(587, 66);
            outputDeli.Name = "outputDeli";
            outputDeli.Size = new Size(121, 23);
            outputDeli.TabIndex = 5;
            outputDeli.SelectedIndexChanged += outputDeli_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(587, 108);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(587, 148);
            button3.Name = "button3";
            button3.Size = new Size(121, 26);
            button3.TabIndex = 7;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(outputDeli);
            Controls.Add(outputFileForamat);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(imputDeli);
            Controls.Add(inputFileFormat);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox inputFileFormat;
        private ComboBox imputDeli;
        private TextBox textBox1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private ComboBox outputFileForamat;
        private ComboBox outputDeli;
        private Button button2;
        private Button button3;
    }
}
