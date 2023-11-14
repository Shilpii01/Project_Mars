using Project_Mars.Pages;
using Project_Mars.Utilities;


namespace Project_Mars.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
        LoginPage LoginPageobj = new LoginPage();
        HomePage HomePageobj = new HomePage();
        LanguageTab LanguageTabobj = new LanguageTab();

        [Given(@"User logs-in to Mars portal")]
        public void GivenUserLogs_InToMarsPortal()
        {
            LoginPageobj.LogInActions();
            HomePageobj.SelectLanguageTab();
        }

        [When(@"User added a new language record '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewLanguageRecord(string LanguageName, string LanguageLevel)
        {
            LanguageTabobj.CreateLanguageRecord(driver, LanguageName, LanguageLevel);
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

       

    }
}
