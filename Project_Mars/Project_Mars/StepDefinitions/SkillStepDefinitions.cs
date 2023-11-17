using NUnit.Framework;
using OpenQA.Selenium;
using Project_Mars.Pages;
using Project_Mars.Utilities;

namespace Project_Mars.StepDefinitions
{
    [Binding]
    [Parallelizable]
    public class SkillStepDefinitions
    {

        LoginPage LoginPageobj = new LoginPage();
        HomePage HomePageobj = new HomePage();
        SkillTab SkillTabobj = new SkillTab();
        private IWebDriver driver;

        public SkillStepDefinitions(IWebDriver driver)
        {
           this.driver = driver;
        }

        [Given(@"User navigates to skill tab")]
        public void GivenUserNavigatesToSkillTab()
        {
            HomePageobj.SelectSkillTab(driver);
        }


        [When(@"User added a new skill record '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewSkillRecord(string SkillName, string SkillLevel)
        {
            
            SkillTabobj.CreateSkillRecord(driver, SkillName, SkillLevel);
        }

        [Then(@"Skill record should be added successfully '([^']*)'")]
        public void ThenSkillRecordShouldBeAddedSuccessfully(string SkillName)
        {
            SkillTabobj.AssertAddedSkillRecord(driver, SkillName);
        }

        [When(@"User edits an existing skill record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingSkillRecord(string OldSkill, string OldSkillLevel, string NewSkill, string NewSkillLevel)
        {
            SkillTabobj.EditSkillrecord(driver, OldSkill, OldSkillLevel, NewSkill, NewSkillLevel);
        }

        [Then(@"Skill record should be updated successfully '([^']*)' '([^']*)'")]
        public void ThenSkillRecordShouldBeUpdatedSuccessfully(string NewSkill, string NewSkillLevel)
        {
            SkillTabobj.AssertUpdatedSkillRecord(driver, NewSkill, NewSkillLevel);
        }

        [When(@"User deletes an existing skill record '([^']*)'")]
        public void WhenUserDeletesAnExistingSkillRecord(string SkillName)
        {
            SkillTabobj.DeleteSkillRecord(driver, SkillName);
        }

        [Then(@"Skill record should be deleted successfully '([^']*)'")]
        public void ThenSkillRecordShouldBeDeletedSuccessfully(string SkillName)
        {
            SkillTabobj.AssertDeletedSkill(driver, SkillName);
        }

        [When(@"User added a new skill record with invalid data '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewSkillRecordWithInvalidData(string SkillName, string SkillLevel)
        {
            SkillTabobj.CreateSkillRecord(driver, SkillName, SkillLevel);
        }

        [Then(@"Skill record not be created  '([^']*)' '([^']*)'")]
        public void ThenSkillRecordNotBeCreated(string SkillName, string SkillLevel)
        {
            SkillTabobj.invalidSkillRecord(driver, SkillName, SkillLevel);
        }

    }
}
