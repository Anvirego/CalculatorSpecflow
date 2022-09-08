using OpenQA.Selenium.Appium.Windows;
/* Author: Angelica V. Rebolloza G.
* Last Modification: 7/09/2022.
*/
namespace CalculatorSpecflow.UIObjects
{
    public class BaseUI
    {
        //Main Page of Calculator
        protected static WindowsDriver<WindowsElement> Main = null;
        //Numbers
        protected WindowsElement number_0 = null;
        protected WindowsElement number_1 = null;
        protected WindowsElement number_2 = null;
        protected WindowsElement number_3 = null;
        protected WindowsElement number_4 = null;
        protected WindowsElement number_5 = null;
        protected WindowsElement number_6 = null;
        protected WindowsElement number_7 = null;
        protected WindowsElement number_8 = null;
        protected WindowsElement number_9 = null;
        //Operators
        protected WindowsElement addButton = null;
        protected WindowsElement equalButton = null;
        //Textbox Result
        protected WindowsElement resultTxtbx = null;
    }//class
}//namespace
