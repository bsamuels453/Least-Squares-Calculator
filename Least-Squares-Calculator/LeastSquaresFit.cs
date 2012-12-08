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
using System.Linq;

#endregion

namespace Least_Squares_Calculator{
    internal static class LeastSquaresFit{
        public static LSFStrings Calculate(LSFInput input){
            var ind = input.XValues;
            var de = input.YValues;
            var uncertain = input.YUncertainties;

            if (ind.Count != de.Count)
                throw new Exception("there are a different number of independent and dependent values");

            if (ind.Count != uncertain.Count)
                throw new Exception("there are a different number of values and uncertanties");

            //calculate relevant LSF constants
            int n = ind.Count;
            var indSum = Summation(ind);
            var deSum = Summation(de);
            var uncertSumPow = SummationPowered(uncertain);
            var indSumPow = SummationPowered(ind);
            var crossSum = SummationMulti(ind, de);

            var lsfResult = CalculateLeastSquaresFit(n, indSum, deSum, indSumPow, crossSum, uncertSumPow);

            #region format everything

            var retStruct = new LSFStrings();
            retStruct.IndSum = "∑x=";
            retStruct.DeSum = "∑y=";
            retStruct.CrossSum = "∑xy=";
            retStruct.IndPowerSum = "∑x^2=";
            retStruct.UncertPowerSum = "∑δy^2=";

            foreach (var d in ind){
                retStruct.IndSum += (d + "+");
            }
            retStruct.IndSum = retStruct.IndSum.Remove(retStruct.IndSum.Count() - 1);

            foreach (var d in de){
                retStruct.DeSum += (d + "+");
            }
            retStruct.DeSum = retStruct.DeSum.Remove(retStruct.DeSum.Count() - 1);

            for (int i = 0; i < n; i++){
                retStruct.CrossSum += ind[i].ToString() + "*" + de[i].ToString() + "+";
            }
            retStruct.CrossSum = retStruct.CrossSum.Remove(retStruct.CrossSum.Count() - 1);

            foreach (var d in ind){
                retStruct.IndPowerSum += (d + "^2+");
            }
            retStruct.IndPowerSum = retStruct.IndPowerSum.Remove(retStruct.IndPowerSum.Count() - 1);

            foreach (var d in uncertain){
                retStruct.UncertPowerSum += (d + "^2+");
            }
            retStruct.UncertPowerSum = retStruct.UncertPowerSum.Remove(retStruct.UncertPowerSum.Count() - 1);

            //now for the second part
            retStruct.SlopeEquation = "m={" + n + "*" + crossSum + "-" + indSum + "*" + deSum + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}";
            retStruct.InterceptEquation = "b={" + indSum + "^2*" + deSum + "-" + indSum + "*" + crossSum + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}";
            retStruct.YUncertEquation = "s_y=sqrt{{" + uncertSumPow + "} over {" + n + "-2}}";
            retStruct.InterceptUncertEquation = "s_b=" + lsfResult.Sy + "*sqrt{{" + indSumPow + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}}";
            retStruct.SlopeUncertEquation = "s_m=" + lsfResult.Sy + "*sqrt{{" + n + "} over {" + n + "*" + indSumPow + "-" + indSum + "^2}}";

            //add the constants generated to the end of the equations in question
            retStruct.IndSum += "=" + indSum;
            retStruct.IndPowerSum += "=" + indSumPow;
            retStruct.DeSum += "=" + deSum;
            retStruct.CrossSum += "=" + crossSum;
            retStruct.InterceptEquation += "=" + lsfResult.YIntercept;
            retStruct.InterceptUncertEquation += "=" + lsfResult.Sb;
            retStruct.SlopeEquation += "=" + lsfResult.Slope;
            retStruct.SlopeUncertEquation += "=" + lsfResult.Sm;
            retStruct.UncertPowerSum += "=" + uncertSumPow;
            retStruct.YUncertEquation += "=" + lsfResult.Sy;
            retStruct.NumSamples = n;

            #endregion

            return retStruct;
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
                result += d*d;
            }
            return result;
        }

        static double SummationMulti(IList<double> li1, IList<double> li2){
            double result = 0;
            for (int i = 0; i < li1.Count(); i++){
                result += li1[i]*li2[i];
            }
            return result;
        }

        static LSFResults CalculateLeastSquaresFit(int n, double indSummation, double deSummation, double indSumPow, double crossSum, double uncertSumPow){
            var retStruct = new LSFResults();
            retStruct.Slope = (n*crossSum - indSummation*deSummation)/(n*indSumPow - Math.Pow(indSummation, 2));
            retStruct.YIntercept = (indSumPow*deSummation - indSummation*crossSum)/(n*indSumPow - Math.Pow(indSummation, 2));

            retStruct.Sy = Math.Sqrt(uncertSumPow/(n - 2));
            retStruct.Sb = retStruct.Sy*Math.Sqrt(indSumPow/(n*indSumPow - Math.Pow(indSummation, 2)));
            retStruct.Sm = retStruct.Sy*Math.Sqrt(n/(n*indSumPow - Math.Pow(indSummation, 2)));
            return retStruct;
        }

        #region Nested type: LSFInput

        public struct LSFInput{
            public IList<double> XValues;
            public IList<double> YUncertainties;
            public IList<double> YValues;
        }

        #endregion

        #region Nested type: LSFResults

        struct LSFResults{
            public double Sb;
            public double Slope;
            public double Sm;
            public double Sy;
            public double YIntercept;
        }

        #endregion

        #region Nested type: LSFStrings

        public struct LSFStrings{
            public string CrossSum;
            public string DeSum;
            public string IndPowerSum;
            public string IndSum;
            public string InterceptEquation;

            public string InterceptUncertEquation;
            public int NumSamples;
            public string SlopeEquation;
            public string SlopeUncertEquation;
            public string UncertPowerSum;
            public string YUncertEquation;
        }

        #endregion
    }
}