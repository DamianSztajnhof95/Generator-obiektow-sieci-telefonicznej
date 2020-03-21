using Generator.DAL;
using Generator.Infrastructure;
using Generator.Models;
using Generator.Models.JSONhelpers;
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
        private PointsToRoadSnapper routePointsGetter = new PointsToRoadSnapper();
        private GeneratorContext context = new GeneratorContext();
        private LocationSeeder seeder = new LocationSeeder();
        private PositionInitializer positionInitializer = new PositionInitializer();        
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
            return View();
        }
        [HttpPost]
        public ActionResult SeedDatabaseWithLocations(LocationViewModel locationViewModel)
        {            
                seeder.SeedDatabaseWithLocations(context, locationViewModel.Town,locationViewModel.radius);
                return RedirectToAction("Index");         
        }
        public ActionResult GenerateTrafic()
        {                                  
            return View();
        }
        [HttpPost]
        public ActionResult GenerateTrafic(int numberOfObjects)
        {
            positionInitializer.SaveRouteInDb(context,numberOfObjects);
            return RedirectToAction("Index");
        }
        public ActionResult CreateHumanType()
        {            
            HumanTypeViewModel humanTypeViewModel = new HumanTypeViewModel();
            return View(humanTypeViewModel);
        }
        [HttpPost]
        public ActionResult CreateHumanType(HumanTypeViewModel humanTypeViewModel)
        {            
            if (!ModelState.IsValid)
            {
                return View(humanTypeViewModel);
            }
            else
            {                
                HumanType humanType = new HumanType();
                var humanLikings = new List<HumanTypeLiking>();
                humanType.HumanTypeName = humanTypeViewModel.HumanTypeName;
                humanType.color = humanTypeViewModel.color;
                humanType.numberOfLocations = humanTypeViewModel.NumberOfLocations;
                string[] likings = humanTypeViewModel.HumanLikings.Split(' ');
                int[] probabilities = humanTypeViewModel.probabilities.Split(' ').Select(int.Parse).ToArray();
                if (likings.Length == probabilities.Length)
                {
                    for (int i = 0; i < likings.Length; i++)
                    {
                        humanLikings.Add(new HumanTypeLiking { humanTypeLikingName = likings[i],
                            probability = probabilities[i] });
                    }
                    humanType.humanLikings = humanLikings;
                    
                    context.humanTypes.AddOrUpdate(humanType);
                    context.SaveChanges();
                }
                else
                {
                    return View(humanTypeViewModel);
                }               
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult ViewHumanPositions()
        {
            var model = new List<PositionListViewModel>();
            var humansToShow = context.People;
            List<StartLocation2> startLocations = context.StartLocations.ToList();
            List<EndLocation2> endLocations = context.EndLocations.ToList();
            foreach (var h in humansToShow)
            {
                List<Route> humanRoutes = context.Routes.Where(c => c.HumanId == h.HumanId).ToList();
                foreach (var r in humanRoutes)
                {
                    r.legs = context.Legs.Where(c => c.RouteId == r.RouteId).ToList();
                    foreach (var s in r.legs)
                    {
                        s.steps = context.Steps.Where(c => c.LegId == s.LegId).ToList();
                        foreach (var step in s.steps)
                        {

                            step.start_location = startLocations.Where(c => c.StartLocation2Id == step.start_location.StartLocation2Id).FirstOrDefault();

                        }
                    }

                }
                h.HumanRoutes = humanRoutes;

                foreach (var r in h.HumanRoutes)
                {
                    foreach (var l in r.legs)
                    {
                        foreach (var s in l.steps)
                        {

                            model.Add(new PositionListViewModel { lat = s.start_location.lat, lng = s.start_location.lng, ObjectId = h.HumanId, time = s.actualTime });

                        }
                    }
                }
            }



            return View(model);
        }
    }
  
}