using System.Collections.Generic;
using System.Linq;
using System.Net;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Deserializers;
using TechTalk.SpecFlow;

namespace RestSpecApprovalTester
{
    [Binding]
    [UseReporter(typeof(BeyondCompareReporter))]
    public class CommonSteps
    {
        [Given(@"the service address '(.*)'")]
        public void GivenTheServiceAddress(string serviceAddress)
        {
            var client = new RestClient(serviceAddress);
            ScenarioContext.Current.Add("client", client);
        }

        [Given(@"the GET request")]
        public void GivenTheGetRequest()
        {
            var request = new RestRequest(Method.GET);
            ScenarioContext.Current.Add("request", request);
        }

        [When(@"the request is sent")]
        public void WhenTheRequestIsSent()
        {
            var client = GetClient();
            var request = GetRequest();

            var response = client.Execute(request);

            ScenarioContext.Current.Add("response", response);
        }
        
        [Then(@"the response status is OK")]
        public void ThenTheResponseStatusIsOk()
        {
            var response = GetResponse();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Then(@"the response content type is JSON")]
        public void ThenTheResponseContentTypeIsJson()
        {
            var response = GetResponse();

            Assert.IsTrue(response.ContentType.Contains("application/json"));
        }

        [Then(@"the response content looks legit to a human")]
        public void ThenTheResponseContentLooksLegitToAHuman()
        {
            var response = GetResponse();

            Approvals.VerifyJson(response.Content);
        }

        [Then(@"the response content keys look legit to a human")]
        public void ThenTheResponseContentKeysLookLegitToAHuman()
        {
            var response = GetResponse();

            var jsonDeserializer= new JsonDeserializer();
            var json = jsonDeserializer.Deserialize<Dictionary<string, string>>(response);

            Approvals.Verify(json.Keys.JoinWith(","));
        }

        [Then(@"the value of the response content key of '(.*)' will look legit to a human")]
        public void ThenTheValueOfTheResponseContentKeyOfWillLookLegitToAHuman(string key)
        {
            var response = GetResponse();

            var jsonDeserializer = new JsonDeserializer();
            var json = jsonDeserializer.Deserialize<Dictionary<string, string>>(response);

            var value = json.Single(s => s.Key == key).Value;
            
            Approvals.Verify(value);
        }
        
        [Given(@"the request query parameters")]
        public void GivenTheRequestQueryParameters(Table table)
        {
            var request = GetRequest();

            foreach (var tableRow in table.Rows)
            {
                request.AddQueryParameter(tableRow["Key"], tableRow["Value"]);
            }
        }
        
        private static IRestResponse GetResponse()
        {
            return ScenarioContext.Current.Get<IRestResponse>("response");
        }

        private static IRestClient GetClient()
        {
            return ScenarioContext.Current.Get<IRestClient>("client");
        }

        private static IRestRequest GetRequest()
        {
            return ScenarioContext.Current.Get<IRestRequest>("request");
        }

    }
}
