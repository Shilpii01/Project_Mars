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
	
	

Scenario Outline: 2. Edit an existing Skill Record
	When User added a new skill record <SkillName> <SkillLevel>
	Then User edits an existing skill record <NewSkill> <NewSkillLevel>
	Then Skill record should be updated successfully <NewSkill> 

  Examples:   
	| SkillName   | SkillLevel  | NewSkill  | NewSkillLevel   |
	| 'Java'     | 'Beginner'   | 'Oracle'  | 'Intermediate'  |
	
	
Scenario Outline: 3. Delete an existing Skill Record
	When User added a new skill record <SkillName> <SkillLevel>
	Then User deletes an existing skill record  
	Then Skill record should be deleted successfully <SkillName> 
 Examples:   
	| SkillName           | SkillLevel         |
	| 'Oracle'            | 'Intermediate'  |

Scenario Outline: 4. Add a new Skill Record with invalid data
	When User added a new skill record with invalid data <SkillName> <SkillLevel>
	Then Skill record not be created  <SkillName> <SkillLevel>

  Examples:   
	| SkillName                | SkillLevel         |
	| 'DJ'                     | ''                 |
	| ''                       | 'Beginner'         |
	| ''                       | 'Expert'           |
	| '*******'                | ''                 |
	| ''                       | 'Intermediate'     |

Scenario Outline: 5.Max Charcaters input 
	When User added a new skill record <SkillName> <SkillLevel>
	Then Skill record should be added successfully <SkillName>

	Examples:
	| SkillName                                                                                                                                                                                                          | SkillLevel |
	|     '!@$%1542761'                                                                                                                                                                                                  | 'Beginner' |
	| '123asdfghjklqsssss1234asdfghwertysssssssssssswertyuiopasdfghjklzxcvbnmqwertyuio1234567890asdfghjkl12345678fghjzxcvbnmasdfghjkpasdfghjklzxcvbnmqwe1234567890qwertyu1111111111ssssssssssssssssssiopasdfghjklzxcvbn' | 'Expert'   |