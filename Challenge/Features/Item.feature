Feature: Item

Scenarios for items page

@item
Scenario Outline: 01_Create_new_item
	Given Open browser
	And Add the file <itemName>
	And Add the description
	And Click on create Item
	Then Confirm the item was created <createItem>

Examples:
	| itemName | createItem |
	| first    | false      |
	| second   | true       |



@item
Scenario Outline: 02_Edit_another_existing_item
	Given Open browser
	And Click on edit button random item
	And Edit Item <fieldToEdit> <itemName>
	And Click on update Item
	Then Confirm the item was updated <fieldToEdit>

Examples:
	| itemName        | fieldToEdit |
	| second          | image       |
	| New_descriprion | descriprion |


@item
Scenario Outline: 03_Delete_the_item_created
	Given Open browser
	And Click on delete button of item created
	And Confirm delete item
	Then Confirm the item was deleted

@item
Scenario Outline: 04_Check_max_long_in_description
	Given Open browser
	And Add the file <itemName>
	And Add the description with specific long <longDescirption>
	Then Validate the confirm buttom <enabledButtonConfirm>

Examples:
	| longDescirption | enabledButtonConfirm | itemName |
	| 1               | true                 | second   |
	| 299             | true                 | second   |
	| 300             | true                 | second   |
	| 301             | false                | second   |
	| 1000            | false                | second   |

@item
Scenario Outline: 05_Check_if_exist_in_the_list_the_item_with_text
	Given Open browser
	Then Validate if exits the text <text>

Examples:
	| text                               |
	| Creators: Matt Duffer, Ross Duffer |
