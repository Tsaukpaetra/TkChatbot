using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for FunctionTests
    /// Tests with various functions
    /// </summary>
    [TestClass]
    public class StaticFunctionTests
    {
        
        [TestMethod]
        public void TestCosFunction()
        {
            double answer = Expression.Eval<double>("Cos(Pi)");
            Assert.AreEqual(answer, Math.Cos(Math.PI));
        }

        [TestMethod]
        public void TestLnFunction()
        {
            double answer = Expression.Eval<double>("Ln(E^2)");
            Assert.AreEqual(answer, Math.Log(Math.E * Math.E));
        }

        [TestMethod]
        public void TestLog10Function()
        {
            double answer = Expression.Eval<double>("Log(E^2)");
            Assert.AreEqual(answer, Math.Log10(Math.E * Math.E));
        }

        [TestMethod]
        public void TestLog42Function()
        {
            double answer = Expression.Eval<double>("Log(E^2; 42)");
            Assert.AreEqual(answer, Math.Log(Math.E * Math.E, 42));
        }

        [TestMethod]
        public void TestPowersFunction()
        {
            Assert.IsTrue(Expression.Eval<bool>("Pow(5+4*(9-1);(5+2)) = (5+4*(9-1))^(5+2)"));
        }

        [TestMethod]
        public void TestMaxFunction()
        {
            double answer = Expression.Eval<double>("Max(5;6;1;6;4;9;3;42;2;5;1;0;4)");
            Assert.AreEqual(answer, 42);
        }

        [TestMethod]
        public void TestMinFunction()
        {
            double answer = Expression.Eval<double>("Min(5;6/3.2;1;6;4*9.12;3;-42.1;2;5;1;0;4)");
            Assert.AreEqual(answer, -42.1);
        }

        [TestMethod]
        public void TestAvgFunction()
        {
            double answer = Expression.Eval<double>("AVG(5;6/3.2;1;6;4*9.12;3;-42.1;2;5;1;0;4)");
            Assert.AreEqual(answer, 23.255 /12, 0.0000001 );
        }

        [TestMethod]
        public void TestClearFunction()
        {
            object answer = Expression.Eval("Clear()");
            Assert.AreEqual(answer, null);
        }

        [TestMethod]
        public void TestHelpFunction()
        {
            string answer = Expression.Eval<string>("Help()");
            Assert.IsTrue(answer.Length > 250);
        }

        [TestMethod]
        public void TestMedianFunction()
        {
            double answer = Expression.Eval<double>("Median(5;6/3.2;+1;6;4*9.12;3;-42.1;2;5;1;0;4)");
            Assert.AreEqual(answer,2.5);

            answer = Expression.Eval<double>("Median(5;6/3.2;1;6;4*9.12;3;-42.1;2;5;0;4)");
            Assert.AreEqual(answer, 3.0);
        }

        [TestMethod]
        public void TestVarFunction()
        {
            double answer = Expression.Eval<double>("var(5;6/3.2;1;6;4*9.12;3;-42.1;2;5;1;0;4)");
            Assert.AreEqual(answer, 288.968161174242, 0.0000001);
        }

        [TestMethod]
        public void TestStDevFunction()
        {
            double answer = Expression.Eval<double>("stdev(5;6/3.2;1;6;4*9.12;3;-42.1;2;5;1;0;4)");
            Assert.AreEqual(answer, 16.9990635381553, 0.0000001);
        }

        [TestMethod]
        public void TestIfFunction()
        {
            double answer = Expression.Eval<double>("IF(1 < 5;42;24)");
            Assert.AreEqual(answer, 42);

            answer = Expression.Eval<double>("IF(1 > 5;42;24)");
            Assert.AreEqual(answer, 24);
        }

        [TestMethod]
        public void TestCaseFunction()
        {
            string answer = Expression.Eval<string>("lOWEr(\"FuBaR\")");
            Assert.AreEqual(answer, "fubar");

            answer = Expression.Eval<string>("UPPER(\"FuBaR\")");
            Assert.AreEqual(answer, "FUBAR");
        }
    }
}
