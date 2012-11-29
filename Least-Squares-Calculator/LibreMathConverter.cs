namespace Least_Squares_Calculator{
    internal class LibreMathConverter{
        public static string EquationToLibre(string equation, int fontSize = 16){
            int pos;
            while ((pos = equation.IndexOf('/')) != -1){
                var right = ExpressionManip.SplitEquation(equation, pos, ExpressionManip.SplitType.RightSide);
                var left = ExpressionManip.SplitEquation(equation, pos, ExpressionManip.SplitType.LeftSide);

                equation = equation.Remove(left.StartIndex, right.EndIndex - left.StartIndex);
                equation = equation.Insert(left.StartIndex, "{" + left.Segment + "} over {" + right.Segment + "}");
            }

            return "size " + fontSize.ToString() + "{" + equation + "}";
        }
    }
}