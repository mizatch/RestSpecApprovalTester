Feature: DateAndTime

Background:

Given the service address 'http://date.jsontest.com'

@dateAndTime
Scenario: GetDateAndTime
	Given the GET request
	When the request is sent
	Then the response status is OK
	Then the response content type is JSON
	Then the response content keys look legit to a human
