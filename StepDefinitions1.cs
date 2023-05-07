using APITestingDemo2.Helper;
using APITestingDemo2.Objects;
using FluentAssertions;
using Microsoft.Extensions.DependencyModel.Resolution;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITestingDemo2.StepDefinitions
{
    [Binding]
    public class StepDefinitions1
    {

        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
        public RestResponse restResponse { get; set; }

        public string baseUrl, getUrl,getUrl2;
        

        public StepDefinitions1()
        {
            baseUrl = AppSettingHelper.Get("baseURL");
            getUrl = AppSettingHelper.Get("getEndPoint");
            getUrl2 = AppSettingHelper.Get("getEndPoint2");

        }



        [Given(@"the Get endpoint need to be triggered")]
        public void GivenTheGetEndpointNeedToBeTriggered()
        {
            string url = Path.Combine(baseUrl, getUrl2);
            restClient = new RestClient(url);
            restRequest = new RestRequest("", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
        }

        [When(@"I invoke the Get method")]
        public void WhenIInvokeTheGetMethod()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"verify the data returned")]
        public void ThenVerifyTheDataReturned()
        {
            var response = restResponse.Content;
            GetUsers1 users = JsonConvert.DeserializeObject<GetUsers1>(response);

            Assert.IsTrue(users.data.Count >= 3);

            foreach(var user in users.data)
            {
                Assert.IsTrue(user.id > 0);
                Assert.That(user.email.Contains("@") && user.email.Contains("."), Is.True, "User email should be valid");
                Assert.That(user.first_name.Length > 0, Is.True, "The first name should not be empty");
                Assert.That(user.last_name.Length > 0, Is.True, "The last name should not be empty");

            }


        }

        [Given(@"valid user IDs (.*) using get end point")]
        public void GivenValidUserIDsUsingGetEndPoint(string userId)
        {
            
            string url = Path.Combine(baseUrl, getUrl);
            string url2 = url + userId;
            restClient = new RestClient(url2);
            restRequest = new RestRequest("", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
        }

        [When(@"the user details are requested via API invoking Get method")]
        public void WhenTheUserDetailsAreRequestedViaAPIInvokingGetMethod()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"the API should return a success status code")]
        public void ThenTheAPIShouldReturnASuccessStatusCode()
        {
            restResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


        [Then(@"the response should contain the user details")]
        public void ThenTheResponseShouldContainTheUserDetails()
        {
            var response = restResponse.Content;
            GetUsers1 users = JsonConvert.DeserializeObject<GetUsers1>(response);
            users.data.Should().NotBeNull();

        }


        [Given(@"The Get end point need to be triggered")]
        public void GivenTheGetEndPointNeedToBeTriggered()
        {
            string url = Path.Combine(baseUrl, getUrl2);
           
            restClient = new RestClient(url);
            restRequest = new RestRequest("", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
        }

        [When(@"I invoke the Get method with a invalid id")]
        public void WhenIInvokeTheGetMethodWithAInvalidId()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int p0)
        {
            restResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }


    }
}
