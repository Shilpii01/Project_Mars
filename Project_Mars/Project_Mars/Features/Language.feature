Feature:Language
	User wants to add,update and delete languages in user's profile details

Background: 
	Given User logs-in to Mars portal 
	


	
Scenario Outline: 1. Add a new Language Record with valid data
	When User added a new language record <LanguageName> <LanguageLevel>
	Then Language record should be added successfully <LanguageName>

  Examples:   
	| LanguageName | LanguageLevel      |
	| 'English'    | 'Fluent'           |
	
	

	
	
	
Scenario Outline: 2. Edit an existing Language Record
	When User added a new language record <LanguageName> <LanguageLevel>
	Then User edits an existing language record <NewName> <NewLevel>
	Then Language record should be updated successfully <NewName>

  Examples:   
	| LanguageName | LanguageLevel       | NewName  | NewLevel |
     | 'English'    | 'Fluent'           | 'Arabic' | 'Fluent' |
	
	
Scenario Outline: 3. Delete an existing Language Record
	When User deletes an existing language record 
	Then Language record should be deleted successfully <LanguageName> 
 Examples:   
	| LanguageName | LanguageLevel       | 
	| 'Arabic'    | 'Fluent'            |
	
	
Scenario Outline: 4. Add a new Language Record with invalid data
	When User added a new language record with invalid data <NewName> <NewLevel>
	Then User should get an error message <NewName> <NewLevel>

  Examples:   
	| NewName       | NewLevel           |
	| ''            | 'Fluent'           |
	| '*******'     | ''                 |
	
	
Scenario Outline: 5. Check for Maximum Added languages
	When User can add max four language records <LanguageName> <LanguageLevel>
	Then Add new language button is unavailable 

  Examples:   
	| LanguageName | LanguageLevel      |
	| 'English'    | 'Fluent'           |
	| 'Hindi'      | 'Native/Bilingual' |
	|'123asdfghjklqsssss1234asdfghwertysssssssssssswertyuiopasdfghjklzxcvbnmqwertyuio1234567890asdfghjkl12345678fghjzxcvbnmasdfghjkpasdfghjklzxcvbnmqwe1234567890qwertyu1111111111ssssssssssssssssssiopasdfghjklzxcvbn' | 'Basic'            |
	| 'Tamil'      | 'Basic'            |
	
	

 
	


