using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project_Mars.Utilities;



namespace Project_Mars.Pages
{
    public class LoginPage : CommonDriver
    {
        private IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement signInButton => driver.FindElement(By.LinkText("Sign In"));
        private IWebElement emailAddress => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        private  IWebElement password => driver.FindElement(By.Name("password"));
        private  IWebElement loginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void SignInActions()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            Thread.Sleep(2000);
            // Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 5);

            SignInButton.Click();

        }
        public void LogInActions()
        {
            
            driver.Navigate().GoToUrl("http://localhost:5000/");

            signInButton.Click();
       
            emailAddress.SendKeys("shilpicharu@gmail.com");

            password.SendKeys("qwerty");

            loginButton.Click();
        }
           
    }
}
