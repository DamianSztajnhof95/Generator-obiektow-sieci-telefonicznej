using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;

namespace Generator.DAL
{
    public class PointsToRoadSnapper
    {
        public AllHumansPositions SnapPointsToRoad(GeneratorContext context)
        {
            AllHumansPositions fullDrawTable = new AllHumansPositions();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));           
            var humansToDraw = context.People;
            foreach(var h in humansToDraw)
            {               
                RootObject root = new RootObject();
                int iterator = 0;
                string url = $"https://roads.googleapis.com/v1/snapToRoads?path=";
                HumanPositions humanPositions = new HumanPositions();
                List<Pozycja> humanRoutes = context.Pozycje.Where(c => c.HumanId == h.HumanId).ToList();
                double beforelat=0;
                double beforelng=0;

                foreach(Pozycja i in humanRoutes)
                {
                    double midpointlat = (beforelat + i.Lat) / 2;
                    double midpointlng = (beforelng + i.Lng) / 2;
                    if (iterator == 0)
                    {
                        url = url + i.Lat.ToString().Replace(",", ".") +","+ i.Lng.ToString().Replace(",", ".");
                    }
                    else
                    {
                        url += "|" + midpointlat.ToString().Replace(",", ".") + "," + midpointlng.ToString().Replace(",", ".");
                        url = url +"|"+ i.Lat.ToString().Replace(",", ".") +"," +i.Lng.ToString().Replace(",", ".");                      
                    }
                    beforelat = i.Lat;
                    beforelng = i.Lng;
                    iterator++;
                }
                url = url + "&interpolate=true&key=AIzaSyA5jOPVeNOqU6lLscGSE3t665ejKNjrGQI";
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    root = responseContent.ReadAsAsync<RootObject>().GetAwaiter().GetResult();
                }
                else
                {                   
                    throw new Exception(response.ReasonPhrase);
                }
                foreach (var i in root.snappedPoints)
                {                  
                    humanPositions.pozycje.Add(new SingleHumanPosition { Lat = i.location.latitude , Lng = i.location.longitude });                   
                }
                fullDrawTable.fullTable.Add(new HumanPositions {pozycje=humanPositions.pozycje,humantype=h.HumanType });               
            }           
            return fullDrawTable;
        }
    }
}