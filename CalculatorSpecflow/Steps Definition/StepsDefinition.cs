using CalculatorSpecflow.Tests;
using CalculatorSpecflow.UIObjects;
using CalculatorSpecflow.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;
/* Author: Angelica V. Rebolloza G.
* Last Modification: 7/09/2022.
*/
namespace CalculatorSpecflow.Steps_Definitions
{
    [Binding]
    public class StepsDefinition
    {
        CalculatorUI calculatorUI =null;

        protected TestContext testContext = null;
        protected static WindowsDriver<WindowsElement> DesktopSession = null;

        public StepsDefinition(TestContext testContext)
        {
            this.testContext = testContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("\nBeforeScenario");
            DesktopSession = Setup.StartWinAppDriver();
            Console.WriteLine("WinAppDriverProcess: " + Setup.winappdriverProcess.Id);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("\nAfterScenario");
            try { DesktopSession.CloseApp(); } catch (Exception) { Console.WriteLine("Closing app failed"); }
            try { Setup.winappdriverProcess.Kill(); } catch (Exception) { Console.WriteLine("WinAppDriver CMD close failed"); }
            try { Setup.LookForWinAppDriver("WinAppDriver", true); } catch (Exception) { Console.WriteLine("Kill WinAppDriver Process failed"); }
            BaseTest.StaticWait(2);
        }

        [Given("Calculator starts")]
        public void CalculatorStarts()
        {
            Console.WriteLine("Calculator is open: " + DesktopSession);
            Assert.IsNotNull(DesktopSession);
            calculatorUI = new CalculatorUI(DesktopSession);
        }

        [When("User selects number (.*)")]
        public void SelectNumber(int number)
        {
            Console.WriteLine(number);
            if(number > 9)
            {
                var numbers = BaseTest.GetNumberParts(number);
                foreach(int num in numbers)
                {
                    calculatorUI.PressNumber(num);
                }
            } else 
            {
                calculatorUI.PressNumber(number);
            }
        }

        [When("User press operator (.*)")]
        public void SelectOperator(String symbolOperator)
        {
            Console.WriteLine(symbolOperator);
            calculatorUI.PressOperator(symbolOperator);
        }

        [Then("Result should be (.*)")]
        public void ValidateResult(double result)
        {
            Console.WriteLine(result);
            Assert.AreEqual(result, calculatorUI.GetResult());
        }
    }//class
}//namespace