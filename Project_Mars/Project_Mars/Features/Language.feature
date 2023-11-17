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
	| 'Hindi'      | 'Native/Bilingual' |
	| 'Spanish'    | 'Conversational'   |
	| 'Tamil'      | 'Basic'            |
	

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

Scenario Outline: 4. Add a new Language Record with invalid data
	When User added a new language record with invalid data <NewName> <NewLevel>
	Then User should get an error message <NewName> <NewLevel>

  Examples:   
	| NewName                                                                                                                                                | NewLevel           |
	| 'Hindi'                                                                                                                                                | 'Native/Bilingual' |
	| 'Hindi'                                                                                                                                                | 'Native/Bilingual' |
	| ''                                                                                                                                                     | 'Fluent'           |
	| '*******'                                                                                                                                              | ''                 |
	| ''                                                                                                                                                     | 'Basic'            |
	|'123asdfghjklqsssss1234asdfghwertysssssssssssswertyuiopasdfghjklzxcvbnmqwertyuio1234567890asdfghjkl12345678fghjzxcvbnmasdfghjkpasdfghjklzxcvbnmqwe1234567890qwertyu1111111111ssssssssssssssssssiopasdfghjklzxcvbn' | 'Basic'            |


Scenario Outline: 5. Check for Maximum Added languages
	When User is trying to add more than four language records <LanguageName> <LanguageLevel>
	Then Add new language button is unavailable 

  Examples:   
	| LanguageName | LanguageLevel      |
	| 'English'    | 'Fluent'           |
	| 'Hindi'      | 'Native/Bilingual' |
	| 'Spanish'    | 'Conversational'   |
	| 'Tamil'      | 'Basic'            |
	| 'Gujarati'   | 'Fluent'           |

 
	


