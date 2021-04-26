using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad2
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TrueFalse()
        {
            var expr = new False();
            Assert.AreEqual(false, expr.Interpret(null));
            var expr2 = new True();
            Assert.AreEqual(true, expr2.Interpret(null));
            var expr3 = new Variable("x");
            var ctx = new Context();
            ctx.SetValue("x", true);
            Assert.AreEqual(true, expr3.Interpret(ctx));
        }

        [TestMethod]
        public void NullContext()
        {
            var expr = new Variable("x");
            Assert.ThrowsException<ArgumentNullException>(() => { expr.Interpret(null); });
        }

        [TestMethod]
        public void VariableNotPresentInContext()
        {
            var expr = new Variable("x");
            var ctx = new Context();
            ctx.SetValue("y", true);
            Assert.ThrowsException<ArgumentException>(() => { expr.Interpret(ctx); });
        }

        [TestMethod]
        public void Negation()
        {
            var expr = new Negation(new True());
            Assert.AreEqual(false, expr.Interpret(null));
            var expr2 = new Negation(new False());
            Assert.AreEqual(true, expr2.Interpret(null));
            var expr3 = new Negation(new Negation(new True()));
            Assert.AreEqual(true, expr3.Interpret(null));
        }

        [TestMethod]
        public void DeMorgan()
        {
            var expr1 = new Conjunction(
                new Negation(new Variable("x")),
                new Negation(new Variable("y")));
            var expr2 = new Negation(
                new Disjunction(
                    new Variable("x"),
                    new Variable("y")));
            var ctx = new Context();
            ctx.SetValue("x", true);
            ctx.SetValue("y", false);
            Assert.AreEqual(expr1.Interpret(ctx), expr2.Interpret(ctx));
            ctx.SetValue("x", false);
            ctx.SetValue("y", false);
            Assert.AreEqual(expr1.Interpret(ctx), expr2.Interpret(ctx));
            ctx.SetValue("x", true);
            ctx.SetValue("y", true);
            Assert.AreEqual(expr1.Interpret(ctx), expr2.Interpret(ctx));
        }
    }
}