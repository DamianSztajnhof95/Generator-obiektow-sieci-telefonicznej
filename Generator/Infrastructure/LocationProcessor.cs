using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Generator.DAL
{
    public class LocationProcessor
    {
        public static LocationRootObject LoadLocation(string query)
        {           
            string url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=50.01241376861261,20.988371372222904&type={ query }&radius=500&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    LocationRootObject root = responseContent.ReadAsAsync<LocationRootObject>().GetAwaiter().GetResult();
                    return root;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }   
        }
    }
}

