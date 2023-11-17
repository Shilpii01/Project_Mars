using NUnit.Framework;
using OpenQA.Selenium;
using Project_Mars.Pages;
using Project_Mars.Utilities;
using System;


namespace Project_Mars.StepDefinitions
{
    [Binding]
    [Parallelizable]
    public class LanguageStepDefinitions 
    {
        LoginPage LoginPageobj = new LoginPage();
        HomePage HomePageobj = new HomePage();
        LanguageTab LanguageTabobj = new LanguageTab();

        private IWebDriver driver;

        public LanguageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User logs-in to Mars portal")]
        public void GivenUserLogs_InToMarsPortal()
        {
            LoginPageobj.LogInActions(driver);
            HomePageobj.SelectLanguageTab(driver);
        }

        [When(@"User added a new language record '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewLanguageRecord(string LanguageName, string LanguageLevel)
        {
            LanguageTabobj.CreateLanguageRecord( driver, LanguageName, LanguageLevel);
        }

        [Then(@"Language record should be added successfully '([^']*)'")]
        public void ThenLanguageRecordShouldBeAddedSuccessfully(string LanguageName)
        {
            LanguageTabobj.AssertAddedLanguageRecord(driver, LanguageName);
        }

        [When(@"User edits an existing language record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingLanguageRecord(string OldName, string OldLevel, string NewName, string NewLevel)
        {
            LanguageTabobj.EditLanguagerecord(driver, OldName, OldLevel, NewName, NewLevel);
        }

        [Then(@"Language record should be updated successfully '([^']*)' '([^']*)'")]
        public void ThenLanguageRecordShouldBeUpdatedSuccessfully(string NewName, string NewLevel)
        {
            LanguageTabobj.AssertUpdatedLanguageRecord(driver, NewName, NewLevel);
        }

        [When(@"User deletes an existing language record '([^']*)'")]
        public void WhenUserDeletesAnExistingLanguageRecord(string LanguageName)
        {
            LanguageTabobj.DeleteLanguageRecord(driver, LanguageName);  
        }

        [Then(@"Language record should be deleted successfully '([^']*)'")]
        public void ThenLanguageRecordShouldBeDeletedSuccessfully(string LanguageName)
        {
            LanguageTabobj.AssertDeletedlanguage(driver, LanguageName);
        }

        [When(@"User added a new language record with invalid data '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewLanguageRecordWithInvalidData(string LanguageName, string LanguageLevel)
        {
            LanguageTabobj.CreateLanguageRecord(driver, LanguageName, LanguageLevel);   
        }

        [Then(@"User should get an error message '([^']*)' '([^']*)'")]
        public void ThenUserShouldGetAnErrorMessage(string NewName, string NewLevel)
        {
            LanguageTabobj.duplicaterecord(driver, NewName, NewLevel);
        }



        [When(@"User is trying to add more than four language records '([^']*)' '([^']*)'")]
        public void WhenUserIsTryingToAddMoreThanFourLanguageRecords(string LanguageName, string LanguageLevel)
        {
            LanguageTabobj.CreateLanguageRecord(driver, LanguageName, LanguageLevel);
        }


        [Then(@"Add new language button is unavailable")]
        public void ThenAddNewLanguageButtonIsUnavailable()
        {
            LanguageTabobj.MaximumLanguagesAdded(driver);
        }

        




    }
}
