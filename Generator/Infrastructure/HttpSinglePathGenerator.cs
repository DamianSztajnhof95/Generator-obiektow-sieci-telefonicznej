using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;

namespace Generator.Infrastructure
{
    public class HttpSinglePathGenerator
    {
        public static Route GetSinglePath(string objective ,string newObjective)
        {
            Random random = new Random();
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin=place_id:" +
                    $"{objective}&destination=place_id:{newObjective}&alternatives=true&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI"; ;
            Root root = new Root();
            Route route = new Route();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    root= responseContent.ReadAsAsync<Root>().GetAwaiter().GetResult();
                    route = root.routes[random.Next(root.routes.Count-1)];
                    return route;
                }
                else
                {
                    return route;
                }
            }
        }
    }
}