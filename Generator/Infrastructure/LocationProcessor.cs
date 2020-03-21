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
        public static LocationRootObject LoadLocation(string query, string secondquery, string  town,int radius)
        {
            string url = "";
            if (secondquery == null)
            {
                 url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={town}" +
                    $"&radius={radius}&type={query}&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
            }
            else
            {
                 url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken=" +
                    $"{ secondquery }&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
            }
            using (HttpClient client = new HttpClient())
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

