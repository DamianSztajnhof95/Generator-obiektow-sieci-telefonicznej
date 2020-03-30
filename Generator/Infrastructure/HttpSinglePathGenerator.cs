using Generator.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Generator.Infrastructure
{
    public class HttpSinglePathGenerator
    {
        public static Leg GetSinglePath(string objective ,string newObjective)
        {
            Random random = new Random();
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin=place_id:" +
                    $"{objective}&destination=place_id:{newObjective}" +
                    $"&alternatives=true&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI"; ;
            Root root = new Root();
            Leg leg = new Leg();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    root= responseContent.ReadAsAsync<Root>().GetAwaiter().GetResult();
                    leg = root.routes[random.Next(root.routes.Count-1)].legs[0];                    
                    return leg;
                }
                else
                {
                    return leg;
                }
            }
        }
    }
}