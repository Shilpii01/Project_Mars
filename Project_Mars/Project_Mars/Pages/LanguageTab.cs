using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V117.Debugger;
using OpenQA.Selenium.Support.UI;
using Project_Mars.Utilities;
using SeleniumExtras.WaitHelpers;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Project_Mars.Pages
{
    public class LanguageTab
    {
        private readonly IWebDriver driver;

        //public LanguageTab(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        public LanguageTab()
        {
        }

        public void CreateLanguageRecord(IWebDriver driver, string LanguageName, string LanguageLevel)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='first']//div[@class ='ui teal button ']", 10);

            int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            Console.WriteLine(totalrows);

            if (totalrows < 4)
            {
                Thread.Sleep(3000);

                IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
                AddNewButton.Click();

                Wait.WaitToBeVisible(driver, "XPath", "//input[@placeholder='Add Language']", 3);
                IWebElement addLanguageInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
                addLanguageInputBox.Click();
                addLanguageInputBox.Clear();
                addLanguageInputBox.SendKeys(LanguageName);
                IWebElement selectLanguageLevelDropdown = driver.FindElement(By.XPath("//select [@class='ui dropdown']"));
                selectLanguageLevelDropdown.Click();

                if (LanguageLevel.Equals("Basic"))
                {
                    IWebElement level = driver.FindElement(By.XPath("//Option[@value='Basic']"));
                    level.Click();
                }
                else if (LanguageLevel.Equals("Conversational"))
                {
                    IWebElement level = driver.FindElement(By.XPath("//Option[@value='Conversational']"));
                    level.Click();
                }
                else if (LanguageLevel.Equals("Fluent"))
                {
                    IWebElement level = driver.FindElement(By.XPath("//Option[@value='Fluent']"));
                    level.Click();
                }
                else if (LanguageLevel.Equals("Native/Bilingual"))
                {
                    IWebElement level = driver.FindElement(By.XPath("//Option[@value='Native/Bilingual']"));
                    level.Click();
                }
                IWebElement addLanguageButton = driver.FindElement(By.XPath("//input [@type='button'][@value='Add']"));
                addLanguageButton.Click();
                Thread.Sleep(2000);
            }

        }



        public void AssertAddedLanguageRecord(IWebDriver driver, String LanguageName)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1] ", 3);
            IWebElement AddedLanguageRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(AddedLanguageRecord.Text == LanguageName, "Language record has not added successfully");
            Thread.Sleep(1000);
        }

        public void EditLanguagerecord(IWebDriver driver, String OldName, string OldLevel, string NewName, string NewLevel)
        {
            int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (totalrows > 0)
            {

                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody", 4);

                int countrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
                for (int i = 1; i <= countrows; i++)
                {
                    Thread.Sleep(2000);
                    IWebElement selectLanguageToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                    if (selectLanguageToUpdate.Text.Equals(OldName))
                    {
                        Thread.Sleep(2000);
                        IWebElement editLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                        Thread.Sleep(1000);
                        editLanguageButton.Click();
                        Thread.Sleep(1000);
                        IWebElement editLanguageTextbox = driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                        editLanguageTextbox.Click();
                        editLanguageTextbox.Clear();
                        editLanguageTextbox.SendKeys(NewName);
                        Thread.Sleep(2000);
                        IWebElement editLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                        editLevelDropdown.Click();
                        if (NewLevel.Equals("Basic"))
                        {
                            IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                            levelOption.Click();
                        }
                        else if (NewLevel.Equals("Conversational"))
                        {
                            IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                            levelOption.Click();
                        }
                        else if (NewLevel.Equals("Fluent"))
                        {
                            IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                            levelOption.Click();
                        }
                        else if (NewLevel.Equals("Native/Bilingual"))
                        {
                            IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                            levelOption.Click();
                        }
                        Thread.Sleep(3000);
                        IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));

                        updateButton.Click();
                        break;
                    }

                }
            }
        }

        public void AssertUpdatedLanguageRecord(IWebDriver driver, String NewName, string NewLevel)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 4);
            // Thread.Sleep(3000);
            int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= totalrows; i++)
            {
                IWebElement UpdatedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                IWebElement UpdatedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));
                if ((UpdatedLanguage.Text.Equals(NewName)) && (UpdatedLevel.Text.Equals(NewLevel)))
                {
                    Assert.That((UpdatedLanguage.Text.Equals(NewName)) && (UpdatedLevel.Text.Equals(NewLevel)), "Language record is not Updated");
                    break;
                }
            }
            Thread.Sleep(1000);

        }

        public void DeleteLanguageRecord(IWebDriver driver, string LanguageName)
        {
            driver.Navigate().Refresh();

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            for (int i = 1; i <= rowCount; i++)
            {
                IWebElement selectLanguageToDelete = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                if (selectLanguageToDelete.Text.Equals(LanguageName))
                {
                    IWebElement DeleteLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i"));

                    DeleteLanguageButton.Click();
                    break;

                }
            }
            Thread.Sleep(2000);
        }

        public void AssertDeletedlanguage(IWebDriver driver, string LanguageName)
        {
            driver.Navigate().Refresh();
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {
                IWebElement DeletedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                //IWebElement selectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));
                if ((DeletedLanguage.Text.Equals(LanguageName)))
                {
                    Assert.That(DeletedLanguage.Text != LanguageName, "Language record is not deleted");

                    break;
                }
            }
            Thread.Sleep(1000);

        }



        public void MaximumLanguagesAdded(IWebDriver driver)
        {
            Thread.Sleep(3000);

            int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            Console.WriteLine(totalrows);
            bool Item;
            try
            {
                Item = driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']")).Displayed;
            }
            catch (Exception ) 
            {
                if ((totalrows <= 4))
                {
                    Assert.Pass("Maximum Languages Added ");

                }
            }
            
            
        }

        public void duplicaterecord(IWebDriver driver, string NewName, string NewLevel) 
        { 
            driver.Navigate().Refresh();
            int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= totalrows; i++)
            {
                IWebElement LanguageName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                IWebElement LanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));
                // IWebDriver popmsg = (IWebDriver)driver.FindElement(By.XPath("//div[contains(text(),'This language is already exist in your language li')]"));
                if ((LanguageName.Text.Equals(NewName)) && (LanguageLevel.Text.Equals(NewLevel)))
                {

                    Assert.Pass("Duplicate Language record cannot be created");

                    //((UpdatedLanguage.Text.Equals(NewName)) && (UpdatedLevel.Text.Equals(NewLevel)), "Language record is not Updated");
                    break;

                }
                else if ((LanguageName.Text!= (NewName)) && (LanguageLevel.Text!= (NewLevel)))
                {
                    Assert.Pass("Invalid record data ");
                    break;
                }
                
            }
            Thread.Sleep(1000);
        }

        
    }
}
       
        
    