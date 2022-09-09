namespace MeteoForms.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;

    public class APICurrentWeather
    {
        public int Cod { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        [JsonPropertyName("main")]
        public Main Temperature { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weathers { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }


    }
}
