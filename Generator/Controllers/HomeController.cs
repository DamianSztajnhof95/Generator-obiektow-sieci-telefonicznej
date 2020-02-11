using Generator.DAL;
using Generator.Infrastructure;
using Generator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Generator.Controllers
{
    public class HomeController : Controller
    {
        PointsToRoadSnapper routePointsGetter = new PointsToRoadSnapper();
        private GeneratorContext context = new GeneratorContext();
        private LocationSeeder seeder = new LocationSeeder();
        PositionInitializer positionInitializer = new PositionInitializer();
        TrafficGenerator trafficGenerator = new TrafficGenerator();
        // GET: Home
        public ActionResult Index()
        {  
            return View();
        }
        public ActionResult RenderMap()
        {

            AllHumansPositions model = routePointsGetter.SnapPointsToRoad(context);
            
            
            return View(model);
        }
        public ActionResult SeedDatabaseWithLocations()
        {
            seeder.SeedDatabaseWithLocations(context);
            return RedirectToAction("Index");
        }
        
        public ActionResult GenerateTrafic()
        {
            List<string> Urls = trafficGenerator.generateTrafficUrls(context);
            foreach (string i in Urls)
            {
               
                positionInitializer.SaveRouteInDb(context, i);
            }
            return RedirectToAction("Index");
        }

    }
}