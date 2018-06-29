using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YutyFramework
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    throw new NotImplementedException();
                case BrowserType.InternetExplorer:
                    throw new NotImplementedException();
                case BrowserType.Opera:
                    throw new NotImplementedException();
                case BrowserType.Edge:
                    throw new NotImplementedException();
                case BrowserType.Safari:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException("Browser type does not exist....yet");
            }
        }

        private static IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
