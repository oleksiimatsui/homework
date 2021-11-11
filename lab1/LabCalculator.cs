using System;
using System.Diagnostics;

namespace ExpressionCalculation
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
    {
        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        //IdentifierExpr

        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            Cell cell = Cell.GetCell(context.GetText());
            if (cell == null) throw new ArgumentException("no cell here");
            if (cell.Parent.Value == null) throw new ArgumentException("no value here");
            Debug.WriteLine(cell.Parent.Value.ToString());
            return Convert.ToDouble(cell.Parent.Value.ToString());
        }

        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                if(right == 0)
                {
                    throw new DivideByZeroException();
                }
                return left / right;
            }
        }

        public override double VisitMaxorminExpr(LabCalculatorParser.MaxorminExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.MAX)
            {
                Debug.WriteLine("max({0} , {1})", left, right);
                if (left > right) return left;
                else return right;
            }
            else
            {
                Debug.WriteLine("min({0} , {1})", left, right);
                if (right < left) return right;
                else return left;
            }
        }

        public override double VisitModordivExpr(LabCalculatorParser.ModordivExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.MOD)
            {
                Debug.WriteLine("mod({0} , {1})", left, right);
                return left % right;
            }
            else
            {
                Debug.WriteLine("div({0} , {1})", left, right);
                return (int)(left / right);
            }
        }

        public override double VisitLessorgreaterorequalExpr(LabCalculatorParser.LessorgreaterorequalExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == LabCalculatorLexer.LESS)
            {
                Debug.WriteLine("{0} < {1}", left, right);
                return Convert.ToDouble(left < right);
            }
            else if (context.operatorToken.Type == LabCalculatorLexer.GREATER)//LabCalculatorLexer.DIVIDE
            {
                Debug.WriteLine("{0} > {1}", left, right);
                return Convert.ToDouble(left > right);
            }
            else
            {
                Debug.WriteLine("{0} == {1}", left, right);
                return Convert.ToDouble(left == right);
            }
        }

        public override double VisitNotExpr(LabCalculatorParser.NotExprContext context)
        {
            var left = WalkLeft(context);
            Debug.WriteLine("!{0}", left);

            bool expr;
            if (left == 0)
            {
                expr = false;
                return 1;
            }
            else if (left == 1)
            {
                expr = true;
                return 0;
            }
            else throw new ArgumentException("Invalid value for NOT expression: " + left);
        }

        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }

        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }
    }
}

