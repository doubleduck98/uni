using System;
using System.Linq;
using System.Linq.Expressions;

namespace zad4
{
    public class PrintExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression expression)
        {
            Console.WriteLine("{0} {1} {2}",
                expression.Left, expression.NodeType, expression.Right);
            return base.VisitBinary(expression);
        }

        protected override Expression VisitLambda<T>(Expression<T> expression)
        {
            Console.WriteLine("{0} -> {1}",
                expression.Parameters.Aggregate(string.Empty, (a, e) => a + e),
                expression.Body);
            return base.VisitLambda(expression);
        }

        protected override Expression VisitConstant(ConstantExpression expression)
        {
            Console.WriteLine("constant {0} {1}", expression.Type, expression.Value);
            return base.VisitConstant(expression);
        }

        protected override Expression VisitConditional(ConditionalExpression expression)
        {
            Console.WriteLine("if {0} then {1} else {2}",
                expression.Test, expression.IfTrue, expression.IfFalse);
            return base.VisitConditional(expression);
        }

        protected override Expression VisitTry(TryExpression expression)
        {
            Console.WriteLine("try {0}", expression.Body);
            return base.VisitTry(expression);
        }

        protected override CatchBlock VisitCatchBlock(CatchBlock expression)
        {
            Console.WriteLine("catch block {0}, exception {1}", expression.Body, expression.Test);
            return base.VisitCatchBlock(expression);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<int, int>> f = n => 4 * (7 + n);
            var v = new PrintExpressionVisitor();
            v.Visit(f);

            var condition = Expression.Condition(
                Expression.Constant(true),
                Expression.Constant("true"),
                Expression.Constant("false"));
            v.Visit(condition);

            var tryCatch =
                Expression.TryCatch(
                    Expression.Constant("try block"),
                    Expression.Catch(
                        typeof(ArgumentException),
                        Expression.Constant("catch block")));
            v.Visit(tryCatch);
        }
    }
}