Feature: Skill
        User wants to add,update and delete skills in user's profile details

Background: 
	Given User logs-in to Mars portal 
	And User navigates to skill tab 



Scenario Outline: 1. Add a new Skill Record with valid data
	When User added a new skill record <SkillName> <SkillLevel>
	Then Skill record should be added successfully <SkillName>

  Examples:   
	| SkillName      | SkillLevel         |
	| 'Java'         | 'Beginner'         |
	| 'Python'       | 'Intermediate'     |
	| 'C#'           | 'Expert'           |
	|'Cybersecurity' | 'Beginner'         |
	| 'QA'           | 'Expert'           |

Scenario Outline: 2. Edit an existing Skill Record
	When User edits an existing skill record <OldSkill> <OldSkillLevel> <NewSkill> <NewSkillLevel>
	Then Skill record should be updated successfully <NewSkill> <NewSkillLevel> 

  Examples:   
	| OldSkill   | OldSkillLevel     | NewSkill  | NewSkillLevel   |
	| 'Java'     | 'Beginner'   | 'Oracle'  | 'Intermediate'  |
	| 'C#'       | 'Expert'     | 'Linux'   | 'Expert'        |
	
Scenario Outline: 3. Delete an existing Skill Record
	When User deletes an existing skill record <SkillName>  
	Then Skill record should be deleted successfully <SkillName> 
 Examples:   
	| SkillName           |
	| 'Cybersecurity'     |
	| 'Linux'             |

Scenario Outline: 4. Add a new Skill Record with invalid data
	When User added a new skill record with invalid data <SkillName> <SkillLevel>
	Then Skill record not be created  <SkillName> <SkillLevel>

  Examples:   
	| SkillName                                                                                                                                                | SkillLevel           |
	| 'DJ'                                                                                                                                                | 'Beginner' |
	| 'DJ'                                                                                                                                                | 'Beginner' |
	| ''                                                                                                                                                     | 'Expert'           |
	| '*******'                                                                                                                                              | ''                 |
	| ''                                                                                                                                                     | 'Intermediate'            |
	|'123asdfghjklqsssss1234asdfghwertysssssssssssswertyuiopasdfghjklzxcvbnmqwertyuio1234567890asdfghjkl12345678fghjzxcvbnmasdfghjkpasdfghjklzxcvbnmqwe1234567890qwertyu1111111111ssssssssssssssssssiopasdfghjklzxcvbn' | 'Expert'            |