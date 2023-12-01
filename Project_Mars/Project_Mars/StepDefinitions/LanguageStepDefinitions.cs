using NUnit.Framework;
using Project_Mars.Pages;
using Project_Mars.Utilities;


namespace Project_Mars.StepDefinitions
{
    [Binding]
    [Parallelizable]
    public class LanguageStepDefinitions: CommonDriver
    {
            
        
            LanguageTab LanguageTabObj;
            LoginPage LoginPageObj;
            HomePage HomePageObj;

            public LanguageStepDefinitions()
            {
                LanguageTabObj = new LanguageTab();
                LoginPageObj = new LoginPage();
                HomePageObj = new HomePage();
            }

            [Given(@"User logs-in to Mars portal")]
        public void GivenUserLogs_InToMarsPortal()
        {
            LoginPageObj.LogInActions();
            HomePageObj.SelectLanguageTab();
           
        }
        

        [When(@"User added a new language record '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewLanguageRecord(string LanguageName, string LanguageLevel)
        {
            LanguageTabObj.ClearExistingLanguages();
            LanguageTabObj.CreateLanguageRecord( LanguageName, LanguageLevel);
        }

        [Then(@"Language record should be added successfully '([^']*)'")]
        public void ThenLanguageRecordShouldBeAddedSuccessfully(string LanguageName)
        {
            string newLanguage = LanguageTabObj.AddedLanguageRecord();
            Assert.That(LanguageName == newLanguage, "Language Record has not been created ");
            
        }

        [Then(@"User edits an existing language record '([^']*)' '([^']*)'")]
        public void ThenUserEditsAnExistingLanguageRecord(string NewName, string NewLevel)
        {
            LanguageTabObj.EditLanguagerecord(NewName, NewLevel);
        }


       

        [Then(@"Language record should be updated successfully '([^']*)'")]
        public void ThenLanguageRecordShouldBeUpdatedSuccessfully(string NewName)
        {

           
            string newLanguage = LanguageTabObj.AddedLanguageRecord();

            Assert.That(NewName == newLanguage, "Language has not been edited");
        }

        [When(@"User deletes an existing language record")]
        public void WhenUserDeletesAnExistingLanguageRecord()
        {
            LanguageTabObj.DeleteLanguageRecord();
        }

        [Then(@"Language record should be deleted successfully '([^']*)'")]
        public void ThenLanguageRecordShouldBeDeletedSuccessfully(string LanguageName)
        {
            string deletedElement = LanguageTabObj.GetDeletedElement();
            Assert.That(LanguageName!= deletedElement, "Deleted language and expected language does not match");

        }

        [When(@"User added a new language record with invalid data '([^']*)' '([^']*)'")]
        public void WhenUserAddedANewLanguageRecordWithInvalidData(string LanguageName, string LanguageLevel)
        {
            LanguageTabObj.CreateLanguageRecord(LanguageName, LanguageLevel);   
        }

        [Then(@"User should get an error message '([^']*)' '([^']*)'")]
        public void ThenUserShouldGetAnErrorMessage(string NewName, string NewLevel)
        {
            string InvalidData= LanguageTabObj.LanguagePopUpMsg();
            Assert.That(InvalidData == "Please enter language and level", "invalid data");
        }


        [When(@"User can add max four language records '([^']*)' '([^']*)'")]
        public void WhenUserCanAddMaxFourLanguageRecords(string LanguageName, string LanguageLevel)
        {
            LanguageTabObj.CreateLanguageRecord(LanguageName, LanguageLevel);
        }



        [Then(@"Add new language button is unavailable")]
        public void ThenAddNewLanguageButtonIsUnavailable()
        {
            int totalrows = LanguageTabObj.rows.Count;
            if (totalrows == 4)
            {
                Assert.Pass("Maximum Languages Added");
            }

        }

        




    }
}
