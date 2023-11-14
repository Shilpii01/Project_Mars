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

       

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
