#region

using System;
using System.Windows.Forms;

#endregion

namespace Least_Squares_Calculator{
    internal class Program{
        [STAThread]
        static void Main(string[] args){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LSFForm());
        }
    }
}