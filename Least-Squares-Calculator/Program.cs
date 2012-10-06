using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Least_Squares_Calculator {
    class Program {
        static void Main(string[] args) {
            



        }


        static List<double> ParseFileToNumList(string filename){
            var reader = new StreamReader(filename);
            var retList = new List<double>();

            string line;
            while ((line = reader.ReadLine()) != null){
                double d;

                if (!double.TryParse(line, out d)){
                    break;
                }
                retList.Add(d);
            }
            reader.Close();

            return retList;
        }
    }
}
