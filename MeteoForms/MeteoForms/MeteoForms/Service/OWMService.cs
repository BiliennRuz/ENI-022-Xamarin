namespace MeteoForms.Service
{
    using MeteoForms.Models;
    using MeteoForms.Utils;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class OWMService
    {
        private RestClient client;

        public OWMService()
        {
            client = new RestClient(Constant.URL_BASE); // https://api.openweathermap.org/
        }

        public Task<APICurrentWeather> CurrentWeather(string cityName)
        {
            var query = string.Format(Constant.URL_WEATHER, cityName); // weather?q=quimper etc ...

            var request = new RestRequest(query);

            return client.GetAsync<APICurrentWeather>(request);
        }

    }
}
