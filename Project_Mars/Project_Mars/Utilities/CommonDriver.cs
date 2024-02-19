using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Project_Mars.Utilities
{
    [TestFixture]
    [Binding]
   
    public class CommonDriver
    {
        
        public static IWebDriver driver;

        
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
        }
        
        public void Close()
        {
            
                driver.Close();
                            
        }

    }
}
