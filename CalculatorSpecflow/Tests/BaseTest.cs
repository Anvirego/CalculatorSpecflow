using System;
using System.Collections.Generic;
using System.Threading;
/* Author: Angelica V. Rebolloza G.
* Last Modification: 7/09/2022.
*/
namespace CalculatorSpecflow.Tests
{
    public static class BaseTest
    {
        /// <summary>
        /// Separates numbers bigger than 9.
        /// </summary>
        /// <param name="number">Number to separate</param>
        /// <returns>List<int> containing the parts of the original number</returns>
        public static List<int> GetNumberParts(int number)
        {
            String texto = number.ToString();

            char[] parts = texto.ToCharArray();
            List<int> listNumbers = new List<int>();
            foreach (char sub in parts) {
                Console.WriteLine(sub);
                listNumbers.Add(int.Parse(sub.ToString()));
            }

            return listNumbers;
        }

        public static void StaticWait(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }//class
}//namespace