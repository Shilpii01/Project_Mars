﻿using OpenQA.Selenium;
//using static Project_Mars.Utilities.CommonDriver;


namespace Project_Mars.Pages
{
    public class HomePage
    {
        
        public void SelectLanguageTab(IWebDriver driver)
        {
            Thread.Sleep(2000);

            //Wait.waitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 2);
            IWebElement LanguageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            LanguageTab.Click();

        }

        public void SelectSkillTab(IWebDriver driver)
        {
            Thread.Sleep(2000);
            //Wait.waitToBeVisible(driver, "XPath", "//a[contains(text(),'Skills')]", 2);
            IWebElement SkillTab = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            SkillTab.Click();

        }
    }
}

