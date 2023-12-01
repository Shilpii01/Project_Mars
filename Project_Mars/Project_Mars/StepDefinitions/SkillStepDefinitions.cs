using NUnit.Framework;
using OpenQA.Selenium;
using Project_Mars.Pages;
using Project_Mars.Utilities;

namespace Project_Mars.StepDefinitions
{
    [Binding]
    [Parallelizable]
    public class SkillStepDefinitions:CommonDriver
    {

        LoginPage LoginPageobj;
        HomePage HomePageobj;
        SkillTab SkillTabobj;
     

        public SkillStepDefinitions()
        {
           LoginPageobj = new LoginPage(); 
            HomePageobj = new HomePage();
            SkillTabobj = new SkillTab();
        }

        [Given(@"User navigates to skill tab")]
        public void GivenUserNavigatesToSkillTab()
        {
            HomePageobj.SelectSkillTab();
        }


        [When(@"User added a new skill record '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewSkillRecord(string SkillName, string SkillLevel)
        {
            SkillTabobj.ClearExistingSkill();
            SkillTabobj.CreateSkillRecord(SkillName, SkillLevel);
        }

        [Then(@"Skill record should be added successfully '([^']*)'")]
        public void ThenSkillRecordShouldBeAddedSuccessfully(string SkillName)
        {
            string newSkill = SkillTabobj.AddedSkillRecord();
            Assert.That(SkillName == newSkill, "Skill Record has not been created successfully");
        }

        [Then(@"User edits an existing skill record '([^']*)' '([^']*)'")]
        public void ThenUserEditsAnExistingSkillRecord(string NewSkill, string NewSkillLevel)
        {
            SkillTabobj.EditSkillrecord(NewSkill, NewSkillLevel);
        }

        [Then(@"Skill record should be updated successfully '([^']*)'")]
        public void ThenSkillRecordShouldBeUpdatedSuccessfully(string NewSkill)
        {
            string Skill = SkillTabobj.AddedSkillRecord();
            Assert.That(NewSkill == Skill, "Skill Record has not been updated successfully");
        }

        [Then(@"User deletes an existing skill record")]
        public void ThenUserDeletesAnExistingSkillRecord()
        {
            SkillTabobj.DeleteSkillRecord();
        }
       
        [Then(@"Skill record should be deleted successfully '([^']*)'")]
        public void ThenSkillRecordShouldBeDeletedSuccessfully(string SkillName)
        {
            string deletedSkillText = SkillTabobj.SkillPopUpMsg();
            Assert.That(deletedSkillText == SkillName + "has been deleted from your skills", "Skill record has not been deleted");
        }

        [When(@"User added a new skill record with invalid data '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewSkillRecordWithInvalidData(string SkillName, string SkillLevel)
        {
            SkillTabobj.CreateSkillRecord(SkillName, SkillLevel);
        }

        [Then(@"Skill record not be created  '([^']*)' '([^']*)'")]
        public void ThenSkillRecordNotBeCreated(string SkillName, string SkillLevel)
        {
            string InvalidData = SkillTabobj.SkillPopUpMsg();
            Assert.That(InvalidData == "Please enter skill and experience level", "invalid data");
        }

    }
}
