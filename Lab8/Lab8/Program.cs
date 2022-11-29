//Student name: Justin The
//Student number: 48875413

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab8
{
    public class Program
    {

        static void Main()
        {
            //You could mainly use unit tests for testing.       
        }

    }
    public class RootFinding
    {
        // Delegate for any function whose root we want to find
        public delegate double Function(double x);

        /// <summary>
        /// Finds a root of f() using the Bisection method.
        /// The cap for the # of attempted iterations is 300.
        /// </summary>
        /// <param name="f">A delegate representing the function f to find the root of.</param>
        /// <param name="a">Left side of (a, b) that brackets a root.</param>
        /// <param name="b">Right side of (a, b) that brackets a root. b is greater than a. </param>
        /// <param name="epsilon">The desired accuracy.</param>
        /// <returns>Returns the calculated root. If a root cannot be found, double.NaN is returned.</returns>
        /// <exception cref="ArgumentException">
        /// thrown if f(a)*f(b) is positive or 
        ///           epsilon is less than or equal to 0. 
        /// </exception>
        public static double Bisection(Function f, double a, double b, double epsilon)
        {
            int maxIterations = 300; 
            //if( f(a)*f(b) > 0) 
            //{
            //    throw new ArgumentException("Interval must be of opposite signs");
            //}
            //if(epsilon <= 0)
            //{
            //    throw new ArgumentException("Epsilon must be more than 0");
            //}
            if( f(a)*f(b) > 0|| epsilon <= 0)
            {
                throw new ArgumentException(); 
            }

            for (int n = 0; n < maxIterations; n++)
            {
                double c = (a + b) / 2; 
                if( f(c) == 0 || (b - a)/2 < epsilon) //return when found solution
                {
                    return c; 
                }

                if ((f(c) < 0 && f(a) < 0) || (f(c) > 0 && f(a)> 0)){ //if c and a have the same sign
                    a = c; 
                }
                else
                {
                    b = c;
                }
            }
            return double.NaN; 

        }

        /// <summary>
        /// Finds a root of f() using the Secant method.
        /// </summary>
        /// <param name="f">A delegate representing the function f to find the root of.</param>
        /// <param name="x0">Initial guess x0.</param>
        /// <param name="x1">Initial guess x1 where x1 is greater than x0. </param>
        /// <param name="epsilon">The desired accuracy.</param>
        /// <returns>Returns the calculated root. </returns>
        /// <exception cref="ArgumentException">
        /// thrown if x1 is not greater than x0 or 
        ///        epsilon is less than or equal 0.
        /// </exception>
        public static double Secant(Function f, double x0, double x1, double epsilon)
        {
            //if(x1 <= x0) 
            //{
            //    throw new ArgumentException("x1 is not greater than x0");
            //}
            //if(epsilon <= 0)
            //{
            //    throw new ArgumentException("Epsilon must be more than 0");
            //}
            if ( x1 <= x0 || epsilon <= 0)
            {
                throw new ArgumentException(); 
            }

            while(true)
            {
                double x2 = x1 - (x1 - x0) * f(x1) / (f(x1) - f(x0)); 
                if(Math.Abs(f(x2)) > epsilon)
                {
                    x0 = x1;
                    x1 = x2; 
                }
                else
                {
                    return x2; 
                }
            }
        }
    }
}