using RestSharp;
using System.Configuration;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace SoFun
{
    [Binding]
    public sealed class ApiSteps : Steps
    {
        private string apiKey = ConfigurationManager.AppSettings["API.Key"];
        private string apiRegion = "";
        private string apiLanguage = "";
        private IRestResponse apiResponse;


        [Given(@"I have a (valid|invalid|inactive|blank) api key")]
        public void GivenIHaveAnApiKey(string keyType)
        {
            switch (keyType)
            {
                case "valid":
                    apiKey = ConfigurationManager.AppSettings["API.Key"];
                    break;
                case "invalid":
                    apiKey = "blahblahblahblah"; // a method to randomize could make sense here
                    break;
                case "inactive":
                    apiKey = "some valid key that is inactive"; // if this is even a thing with TMDB
                    break;
                case "blank":
                    apiKey = "";
                    break;
            }
        }

        [Given(@"no movies are now playing in (Peru)")]
        public void GivenNoMoviesAreNowPlayingIn(string region)
        {
            // For illustrative purposes... set up steps like these would be used to establish the pre-conditions of the tests
            //ScenarioContext.Current.Pending();
        }

        [When(@"I request the list of movies now playing in (the world|Peru|Mexico)")]
        public void WhenIRequestTheListOfMoviesNowPlayingInTheWorld(string region)
        {
            switch (region)
            {
                case "the world":
                    apiRegion = "";
                    break;
                case "Peru":
                    apiRegion = "pe";
                    break;
                case "Mexico":
                    apiRegion = "mx";
                    break;
            }

            var client = new RestClient("https://api.themoviedb.org/3/movie/now_playing?region=" + apiRegion + "&language=" + apiLanguage + "&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            apiResponse = client.Execute(request);
        }

        [Then(@"the server responds with (OK|Unauthorized)")]
        public void ThenTheServerRespondsWithOK(HttpStatusCode expectedResponse)
        {
            Assert.Equal(expectedResponse, apiResponse.StatusCode);
        }

        [Then(@"there are (.*) total results")]
        public void ThenThereAreTotalResults(int p0)
        {
            // deserialize, assert
            //ScenarioContext.Current.Pending();
        }


    }

}
