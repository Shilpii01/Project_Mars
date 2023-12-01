using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project_Mars.Utilities;
using System.Collections.ObjectModel;

namespace Project_Mars.Pages
{
    public class LanguageTab : CommonDriver
    {
       

       public ReadOnlyCollection<IWebElement> rows => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody"));

       private IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
       private IWebElement addLanguageInputBox => driver.FindElement(By.Name("name"));
        private IWebElement selectLanguageLevelDropdown => driver.FindElement(By.Name("level"));
        private IWebElement addLanguageButton => driver.FindElement(By.XPath("//input [@type='button'][@value='Add']"));
        private IWebElement LanguageRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        private IWebElement editLanguageButton => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));

        private IWebElement deletedElement => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));

        private IWebElement DeleteLanguageButton => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        

        public void ClearExistingLanguages() 
        {
            Thread.Sleep(2000);
            int totalrows= rows.Count;
            Console.WriteLine(totalrows);
            for (int i = 0; i < totalrows ;i= i+1)
            {
                DeleteLanguageButton.Click();
                Thread.Sleep(2000);
            }

        }





        public void CreateLanguageRecord( string LanguageName, string LanguageLevel)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='first']//div[@class ='ui teal button ']", 10);
                        
                Thread.Sleep(3000);
                            
                AddNewButton.Click();
                Wait.WaitToBeVisible(driver, "XPath", "//input[@placeholder='Add Language']", 3);
                
                addLanguageInputBox.Click();
                addLanguageInputBox.Clear();
                addLanguageInputBox.SendKeys(LanguageName);
                //create select element object 
                 var selectElement = new SelectElement(selectLanguageLevelDropdown);
               //select by value
                selectElement.SelectByValue(LanguageLevel);
    
                addLanguageButton.Click();
                Thread.Sleep(2000);         

        }




        public string AddedLanguageRecord()
        {
            driver.Navigate().Refresh();

            return LanguageRecord.Text;
        }

        public void EditLanguagerecord( string NewName, string NewLevel)
        {

            Thread.Sleep(1000);
            editLanguageButton.Click();
            addLanguageInputBox.Click();
            addLanguageInputBox.Clear();
            addLanguageInputBox.SendKeys(NewName);
            //create select element object 
            var selectElement = new SelectElement(selectLanguageLevelDropdown);
            //select by value
            selectElement.SelectByValue(NewLevel);
            updateButton.Click();

        }

       
        public void DeleteLanguageRecord()
        {
                             
           DeleteLanguageButton.Click();
                              
        }

        public string GetDeletedElement()
        {
            return deletedElement.Text;
        }

        public string LanguagePopUpMsg()
        {
            Thread.Sleep(2000);
            return PopUpMsg.Text;
           

        }
        public Boolean ButtonIsAvailable() 
        {
           bool Buttonvalue = AddNewButton.Displayed;
            return Buttonvalue;
        }


        

        

    }
}


