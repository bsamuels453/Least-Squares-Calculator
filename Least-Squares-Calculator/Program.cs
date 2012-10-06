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
            var uncertain = ParseFileToNumList("uncertainties.txt");

            if (ind.Count != de.Count)
                throw new Exception("there are a different number of independent and dependent values");

            if (ind.Count != uncertain.Count)
                throw new Exception("there are a different number of values and uncertanties");

            int n = ind.Count;

            var indSummation = Summation(ind);
            var deSummation = Summation(de);

            var uncertainSumSquare = SummationSquared(uncertain);

            var indSumSquare = SummationSquared(ind);
            var crossSum = SummationMulti(ind, de);

            var lssResult = CalculateLeastSquaresFit(n, indSummation, deSummation, indSumSquare, crossSum, uncertainSumSquare);

            int f = 5;

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

        static LSFResults CalculateLeastSquaresFit(int n, double indSummation, double deSummation, double indSumSquare, double crossSum, double uncertSumSquare){
            var retStruct = new LSFResults();
            retStruct.Slope = (n * crossSum - indSummation * deSummation) / (n * indSumSquare - Math.Pow(indSummation, 2));
            retStruct.YIntercept = (indSumSquare * deSummation - indSummation * crossSum) / (n * indSumSquare - Math.Pow(indSummation, 2));

            retStruct.Sy = Math.Sqrt(uncertSumSquare / (n - 2));
            retStruct.Sb = retStruct.Sy * Math.Sqrt(indSumSquare / (n * indSumSquare - Math.Pow(indSummation, 2)));
            retStruct.Sm = retStruct.Sy * Math.Sqrt(n / (n * indSumSquare - Math.Pow(indSummation, 2)));
            return retStruct;
        }

        struct LSFResults{
            public double Sy;
            public double Sm;
            public double Sb;
            public double Slope;
            public double YIntercept;
        }
    }
}
