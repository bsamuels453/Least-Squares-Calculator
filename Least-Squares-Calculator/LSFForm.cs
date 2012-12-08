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
#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Least_Squares_Calculator{
    public partial class LSFForm : Form{
        public LSFForm(){
            InitializeComponent();
            OutputFmtDrpDwn.SelectedItem = "LibreOffice Math";
            LibreFontsizeDrpDwn.SelectedItem = "16";
            LatexFontSizeDrpDwn.SelectedItem = "Normal";
            DataPointTextbox.Text = 1.ToString();
        }

        #region input handling

        void TextBox1TextChanged(object sender, EventArgs e){
            int n;
            if (!int.TryParse(DataPointTextbox.Text, out n)){
                SetErrorText("Invalid value for number of samples");
            }
            else{
                SetErrorText("");
            }
            DataEntry.RowCount = n;
        }

        void OutputFmtDrpDwnSelectedValueChanged(object sender, EventArgs e){
            if (OutputFmtDrpDwn.SelectedItem.ToString() == "LibreOffice Math"){
                LatexFontSizeDrpDwn.Visible = false;
                LibreFontsizeDrpDwn.Visible = true;
            }
            if (OutputFmtDrpDwn.SelectedItem.ToString() == "LaTeX"){
                LatexFontSizeDrpDwn.Visible = true;
                LibreFontsizeDrpDwn.Visible = false;
            }
        }

        void CalculateButClick(object sender, EventArgs e){
            string str;
            if (IsVariableTableValid(out str)){
                SetErrorText(str);
                LeastSquaresFit.LSFInput input;
                input.XValues = new List<double>();
                input.YValues = new List<double>();
                input.YUncertainties = new List<double>();


                for (int i = 0; i < DataEntry.RowCount; i++){
                    input.XValues.Add(double.Parse(DataEntry[0, i].Value.ToString()));
                    input.YValues.Add(double.Parse(DataEntry[1, i].Value.ToString()));
                    input.YUncertainties.Add(double.Parse(DataEntry[2, i].Value.ToString()));
                }

                var results = LeastSquaresFit.Calculate(input);
                if (OutputFmtDrpDwn.SelectedItem.ToString() == "LibreOffice Math"){
                    LibreConvert(ref results, int.Parse(LibreFontsizeDrpDwn.SelectedItem.ToString()));
                }
                if (OutputFmtDrpDwn.SelectedItem.ToString() == "LaTeX"){
                    LatexConvert(ref results, LatexFontSizeDrpDwn.SelectedItem.ToString());
                }
                textBox2.Text = results.IndSum;
                textBox3.Text = results.IndPowerSum;
                textBox5.Text = results.DeSum;
                textBox4.Text = results.CrossSum;
                textBox7.Text = results.UncertPowerSum;
                textBox6.Text = results.SlopeEquation;
                textBox9.Text = results.YUncertEquation;
                textBox8.Text = results.InterceptEquation;
                textBox11.Text = results.SlopeUncertEquation;
                textBox10.Text = results.InterceptUncertEquation;
            }
            else{
                SetErrorText(str);
            }
        }

        #region copy stuff

        void Button2Click(object sender, EventArgs e){
            Clipboard.SetText(textBox2.Text);
        }

        void Button3Click(object sender, EventArgs e){
            Clipboard.SetText(textBox3.Text);
        }

        void Button5Click(object sender, EventArgs e){
            Clipboard.SetText(textBox5.Text);
        }

        void Button4Click(object sender, EventArgs e){
            Clipboard.SetText(textBox4.Text);
        }

        void Button7Click(object sender, EventArgs e){
            Clipboard.SetText(textBox7.Text);
        }

        void Button6Click(object sender, EventArgs e){
            Clipboard.SetText(textBox6.Text);
        }

        void Button9Click(object sender, EventArgs e){
            Clipboard.SetText(textBox9.Text);
        }

        void Button8Click(object sender, EventArgs e){
            Clipboard.SetText(textBox8.Text);
        }

        void Button11Click(object sender, EventArgs e){
            Clipboard.SetText(textBox11.Text);
        }

        void Button10Click(object sender, EventArgs e){
            Clipboard.SetText(textBox10.Text);
        }

        #endregion

        #endregion

        void SetErrorText(string str){
            ErrorText.Visible = true;
            ErrorText.Text = str;
        }

        bool IsVariableTableValid(out string retText){
            int numNullRows = 0;
            for (int row = 0; row < DataEntry.RowCount; row++){
                //check for empty cells
                //skip empty rows
                if (DataEntry[0, row].Value == null && DataEntry[1, row].Value == null && DataEntry[2, row].Value == null){
                    numNullRows++;
                    continue;
                }

                //if at least one column has text in it in the row and the others dont, then incomplete
                if (DataEntry[0, row].Value != null || DataEntry[1, row].Value != null || DataEntry[2, row].Value != null){
                    if (DataEntry[0, row].Value == null || DataEntry[1, row].Value == null || DataEntry[2, row].Value == null){
                        retText = "ERROR: Row " + row + " Variable data incomplete";
                        return false;
                    }
                }

                //scientific notation
                for (int col = 0; col < DataEntry.ColumnCount; col++){
                    string text = (string) (DataEntry[col, row].Value);
                    text = text.Replace("*10^", "E");

                    double _;
                    if (!double.TryParse(text, out _)){
                        retText = "ERROR: Row " + row + "'s value needs to be a number.";
                        return false;
                    }
                }
            }

            if (numNullRows > 0){
                retText = "ERROR: No variable data entered";
                return false;
            }

            retText = "";
            return true;
        }

        //eventually it would be nice  to hide this crap behind an interface
        static void LatexConvert(ref LeastSquaresFit.LSFStrings data, string fontSize){
            data.IndSum = LatexConverter.ToLatex(data.IndSum, fontSize);
            data.IndPowerSum = LatexConverter.ToLatex(data.IndPowerSum, fontSize);
            data.DeSum = LatexConverter.ToLatex(data.DeSum, fontSize);
            data.CrossSum = LatexConverter.ToLatex(data.CrossSum, fontSize);
            data.UncertPowerSum = LatexConverter.ToLatex(data.UncertPowerSum, fontSize);
            data.SlopeEquation = LatexConverter.ToLatex(data.SlopeEquation, fontSize);
            data.InterceptEquation = LatexConverter.ToLatex(data.InterceptEquation, fontSize);
            data.YUncertEquation = LatexConverter.ToLatex(data.YUncertEquation, fontSize);
            data.InterceptUncertEquation = LatexConverter.ToLatex(data.InterceptUncertEquation, fontSize);
            data.SlopeUncertEquation = LatexConverter.ToLatex(data.SlopeUncertEquation, fontSize);
        }

        static void LibreConvert(ref LeastSquaresFit.LSFStrings data, int fontSize){
            data.IndSum = LibreMathConverter.EquationToLibre(data.IndSum, fontSize);
            data.IndPowerSum = LibreMathConverter.EquationToLibre(data.IndPowerSum, fontSize);
            data.DeSum = LibreMathConverter.EquationToLibre(data.DeSum, fontSize);
            data.CrossSum = LibreMathConverter.EquationToLibre(data.CrossSum, fontSize);
            data.UncertPowerSum = LibreMathConverter.EquationToLibre(data.UncertPowerSum, fontSize);
            data.SlopeEquation = LibreMathConverter.EquationToLibre(data.SlopeEquation, fontSize);
            data.InterceptEquation = LibreMathConverter.EquationToLibre(data.InterceptEquation, fontSize);
            data.YUncertEquation = LibreMathConverter.EquationToLibre(data.YUncertEquation, fontSize);
            data.InterceptUncertEquation = LibreMathConverter.EquationToLibre(data.InterceptUncertEquation, fontSize);
            data.SlopeUncertEquation = LibreMathConverter.EquationToLibre(data.SlopeUncertEquation, fontSize);
        }

        void ClearButClick(object sender, EventArgs e){
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            DataPointTextbox.Text = 0.ToString();
        }
    }
}