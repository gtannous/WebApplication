using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;
using Microsoft.Ajax.Utilities;
using System.Security.Principal;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;
using System.Text;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:7050/WeatherForecast");            
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = client.Execute(request);
            Console.WriteLine(response.Content);

            var Serialized = JsonSerializer.Deserialize<List<Weather>>(response.Content);


            Weather weather = new Weather();
            weather.date = DateTime.UtcNow;
            weather.summary = "test";
            weather.temperatureC = 0;
            weather.temperatureF = 32; 
            client = new RestClient("https://localhost:7050/PostWeather"); 
            request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(weather); 
            response = client.Execute(request);

            client = new RestClient("https://localhost:7050/users");
            request = new RestRequest();
            request.Method = Method.Get;
            string authenticateHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("test:test"));
            request.AddHeader("Authorization", "Basic "+ authenticateHeader);
            response = client.Execute(request);

        }
    }
}