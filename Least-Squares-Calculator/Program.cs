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

            //calculate relevant LSF constants
            int n = ind.Count;
            var indSummation = Summation(ind);
            var deSummation = Summation(de);
            var uncertainSumPow = SummationPowered(uncertain);
            var indSumPower = SummationPowered(ind);
            var crossSum = SummationMulti(ind, de);

            var lssResult = CalculateLeastSquaresFit(n, indSummation, deSummation, indSumPower, crossSum, uncertainSumPow);

            //now construct the equation-strings for returning∑




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

        static double SummationPowered(IEnumerable<double> li){
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

        static LSFResults CalculateLeastSquaresFit(int n, double indSummation, double deSummation, double indSumPow, double crossSum, double uncertSumPow){
            var retStruct = new LSFResults();
            retStruct.Slope = (n * crossSum - indSummation * deSummation) / (n * indSumPow - Math.Pow(indSummation, 2));
            retStruct.YIntercept = (indSumPow * deSummation - indSummation * crossSum) / (n * indSumPow - Math.Pow(indSummation, 2));

            retStruct.Sy = Math.Sqrt(uncertSumPow / (n - 2));
            retStruct.Sb = retStruct.Sy * Math.Sqrt(indSumPow / (n * indSumPow - Math.Pow(indSummation, 2)));
            retStruct.Sm = retStruct.Sy * Math.Sqrt(n / (n * indSumPow - Math.Pow(indSummation, 2)));
            return retStruct;
        }

        static LSFStrings GenerateLSFEquationStrings(int n, IList<double> ind, IList<double> de, IEnumerable<double> uncertain){
            var retStruct = new LSFStrings();
            retStruct.IndSum = "∑x=";
            retStruct.DeSum = "∑y=";
            retStruct.CrossSum = "∑xy=";
            retStruct.IndPowerSum = "∑x^2=";
            retStruct.UncertPowerSum = "∑δy^2=";

            foreach (var d in ind) {
                retStruct.IndSum += (d + "+");
            }
            retStruct.IndSum = retStruct.IndSum.Remove(retStruct.IndSum.Count() - 1);

            foreach (var d in de) {
                retStruct.DeSum += (d + "+");
            }
            retStruct.DeSum = retStruct.DeSum.Remove(retStruct.DeSum.Count() - 1);

            for (int i = 0; i < n; i++) {
                retStruct.CrossSum += ind[i].ToString() + "*" + de[i].ToString() + "+";
            }
            retStruct.CrossSum = retStruct.CrossSum.Remove(retStruct.CrossSum.Count() - 1);

            foreach (var d in ind) {
                retStruct.IndPowerSum += (d + "^2+");
            }
            retStruct.IndPowerSum = retStruct.IndPowerSum.Remove(retStruct.IndPowerSum.Count() - 1);

            foreach (var d in uncertain) {
                retStruct.UncertPowerSum += (d + "^2+");
            }
            retStruct.UncertPowerSum = retStruct.UncertPowerSum.Remove(retStruct.UncertPowerSum.Count() - 1);
            return retStruct;
        }

        struct LSFResults{
            public double Sy;
            public double Sm;
            public double Sb;
            public double Slope;
            public double YIntercept;
        }

        struct LSFStrings{
            public string IndSum;
            public string DeSum;
            public string CrossSum;
            public string IndPowerSum;
            public string UncertPowerSum;
        }
    }
}
