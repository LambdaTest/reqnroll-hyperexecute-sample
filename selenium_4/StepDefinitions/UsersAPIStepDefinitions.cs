using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using Reqnroll;

namespace LTSpecFlow.StepDefinitions
{
    [Binding]
    public class UsersApiStepDefinitions
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;
        private JsonDocument _jsonResponse;

        public UsersApiStepDefinitions()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://dummyjson.com/")
            };
        }

        [Given(@"I request the users list from the DummyJSON API")]
        public async Task GivenIRequestTheUsersListFromTheDummyJSONAPI()
        {
            Console.WriteLine($"[LOG] Making GET request to {_httpClient.BaseAddress}users");
            _response = await _httpClient.GetAsync("users");
            Console.WriteLine($"[LOG] Received Response Status Code: {(int)_response.StatusCode} ({_response.StatusCode})");
            Assert.That(_response.IsSuccessStatusCode, Is.True, "API request was not successful.");
            Console.WriteLine("[PASS] Verified API response was successful (2XX).");
        }

        [When(@"I parse the API response")]
        public async Task WhenIParseTheAPIResponse()
        {
            var content = await _response.Content.ReadAsStringAsync();
            Console.WriteLine($"[LOG] Parsing JSON response payload...");
            _jsonResponse = JsonDocument.Parse(content);
            Console.WriteLine("[PASS] Successfully parsed JSON response.");
        }

        [Then(@"I should verify that a user with the last name ""(.*)"" exists")]
        public void ThenIShouldVerifyThatAUserWithTheLastNameExists(string lastName)
        {
            var usersElement = _jsonResponse.RootElement.GetProperty("users");
            Console.WriteLine($"[LOG] Checking {usersElement.GetArrayLength()} users for last name '{lastName}'...");
            
            bool userExists = false;
            foreach (var user in usersElement.EnumerateArray())
            {
                if (user.GetProperty("lastName").GetString() == lastName)
                {
                    userExists = true;
                    Console.WriteLine($"[LOG] Match found: User ID {user.GetProperty("id").GetInt32()}, FirstName '{user.GetProperty("firstName").GetString()}', LastName '{user.GetProperty("lastName").GetString()}'");
                    break;
                }
            }

            Assert.That(userExists, Is.True, $"No user found with the last name '{lastName}'.");
            Console.WriteLine($"[PASS] Verified that a user with the last name '{lastName}' exists in the API response.");
        }
    }
}
