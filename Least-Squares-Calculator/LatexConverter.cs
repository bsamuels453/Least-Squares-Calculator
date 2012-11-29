/*
Copyright (C) 2012 zalzane

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
namespace Least_Squares_Calculator{
    internal class LatexConverter{
        public static string ToLatex(string expression, string fontSize = "Normal"){
            //convert fractions
            int pos;
            while ((pos = expression.IndexOf('/')) != -1){
                var right = ExpressionManip.SplitEquation(expression, pos, ExpressionManip.SplitType.RightSide);
                var left = ExpressionManip.SplitEquation(expression, pos, ExpressionManip.SplitType.LeftSide);

                expression = expression.Remove(left.StartIndex, right.EndIndex - left.StartIndex);
                expression = expression.Insert(left.StartIndex, "\\frac{" + left.Segment + "}{" + right.Segment + "}");
            }

            //convert math symbols
            expression = expression.Replace("ρ", @"\rho ");
            expression = expression.Replace("π", @"\pi ");
            expression = expression.Replace("Ω", @"\Omega ");
            expression = expression.Replace("δ", @"\delta ");
            expression = expression.Replace("Δ", @"\Delta ");
            expression = expression.Replace("α", @"\alpha ");
            expression = expression.Replace("μ", @"\mu ");
            expression = expression.Replace("ε", @"\epsilon ");
            expression = expression.Replace("θ", @"\theta ");
            expression = expression.Replace("κ", @"\kappa ");
            expression = expression.Replace("σ", @"\sigma ");
            expression = expression.Replace("β", @"\beta ");
            expression = expression.Replace("γ", @"\gamma ");
            expression = expression.Replace("η", @"\eta ");
            expression = expression.Replace("λ", @"\lambda ");
            expression = expression.Replace("ν", @"\nu ");
            expression = expression.Replace("ξ", @"\xi ");
            expression = expression.Replace("τ", @"\tau ");
            expression = expression.Replace("υ", @"\upsilon ");
            expression = expression.Replace("φ", @"\phi ");
            expression = expression.Replace("ψ", @"\psi ");
            expression = expression.Replace("ω", @"\omega ");

            string prefix;
            const string suffix = "}$";

            //todo: enum this
            switch (fontSize){
                case "Tiny":
                    prefix = @"${\tiny ";
                    break;
                case "Script Size":
                    prefix = @"${\scriptsize ";
                    break;
                case "Footnote Size":
                    prefix = @"${\footnotesize ";
                    break;

                case "Small":
                    prefix = @"${\small ";
                    break;

                case "Normal":
                    prefix = @"${\normalsize ";
                    break;
                case "large":
                    prefix = @"${\large ";
                    break;

                case "Large":
                    prefix = @"${\Large ";
                    break;

                case "LARGE":
                    prefix = @"${\LARGE ";
                    break;
                case "huge":
                    prefix = @"${\huge ";
                    break;
                case "Huge":
                    prefix = @"${\Huge ";
                    break;
                default:
                    prefix = "${";
                    break;
            }
            return prefix + expression + suffix;
        }
    }
}