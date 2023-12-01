using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project_Mars.Utilities;



namespace Project_Mars.Pages
{
    public class HomePage:CommonDriver
    {
       IWebElement LanguageTab => driver.FindElement(By.XPath("//a[@data-tab='first']"));
        IWebElement SkillTab => driver.FindElement(By.XPath("//a[@data-tab='second']"));

        public void SelectLanguageTab()
        {
            Thread.Sleep(2000);
           // IWebElement LanguageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            LanguageTab.Click();
            

        }

        public void SelectSkillTab()
        {
            Thread.Sleep(2000);
                    
            SkillTab.Click();
            Thread.Sleep(1000);
        }
    }
}

