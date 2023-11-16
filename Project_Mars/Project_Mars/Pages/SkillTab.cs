using NUnit.Framework;
using OpenQA.Selenium;
using Project_Mars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars.Pages
{
    public class SkillTab
    {
        public void CreateSkillRecord(IWebDriver driver, string SkillName, string SkillLevel)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//div[@class ='ui teal button']", 10);

            //Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class ='ui teal button']"));
          
            AddNewButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//input[@placeholder='Add Skill']", 3);
            IWebElement addSkillInputBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillInputBox.Click();
            addSkillInputBox.Clear();
            addSkillInputBox.SendKeys(SkillName);
            IWebElement selectSkillLevelDropdown = driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            selectSkillLevelDropdown.Click();

            if (SkillLevel.Equals("Beginner"))
            {
                IWebElement level = driver.FindElement(By.XPath("//Option[@value='Beginner']"));
                level.Click();
            }
            else if (SkillLevel.Equals("Intermediate"))
            {
                IWebElement level = driver.FindElement(By.XPath("//Option[@value='Intermediate']"));
                level.Click();
            }
            else if (SkillLevel.Equals("Expert"))
            {
                IWebElement level = driver.FindElement(By.XPath("//Option[@value='Expert']"));
                level.Click();
            }

            IWebElement addSkillButton = driver.FindElement(By.XPath("//input[@type='button'][@value='Add']"));
            addSkillButton.Click();
        }

        public void AssertAddedSkillRecord(IWebDriver driver, String SkillName)
        {
           
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 3);
            IWebElement AddedSkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            //IWebElement lastSkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(AddedSkillRecord.Text == SkillName, "Skill record has not added successfully");
            Thread.Sleep(1000);
        }

        public void EditSkillrecord(IWebDriver driver, String OldSkill, string OldSkillLevel, string NewSkill, string NewSkillLevel)
        {
            //int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            //if (totalrows > 0)
            //{

                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody", 4);

                int countrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table//tbody")).Count;
                for (int i = 1; i <= countrows; i++)
                {
                    Thread.Sleep(2000);
                    IWebElement selectSkillToUpdate = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                                                                                   
                    if (selectSkillToUpdate.Text.Equals(OldSkill))
                    {
                        Thread.Sleep(2000);
                        IWebElement editSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                        Thread.Sleep(1000);                                       
                        editSkillButton.Click();
                        Thread.Sleep(1000);
                        IWebElement editSkillTextbox = driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                        editSkillTextbox.Click();
                        editSkillTextbox.Clear();
                        editSkillTextbox.SendKeys(NewSkill);
                        Thread.Sleep(2000);
                        IWebElement editLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                        editLevelDropdown.Click();
                        if (NewSkillLevel.Equals("Beginner"))
                        {
                            IWebElement level = driver.FindElement(By.XPath("//Option[@value='Beginner']"));
                            level.Click();
                        }
                        else if (NewSkillLevel.Equals("Intermediate"))
                        {
                            IWebElement level = driver.FindElement(By.XPath("//Option[@value='Intermediate']"));
                            level.Click();
                        }
                        else if (NewSkillLevel.Equals("Expert"))
                        {
                            IWebElement level = driver.FindElement(By.XPath("//Option[@value='Expert']"));
                            level.Click();
                        }
                        Thread.Sleep(3000);
                        IWebElement updateSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                                                                                
                        updateSkillButton.Click();
                        break;
                    }

                }
            //}
        }

        public void AssertUpdatedSkillRecord(IWebDriver driver, String NewSkill, string NewSkillLevel)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 4);
            // Thread.Sleep(3000);
            int totalrows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= totalrows; i++)
            {
                IWebElement UpdatedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                IWebElement UpdatedSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));
                if ((UpdatedSkill.Text.Equals(NewSkill)) && (UpdatedSkillLevel.Text.Equals(NewSkillLevel)))
                {
                    Assert.That((UpdatedSkill.Text.Equals(NewSkill)) && (UpdatedSkillLevel.Text.Equals(NewSkillLevel)), "Skill record is not Updated");
                    break;
                }
            }
            Thread.Sleep(1000);

        }

        public void DeleteSkillRecord(IWebDriver driver, string SkillName)
        {
            driver.Navigate().Refresh();

            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            for (int i = 1; i <= rowCount; i++)
            {
                IWebElement selectSkillToDelete = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                if (selectSkillToDelete.Text.Equals(SkillName))
                {
                    IWebElement DeleteSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i"));

                    DeleteSkillButton.Click();
                    break;

                }
            }
            Thread.Sleep(2000);
        }

        public void AssertDeletedSkill(IWebDriver driver, string SkillName)
        {
            driver.Navigate().Refresh();
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            int i;
            for (i = 1; i <= rowCount; i++)
            {
                IWebElement DeletedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                //IWebElement selectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));
                if ((DeletedSkill.Text.Equals(SkillName)))
                {
                    Assert.That(DeletedSkill.Text != SkillName, "Skill record is not deleted");

                    break;
                }
            }
            Thread.Sleep(1000);

        }



    }
}
