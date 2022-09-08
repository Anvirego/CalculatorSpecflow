using OpenQA.Selenium.Appium.Windows;
using System;
/* Author: Angelica V. Rebolloza G.
* Last Modification: 7/09/2022.
*/
namespace CalculatorSpecflow.UIObjects
{
    public class CalculatorUI : BaseUI
    {
        public CalculatorUI(WindowsDriver<WindowsElement> DesktopSession)
        {
            Main = DesktopSession;
            number_0 = Main.FindElementByAccessibilityId("num0Button");
            number_1 = Main.FindElementByAccessibilityId("num1Button");
            number_2 = Main.FindElementByAccessibilityId("num2Button");
            number_3 = Main.FindElementByAccessibilityId("num3Button");
            number_4 = Main.FindElementByAccessibilityId("num4Button");
            number_5 = Main.FindElementByAccessibilityId("num5Button");
            number_6 = Main.FindElementByAccessibilityId("num6Button");
            number_7 = Main.FindElementByAccessibilityId("num7Button");
            number_8 = Main.FindElementByAccessibilityId("num8Button");
            number_9 = Main.FindElementByAccessibilityId("num9Button");

            addButton = Main.FindElementByAccessibilityId("plusButton");
            equalButton = Main.FindElementByAccessibilityId("equalButton");

            resultTxtbx = Main.FindElementByAccessibilityId("CalculatorResults");
    }
        /// <summary>
        /// Press number selected on the Calculator.
        /// </summary>
        /// <param name="number">Number to press</param>
        public void PressNumber(int number)
        {
            switch(number)
            {
                case 0:
                    number_0.Click();
                    break;
                case 1:
                    number_1.Click();
                    break;
                case 2:
                    number_2.Click();
                    break;
                case 3:
                    number_3.Click();
                    break;
                case 4:
                    number_4.Click();
                    break;
                case 5:
                    number_5.Click();
                    break;
                case 6:
                    number_6.Click();
                    break;
                case 7:
                    number_7.Click();
                    break;
                case 8:
                    number_8.Click();
                    break;
                case 9:
                    number_9.Click();
                    break;
                default:
                    new NotImplementedException("Number '" + number + "' not defined!");
                    break;
            }//switch
        }

        /// <summary>
        /// Press Operator on the Calculator.
        /// </summary>
        /// <param name="symbolOperator">Operator to press</param>
        public void PressOperator(string symbolOperator)
        {
            switch(symbolOperator)
            {
                case "+":
                    addButton.Click();
                    break;
                case "=":
                    equalButton.Click();
                    break;
                default:
                    new NotImplementedException("Operator '" + symbolOperator + "' not defined!");
                    break;
            }
        }

        /// <summary>
        /// Gets the text from the Calculator text box.
        /// </summary>
        /// <returns>Double result</returns>
        public double GetResult()
        {
            String texto = resultTxtbx.GetAttribute("Name");
            Console.WriteLine("Texto:   " +texto);
            texto = texto.Replace("Display is ", "").Trim();
            return double.Parse(texto);
        }
    }///class
}//namespace