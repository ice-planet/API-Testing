Feature: apiTest1

Validation of the get and post end point URL

Scenario: To show the URL lists at least 3 users and they have a valid Id, email, first name, last name
Given the Get endpoint need to be triggered
When I invoke the Get method
Then verify the data returned

Scenario Outline: Retrive user details for multiple users
Given valid user IDs <user_id> using get end point
When  the user details are requested via API invoking Get method
Then the API should return a success status code
And the response should contain the user details

Examples: 
| user_id |
| 2       |
| 3       |
| 4       |


Scenario: Verifying the response for an invalid userid
Given The Get end point need to be triggered
When I invoke the Get method with a invalid id
Then the response status code should be 404
