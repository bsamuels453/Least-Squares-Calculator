/*
Copyright (C) 2012 Ben Samuels

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
IN THE SOFTWARE.
*/
namespace Least_Squares_Calculator {
    partial class LSFForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.DataPointTextbox = new System.Windows.Forms.TextBox();
            this.OutputFmtDrpDwn = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LibreFontsizeDrpDwn = new System.Windows.Forms.ComboBox();
            this.CalculateBut = new System.Windows.Forms.Button();
            this.ErrorText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ClearBut = new System.Windows.Forms.Button();
            this.DataEntry = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatexFontSizeDrpDwn = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Data Points";
            // 
            // DataPointTextbox
            // 
            this.DataPointTextbox.Location = new System.Drawing.Point(15, 25);
            this.DataPointTextbox.Name = "DataPointTextbox";
            this.DataPointTextbox.Size = new System.Drawing.Size(53, 20);
            this.DataPointTextbox.TabIndex = 1;
            this.DataPointTextbox.WordWrap = false;
            this.DataPointTextbox.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
            // 
            // OutputFmtDrpDwn
            // 
            this.OutputFmtDrpDwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputFmtDrpDwn.FormattingEnabled = true;
            this.OutputFmtDrpDwn.Items.AddRange(new object[] {
            "LibreOffice Math",
            "LaTeX"});
            this.OutputFmtDrpDwn.Location = new System.Drawing.Point(298, 83);
            this.OutputFmtDrpDwn.Name = "OutputFmtDrpDwn";
            this.OutputFmtDrpDwn.Size = new System.Drawing.Size(106, 21);
            this.OutputFmtDrpDwn.TabIndex = 8;
            this.OutputFmtDrpDwn.SelectedValueChanged += new System.EventHandler(this.OutputFmtDrpDwnSelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output Format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Output Font Size";
            // 
            // LibreFontsizeDrpDwn
            // 
            this.LibreFontsizeDrpDwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LibreFontsizeDrpDwn.FormattingEnabled = true;
            this.LibreFontsizeDrpDwn.Items.AddRange(new object[] {
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24"});
            this.LibreFontsizeDrpDwn.Location = new System.Drawing.Point(410, 83);
            this.LibreFontsizeDrpDwn.Name = "LibreFontsizeDrpDwn";
            this.LibreFontsizeDrpDwn.Size = new System.Drawing.Size(91, 21);
            this.LibreFontsizeDrpDwn.TabIndex = 10;
            // 
            // CalculateBut
            // 
            this.CalculateBut.Location = new System.Drawing.Point(299, 125);
            this.CalculateBut.Name = "CalculateBut";
            this.CalculateBut.Size = new System.Drawing.Size(203, 38);
            this.CalculateBut.TabIndex = 12;
            this.CalculateBut.Text = "Calculate";
            this.CalculateBut.UseVisualStyleBackColor = true;
            this.CalculateBut.Click += new System.EventHandler(this.CalculateButClick);
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorText.ForeColor = System.Drawing.Color.Red;
            this.ErrorText.Location = new System.Drawing.Point(132, 20);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(133, 24);
            this.ErrorText.TabIndex = 13;
            this.ErrorText.Text = "ERROR TEXT";
            this.ErrorText.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 259);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(354, 193);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(46, 20);
            this.button10.TabIndex = 32;
            this.button10.Text = "Copy";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(214, 194);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(134, 20);
            this.textBox10.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(211, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Uncertainty in Y Intercept";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(149, 194);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(46, 20);
            this.button11.TabIndex = 29;
            this.button11.Text = "Copy";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(9, 195);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(134, 20);
            this.textBox11.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Uncertainty in Slope";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(354, 154);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 20);
            this.button8.TabIndex = 26;
            this.button8.Text = "Copy";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(214, 155);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(134, 20);
            this.textBox8.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(211, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Y Intercept";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(149, 155);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(46, 20);
            this.button9.TabIndex = 23;
            this.button9.Text = "Copy";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(9, 156);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(134, 20);
            this.textBox9.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Sy";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(354, 115);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 20);
            this.button6.TabIndex = 20;
            this.button6.Text = "Copy";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(214, 116);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(134, 20);
            this.textBox6.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Slope";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(149, 116);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(46, 20);
            this.button7.TabIndex = 17;
            this.button7.Text = "Copy";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(9, 117);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(134, 20);
            this.textBox7.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "∑δy^2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(354, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 20);
            this.button4.TabIndex = 14;
            this.button4.Text = "Copy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(214, 74);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(134, 20);
            this.textBox4.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "∑xy";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(149, 74);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 20);
            this.button5.TabIndex = 11;
            this.button5.Text = "Copy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(9, 75);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(134, 20);
            this.textBox5.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "∑y";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(354, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 20);
            this.button3.TabIndex = 8;
            this.button3.Text = "Copy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(214, 33);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(134, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(211, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "∑x^2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(134, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "∑x";
            // 
            // ClearBut
            // 
            this.ClearBut.Location = new System.Drawing.Point(435, 169);
            this.ClearBut.Name = "ClearBut";
            this.ClearBut.Size = new System.Drawing.Size(66, 25);
            this.ClearBut.TabIndex = 16;
            this.ClearBut.Text = "Clear";
            this.ClearBut.UseVisualStyleBackColor = true;
            this.ClearBut.Click += new System.EventHandler(this.ClearButClick);
            // 
            // DataEntry
            // 
            this.DataEntry.AllowUserToAddRows = false;
            this.DataEntry.AllowUserToDeleteRows = false;
            this.DataEntry.AllowUserToResizeColumns = false;
            this.DataEntry.AllowUserToResizeRows = false;
            this.DataEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DataEntry.Location = new System.Drawing.Point(15, 68);
            this.DataEntry.MultiSelect = false;
            this.DataEntry.Name = "DataEntry";
            this.DataEntry.RowHeadersVisible = false;
            this.DataEntry.RowHeadersWidth = 35;
            this.DataEntry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataEntry.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DataEntry.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataEntry.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataEntry.ShowCellErrors = false;
            this.DataEntry.ShowCellToolTips = false;
            this.DataEntry.ShowEditingIcon = false;
            this.DataEntry.ShowRowErrors = false;
            this.DataEntry.Size = new System.Drawing.Size(274, 129);
            this.DataEntry.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X Values";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Y Values";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y Uncertainty";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 90;
            // 
            // LatexFontSizeDrpDwn
            // 
            this.LatexFontSizeDrpDwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LatexFontSizeDrpDwn.FormattingEnabled = true;
            this.LatexFontSizeDrpDwn.Items.AddRange(new object[] {
            "Tiny",
            "Script Size",
            "Footnote Size",
            "Small",
            "Normal",
            "large",
            "Large",
            "LARGE",
            "huge",
            "Huge"});
            this.LatexFontSizeDrpDwn.Location = new System.Drawing.Point(410, 83);
            this.LatexFontSizeDrpDwn.Name = "LatexFontSizeDrpDwn";
            this.LatexFontSizeDrpDwn.Size = new System.Drawing.Size(91, 21);
            this.LatexFontSizeDrpDwn.TabIndex = 17;
            this.LatexFontSizeDrpDwn.Visible = false;
            // 
            // LSFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(531, 489);
            this.Controls.Add(this.LatexFontSizeDrpDwn);
            this.Controls.Add(this.ClearBut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.CalculateBut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LibreFontsizeDrpDwn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutputFmtDrpDwn);
            this.Controls.Add(this.DataEntry);
            this.Controls.Add(this.DataPointTextbox);
            this.Controls.Add(this.label1);
            this.Name = "LSFForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Least Squares Fit Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DataPointTextbox;
        private System.Windows.Forms.ComboBox OutputFmtDrpDwn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LibreFontsizeDrpDwn;
        private System.Windows.Forms.Button CalculateBut;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ClearBut;
        private System.Windows.Forms.DataGridView DataEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox LatexFontSizeDrpDwn;
    }
}