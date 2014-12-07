Feature: EchoJson

@echoJson
Scenario: Get Echo Json One Two
	Given the service address 'http://echo.jsontest.com/key/value/one/two'
	Given the GET request
	When the request is sent
	Then the response content looks legit to a human

@echoJson
Scenario: Get Echo Json Three Four
	Given the service address 'http://echo.jsontest.com/key/value/three/four'
	Given the GET request
	When the request is sent
	Then the response content looks legit to a human

@echoJson
Scenario: Get Echo Json Five Six
	Given the service address 'http://echo.jsontest.com/key/value/five/six'
	Given the GET request
	When the request is sent
	Then the response content looks legit to a human