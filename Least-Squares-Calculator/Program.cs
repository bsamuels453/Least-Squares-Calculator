using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Least_Squares_Calculator {
    class Program {
        static void Main(string[] args) {
            var ind = ParseFileToNumList("independents.txt");
            var de = ParseFileToNumList("dependents.txt");



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

        static double Summation(IEnumerable<double> li){
            double result = 0;
            foreach (var d in li){
                result += d;
            }
            return result;
        }

        static double SummationSquared(IEnumerable<double> li){
            double result = 0;
            foreach (var d in li){
                result += d * d;
            }
            return result;
        }

        static double SummationMulti(IList<double> li1, IList<double> li2){
            double result = 0;
            for (int i = 0; i < li1.Count(); i++){
                result += li1[i] * li2[i];
            }
            return result;
        }
    }
}
