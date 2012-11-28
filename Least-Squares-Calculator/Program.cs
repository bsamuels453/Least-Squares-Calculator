using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Least_Squares_Calculator {
    class Program {
        static void Main(string[] args) {
            var v = new LSFForm();
            Application.Run(new LSFForm());

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

            var lsfResult = CalculateLeastSquaresFit(n, indSummation, deSummation, indSumPower, crossSum, uncertainSumPow);

            //now construct the equation-strings for returning∑
            var lsfStrings = GenerateLSFEquationStrings(n, ind, de, uncertain, indSummation, deSummation, uncertainSumPow, indSumPower, crossSum, lsfResult.Sy);

            //add the constants generated to the end of the equations in question
            lsfStrings.IndSum += "=" + indSummation;
            lsfStrings.IndPowerSum += "=" + indSumPower;
            lsfStrings.DeSum += "=" + deSummation;
            lsfStrings.CrossSum += "=" + crossSum;
            lsfStrings.InterceptEquation += "=" + lsfResult.YIntercept;
            lsfStrings.InterceptUncertEquation += "=" + lsfResult.Sb;
            lsfStrings.SlopeEquation += "=" + lsfResult.Slope;
            lsfStrings.SlopeUncertEquation += "=" + lsfResult.Sm;
            lsfStrings.UncertPowerSum += "=" + uncertainSumPow;
            lsfStrings.YUncertEquation += "=" + lsfResult.Sy;

            //now write the strings to file

            var writer = new StreamWriter("results.txt", false);
            writer.WriteLine("N="+n);
            writer.WriteLine(lsfStrings.IndSum);
            writer.WriteLine(lsfStrings.IndPowerSum);
            writer.WriteLine(lsfStrings.DeSum);
            writer.WriteLine(lsfStrings.CrossSum);
            writer.WriteLine(lsfStrings.UncertPowerSum);
            writer.WriteLine(lsfStrings.SlopeEquation);
            writer.WriteLine(lsfStrings.InterceptEquation);
            writer.WriteLine(lsfStrings.YUncertEquation);
            writer.WriteLine(lsfStrings.InterceptUncertEquation);
            writer.WriteLine(lsfStrings.SlopeUncertEquation);
            writer.Close();
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

        //this probably shouldn't be its own method considering all the parameters, but it is for the sake of cleanliness of the main() method
        static LSFStrings GenerateLSFEquationStrings(int n, IList<double> ind, IList<double> de, IEnumerable<double> uncertain, double indSum, double deSum, double uncertSumPow, double indSumPow, double crossSum, double sy){
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

            //now for the second part
            retStruct.SlopeEquation = "m={"+n+"*"+crossSum+"-"+indSum+"*"+deSum+"} over {"+n+"*"+indSumPow+"-"+indSum+"^2}";
            retStruct.InterceptEquation = "b={" + indSum + "^2*" + deSum + "-" + indSum + "*" + crossSum + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}";
            retStruct.YUncertEquation = "s_y=sqrt{{" + uncertSumPow + "} over {" + n + "-2}}";
            retStruct.InterceptUncertEquation = "s_b=" + sy + "*sqrt{{" + indSumPow + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}}";
            retStruct.SlopeUncertEquation = "s_m=" + sy + "*sqrt{{" + n + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}}";

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

            public string SlopeEquation;
            public string InterceptEquation;

            public string YUncertEquation;
            public string InterceptUncertEquation;
            public string SlopeUncertEquation;
        }
    }
}
