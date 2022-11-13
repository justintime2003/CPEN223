//Student name: Justin The
//Student number: 48875413

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Lab6.Tests
{
    [TestClass()]
    public class CalculusTests
    {
        //Put a helper method below for each of the f(x) that you have a test case on
        //Each of these helper methods must take one parameter (type double) and must have a double return type
        double TestFunction1(double x) //a linear function
        {
            return x + 2;
        }
        double TestFunction2(double x) //the cos(x) - x^3 function
        {
            return Math.Cos(x) - x * x * x;
        }
        double TestFunction3(double x)
        {
            return Math.Pow(x, 2); 
        }
        double TestFunction4(double x)
        {
            return 1 / Math.Pow(x, 2); 
        }
        double TestFunction5(double x)
        {
            return Math.Sin(x); 
        }

        [TestMethod()]
        public void DefiniteIntegralTest1()
        {
            int n = 500;
            double a = 0;
            double b = 1;

            double result = Calculus.RectangularMethod(TestFunction1, a, b, n);
            Assert.AreEqual(2.5, result, 0.01);
        }
        [TestMethod()]
        public void DefiniteIntegralTest2()
        {
            int n = 500;
            double a = 0;
            double b = 1;

            double result = Calculus.RectangularMethod(TestFunction3, a, b, n);
            Assert.AreEqual(0.333333333, result, 0.01);
        }
        [TestMethod()]
        public void DefiniteIntegralTest3()
        {
            int n = 500;
            double a = 2;
            double b = 3;

            double result = Calculus.RectangularMethod(TestFunction4, a, b, n);
            Assert.AreEqual(0.16666666666, result, 0.01);
        }
        [TestMethod()]
        public void DefiniteIntegralTest4()
        {
            int n = 500;
            double a = 0;
            double b = Math.PI / 2;

            double result = Calculus.RectangularMethod(TestFunction5, a, b, n);
            Assert.AreEqual(1, result, 1);
        }
        [TestMethod()]
        public void NumericalDifferentiationTest()
        {
            double x = 3;
            double h = 1;

           double result = Calculus.CentralDifferenceDerivative(TestFunction1, x, h);
            Assert.AreEqual(1, result, 0.001); 
        } 
        [TestMethod()]
        public void NumericalDifferentaitionTest2()
        {
            double x = 1;
            double h = 1;

           double result = Calculus.CentralDifferenceDerivative(TestFunction3, x, h);
            Assert.AreEqual(2, result, 0.001);
        } 
        [TestMethod()]
        public void AdaptiveIntegralTest1()
        {
            double a = 0;
            double b = 1;
            int seed = 10;
            double epsilon = 0.001; 

           double result = Calculus.AdaptiveRectangularMethod(TestFunction1, a, b, seed, epsilon);
            Assert.AreEqual(2.5, result, 0.01);
        }
        [TestMethod()]
        public void AdaptiveIntegralTest2()
        {
            double a = 0;
            double b = 1;
            int seed = 20;
            double epsilon = 0.001;  

           double result = Calculus.AdaptiveRectangularMethod(TestFunction3, a, b, seed, epsilon);
            Assert.AreEqual(0.333333, result, 0.01);
        }

       
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ExceptionTest1()
        {
            Calculus.RectangularMethod(TestFunction2, 0, 1, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ExceptionTest2()
        {
            Calculus.AdaptiveRectangularMethod(TestFunction3, 0, 1, 1, 0);
        }
    }
}