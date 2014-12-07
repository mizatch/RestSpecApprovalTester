Feature: Validation

Scenario: Validation - validation is true
	Given the service address 'http://validate.jsontest.com/?json={"key":"value"}'
	Given the GET request
	When the request is sent
	Then the response status is OK
	Then the response content type is JSON
	Then the value of the response content key of 'validate' will look legit to a human
	
Scenario: Validation - validation is false
	Given the service address 'http://validate.jsontest.com/?json={"key":"value"'
	Given the GET request
	When the request is sent
	Then the response status is OK
	Then the response content type is JSON
	Then the value of the response content key of 'validate' will look legit to a human
