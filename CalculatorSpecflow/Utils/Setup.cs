using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
/* Author: Angelica V. Rebolloza G.
 * Last Modification: 7/09/2022.
 */
namespace CalculatorSpecflow.Utils
{
    public class Setup
    {
        public const string DriverUrl = "http://127.0.0.1:4723/";
        public const string WinAppDriverPath = @"C:\Program Files (x86)\Windows Application Driver\";
        public static Process winappdriverProcess = null;

        /// <summary>
        ///  Validates if WinAppDriver Process is already running if not, starts WinAppDriver Process and creates a DesktopSession with Calculator app.
        /// </summary>
        /// <returns></returns>
        public static WindowsDriver<WindowsElement> StartWinAppDriver()
        {
            if (!LookForWinAppDriver("WinAppDriver", false))
                winappdriverProcess = RunWinAppDriver();

            Console.WriteLine("WinAppDriverProcess: " +winappdriverProcess.Id);

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            WindowsDriver<WindowsElement> DesktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), options);

            Assert.IsNotNull(DesktopSession);

            //Adds implicit Wait on DesktopSession
            DesktopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return DesktopSession;
        }//method
        
        /// <summary>
        /// Looks for WinAppDriver Process
        /// </summary>
        /// <param name="processName"> Name of the Process to look for </param>
        /// <param name="killProcess"> True if found process will be killed, false to keep the process </param>
        /// <returns>True if process was found, false if not</returns>
        public static Boolean LookForWinAppDriver(String processName, Boolean killProcess)
        {
            bool found = false;
            foreach (var process in Process.GetProcessesByName(processName))
            {
                Console.WriteLine("WinAppDriver already running...");
                winappdriverProcess = process;
                found = true;
            }
            if (found && killProcess)
                winappdriverProcess.Kill();

            return found;
        }

        /// <summary>
        /// Starts WinAppDriver Process using CMD with Admin rights.
        /// </summary>
        /// <returns></returns>
        private static Process RunWinAppDriver()
        {
            string command = @"cd " + WinAppDriverPath + "&&WinAppDriver.exe";

            var startAppInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/K" + command,
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = true,
                UseShellExecute = true,
                Verb = "runas"
            };
            return Process.Start(startAppInfo);
        }
    }//class
}//namespace