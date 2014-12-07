Feature: IPAddress

Background: 
	Given the service address 'http://ip.jsontest.com/'
	
@ipaddress
Scenario: GetIPAddress
	Given the GET request
	When the request is sent
	Then the response status is OK
	Then the response content type is JSON
	Then the response content looks legit to a human
