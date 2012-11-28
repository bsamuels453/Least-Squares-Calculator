using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Least_Squares_Calculator {
    public partial class LSFForm : Form {
        public LSFForm() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            int n = int.Parse(textBox1.Text);
            dataGridView1.RowCount = n;
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }
    }
}
