Feature:Language
	User wants to add,update and delete languages in user's profile details

Background: 
	Given User logs-in to Mars portal 

   

Scenario Outline: 1. Add a new Language Record
	When User added a new language record <LanguageName> <LanguageLevel>
	Then Language record should be added successfully <LanguageName>

  Examples:   
	| LanguageName    | LanguageLevel       | 
	| 'English'       |     'Fluent'        | 
	| 'Hindi'         | 'Native/Bilingual'  |
	| 'Spanish'       |  'Conversational'   | 

Scenario Outline: 2. Edit an existing Language Record
	When User edits an existing language record <OldName> <OldLevel> <NewName> <NewLevel>
	Then Language record should be updated successfully <NewName> <NewLevel> 

  Examples:   
	| OldName   | OldLevel         | NewName  | NewLevel |
	| 'English' | 'Fluent'         | 'Arabic' | 'Basic'  |
	| 'Spanish' | 'Conversational' | 'Sindhi' | 'Fluent' |
	
Scenario Outline: 3. Delete an existing Language Record
	When User deletes an existing language record <LanguageName>  
	Then Language record should be deleted successfully <LanguageName> 
 Examples:   
	| LanguageName |
	| 'Arabic'     |
	| 'Sindhi'     |
	


