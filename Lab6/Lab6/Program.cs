//Student name: Justin The
//Student number: 48875413

using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Lab6
{
    public class Program
    {
        static void Main()
        {
            //You could mainly use unit tests for testing.       
            
        }
    }
    public class Calculus
    {
        // Delegate for any function whose definite integral or derivative we want to calculate
        public delegate double Function(double x); //accessor

        /// <summary>
        /// Finds the definite integral of f between a and b using 
        /// the rectangular method for a given n (sub-intervals).
        /// </summary>
        /// <param name="f">A delegate representing the function f.</param>
        /// <param name="a">Lower limit of the integral.</param>
        /// <param name="b">upper limit of the integral.</param>
        /// <param name="n">The number of subintervals between a and b for the rectangular method.</param>
        /// <returns>Returns the calculated integral value.</returns>
        /// <exception cref="ArgumentException">
        /// thrown if n is not a positive number.
        /// </exception>
        public static double RectangularMethod(Function f, double a, double b, int n)
        {
            if(n <= 0)
            {
                throw new ArgumentException("n cannot be negative"); 
            }

            double deltaX = ( b - a) / n;
            double result = 0;  

            for (int i = 1; i <= n; i++)
            {
                double inputFunc = a + (i * deltaX); 
                 result += f(inputFunc) * deltaX; //riemann sum formula
            }
            return result; 
        }

        /// <summary>
        /// Finds the definite integral adaptively by starting from 
        /// a seed value for n (# of sub-intervals), until the desired
        /// accuracy is achieved.
        /// This method uses RectangularMethod() in its implementation.
        /// </summary>
        /// <param name="f">A delegate representing the function f.</param>
        /// <param name="a">Lower limit of the integral.</param>
        /// <param name="b">upper limit of the integral.</param>
        /// <param name="SeedForN">The starting (seed) n for the rectangular method.</param>
        /// <param name="epsilon">The desired accuracy.</param>
        /// <returns>Returns the calculated integral value. 
        /// If an acceptable result is not found, returns double.NaN.</returns>
        ///<exception cref="ArgumentException">
        /// thrown if epsilon is not a positive number.
        /// </exception>
        public static double AdaptiveRectangularMethod(Function f, double a, double b, int SeedForN, double epsilon)
        {
            int nNaut = SeedForN;
            double result = 0; 
            int MaxIterations = 10;
            int count;  

            if(epsilon <= 0)
            {
                throw new ArgumentException("Epsilon must be a positive number");
            }

            for(count = 0; count < MaxIterations; count++)
            {
                int nOne = 2 * nNaut;
                double firstPoint = RectangularMethod(f, a, b, nNaut);
                double secondPoint = RectangularMethod(f, a, b, nOne); 

                if (Math.Abs(firstPoint - secondPoint) < epsilon) //calculate accuracy of each subinterval
                {
                    result = secondPoint; 
                    return result; 
                }
                else
                {
                    nNaut *= 2; 
                }
            }

            if(count == MaxIterations)
            {
                return double.NaN;
            }
            
            return result; 
        }

        /// <summary>
        /// Finds the derivative of f() at the given x.
        /// </summary>
        /// <param name="f">A delegate representing the function f.</param>
        /// <param name="x">The point at which to calculate the derivative.</param>
        /// <param name="h">The h used for the central difference method.</param>
        /// <returns>Returns the calculated derivative value. </returns>
        public static double CentralDifferenceDerivative(Function f, double x, double h)
        {
            double numerator = f(x - (2 * h)) - 8 * f(x - h) + 8 * f(x + h) - f(x + (2 * h));
            double denominator = 12 * h;

            return numerator / denominator; 
        }
    }
}