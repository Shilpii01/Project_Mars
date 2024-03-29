﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project_Mars.Utilities;
using System.Collections.ObjectModel;

namespace Project_Mars.Pages
{
    public class SkillTab: CommonDriver
    {
        public ReadOnlyCollection<IWebElement> skillrows => driver.FindElements(By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody"));

        private  IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private  IWebElement AddNewButton => driver.FindElement(By.XPath("(//div[@class='ui teal button'])[1]"));
        private  IWebElement addSkillInputBox => driver.FindElement(By.Name("name"));
        private IWebElement selectSkillLevelDropdown => driver.FindElement(By.Name("level"));
        private IWebElement addSkillButton => driver.FindElement(By.XPath("//input[@type='button'][@value='Add']"));
       private IWebElement SkillRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
      
       private IWebElement editSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
       
       private IWebElement updateSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
    
       private IWebElement DeleteSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));

        public void ClearExistingSkill()
        {
            
            Thread.Sleep(2000);
            int rows = skillrows.Count;
            for (int i = 0; i < rows; i= i+1)
            {
                DeleteSkillButton.Click();
                Thread.Sleep(2000);
            }
        }


        public void CreateSkillRecord(string SkillName, string SkillLevel)
        {
            Thread.Sleep(3000);
            SkillsTab.Click();
            AddNewButton.Click();
            Thread.Sleep(1000);
            addSkillInputBox.Click();
            addSkillInputBox.Clear();
            addSkillInputBox.SendKeys(SkillName);
           
           
            //create select element object 
            var selectElement = new SelectElement(selectSkillLevelDropdown);
            //select by value
            selectElement.SelectByValue(SkillLevel);
            // var selectElement = new SelectElement(selectSkilllevelDropdown);
                      
            addSkillButton.Click();
            Thread.Sleep(2000);
        }

        public string AddedSkillRecord()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            return SkillRecord.Text;
        }

        public void EditSkillrecord(string NewSkill, string NewSkillLevel)
        {
            Thread.Sleep(2000);
            editSkillButton.Click();
            addSkillInputBox.Click();
            addSkillInputBox.Clear();
            addSkillInputBox.SendKeys(NewSkill);
            //create select element object 
            var selectElement = new SelectElement(selectSkillLevelDropdown);
            //select by value
            selectElement.SelectByValue(NewSkillLevel);
            // var selectElement = new SelectElement(selectSkilllevelDropdown);
            updateSkillButton.Click();
            Thread.Sleep(2000);
        }
       

        public void DeleteSkillRecord()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
                   
            DeleteSkillButton.Click(); 
            Thread.Sleep(2000);
        }

        public string SkillPopUpMsg()
        {
            Thread.Sleep(2000);
            return PopUpMsg.Text;
            

        }
       

        



    }
}
