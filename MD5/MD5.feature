Feature: MD5

Scenario: MD5 Encryption
	Given the service address 'http://md5.jsontest.com/'
	Given the GET request
	Given the request query parameters
	| Key  | Value        |
	| text | example_text |
	When the request is sent
	Then the response status is OK
	Then the response content type is JSON
	Then the response content looks legit to a human