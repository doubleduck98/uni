using System;
using System.Collections.Generic;

namespace zad2
{
    public class Context
    {
        private readonly Dictionary<string, bool> _vars = new Dictionary<string, bool>();

        public bool GetValue(string varName)
        {
            if (_vars.ContainsKey(varName))
            {
                return _vars[varName];
            }

            throw new ArgumentException("variable name not present in context");
        }

        public void SetValue(string varName, bool value)
        {
            _vars[varName] = value;
        }
    }

    public abstract class AbstractExpression
    {
        public abstract bool Interpret(Context context);
    }

    public abstract class ConstExpression : AbstractExpression
    {
    }

    public class True : ConstExpression
    {
        public override bool Interpret(Context context)
        {
            return true;
        }
    }

    public class False : ConstExpression
    {
        public override bool Interpret(Context context)
        {
            return false;
        }
    }

    public class Variable : AbstractExpression
    {
        private readonly string _varName;

        public Variable(string varName)
        {
            _varName = varName;
        }

        public override bool Interpret(Context context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "context can not be null");
            }

            return context.GetValue(_varName);
        }
    }

    public abstract class UnaryExpression : AbstractExpression
    {
        protected AbstractExpression _expr;

        protected UnaryExpression(AbstractExpression expression)
        {
            _expr = expression;
        }
    }

    public class Negation : UnaryExpression
    {
        public Negation(AbstractExpression expression) : base(expression)
        {
        }

        public override bool Interpret(Context context)
        {
            return !_expr.Interpret(context);
        }
    }

    public abstract class BinaryExpression : AbstractExpression
    {
        protected AbstractExpression _left;
        protected AbstractExpression _right;

        protected BinaryExpression(AbstractExpression left, AbstractExpression right)
        {
            _left = left;
            _right = right;
        }
    }

    public class Conjunction : BinaryExpression
    {
        public Conjunction(AbstractExpression left, AbstractExpression right) : base(left, right)
        {
        }

        public override bool Interpret(Context context)
        {
            return _left.Interpret(context) && _right.Interpret(context);
        }
    }

    public class Disjunction : BinaryExpression
    {
        public Disjunction(AbstractExpression left, AbstractExpression right) : base(left, right)
        {
        }

        public override bool Interpret(Context context)
        {
            return _left.Interpret(context) || _right.Interpret(context);
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}