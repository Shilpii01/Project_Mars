using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using static Project_Mars.Utilities.CommonDriver;


namespace Project_Mars.Pages
{
    public class LoginPage
    {

        public void SignInActions(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            Thread.Sleep(2000);
            // Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 5);
            IWebElement SignInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInButton.Click();

        }
        public void LogInActions(IWebDriver driver)
        {
            //driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

            try
            {
                //click Sign In
                IWebElement signInButton = driver.FindElement(By.LinkText("Sign In"));
                signInButton.Click();

                //Enter email address
                IWebElement emailAddress = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
                emailAddress.SendKeys("shilpicharu@gmail.com");

                //Enter password
                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("qwerty");

                //Click Login
                IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Portal does not launch.", ex.Message);
            }

        }
    }
}
