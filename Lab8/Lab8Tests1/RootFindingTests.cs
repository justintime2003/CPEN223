//Student Name: Justin The
//Student Number: 48875413

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Tests
{
    [TestClass()]
    public class RootFindingTests
    {
        //Put a helper method below for each of the f(x) that you have a test case on
        //Each of these helper methods must take one parameter (type double) and must have a double return type
        double TestFunction1(double x) //a quadratic equation
        {
            return x * x + (-3) * x + 2;
        }
        double TestFunction2(double x) //the cos(x) - x^3 equation
        {
            return Math.Cos(x) - x * x * x;
        }
        double TestFunction3(double x)
        {
            return x * x - 9;
        }
        double TestFunction4(double x)
        {
            return Math.Sin(x);
        }

        [TestMethod()]
        public void BisectionTest1()
        {
            double epsilon = 0.0001;
            double a = 0.5;
            double b = 1.5;
            double result = RootFinding.Bisection(TestFunction1, a, b, epsilon);
            Assert.AreEqual(1, result, epsilon);
        }
        [TestMethod()]
        public void BisectionTest2()
        {
            double epsilon = 0.0001;
            double a = 0.5;
            double b = 1.5;
            double result = RootFinding.Bisection(TestFunction2, a, b, epsilon);
            Assert.AreEqual(0.8654, result, epsilon);
        }
        [TestMethod()]
        public void BisectionTest3()
        {
            double epsilon = 0.0001;
            double a = 1;
            double b = 4;
            double result = RootFinding.Bisection(TestFunction3, a, b, epsilon);
            Assert.AreEqual(3, result, epsilon);
        }
        [TestMethod()]
        public void BisectionTest4()
        {
            double epsilon = 0.0001;
            double a = 2;
            double b = 5;
            double result = RootFinding.Bisection(TestFunction4, a, b, epsilon);
            Assert.AreEqual(3.1415, result, epsilon);
        }
        [TestMethod()]
        public void SecantTest1()
        {
            double epsilon = 0.0001;
            double a = 0.5;
            double b = 1.5;
            double result = RootFinding.Secant(TestFunction1, a, b, epsilon);
            Assert.AreEqual(1, result, epsilon);
        }
        [TestMethod()]
        public void SecantTest2()
        {
            double epsilon = 0.0001;
            double a = 0.5;
            double b = 1.5;
            double result = RootFinding.Secant(TestFunction2, a, b, epsilon);
            Assert.AreEqual(0.8654, result, epsilon);
        }
        [TestMethod()]
        public void SecantTest3()
        {
            double epsilon = 0.0001;
            double a = 1;
            double b = 4;
            double result = RootFinding.Secant(TestFunction3, a, b, epsilon);
            Assert.AreEqual(3, result, epsilon);
        }
        [TestMethod()]
        public void SecantTest4()
        {
            double epsilon = 0.0001;
            double a = 2;
            double b = 5;
            double result = RootFinding.Secant(TestFunction4, a, b, epsilon);
            Assert.AreEqual(3.1416, result, epsilon);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BisectionExceptionTest1()
        {
            RootFinding.Bisection(TestFunction2, 0.8, 0.85, 0.0001);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BisectionExceptionTest2()
        {
            RootFinding.Bisection(TestFunction2, 0.9, 0.85, -0.0001);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SecantExceptionTest1()
        {
            RootFinding.Bisection(TestFunction2, 0.8, 0.85, 0.0001);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SecantExceptionTest2()
        {
            RootFinding.Bisection(TestFunction2, 0.9, 0.85, -0.0001);
        }
    }
}