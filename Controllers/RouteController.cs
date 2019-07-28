using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;
using System.IO;
using ItineroRouterApi.Services;

namespace ItineroRouterApi.Controllers
{

	//http://localhost:54596/api/route?latitudeStart=56.747057&longitudeStart=60.566096&latitudeEnd=56.8344576&longitudeEnd=60.6232576
	[Route("api/[controller]")]
    public class RouteController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get(float latitudeStart, float longitudeStart, float latitudeEnd, float longitudeEnd)
        {
			var profile = Vehicle.Car.Fastest(); // the default OSM car profile.

			var router = RouterService.router;
			// create a routerpoint from a location.
			// snaps the given location to the nearest routable edge.56.747057, 60.566096
			var start = router.Resolve(profile, latitudeStart, longitudeStart);
			var end = router.Resolve(profile, latitudeEnd, longitudeEnd);
			//var start = router.Resolve(profile, 56.833510f, 60.615870f);
			//var end = router.Resolve(profile, 56.8344576f, 60.6232576f);//56.833510, 60.615870

			// calculate a route.
			var route = router.Calculate(profile, start, end);

			return route.ToGeoJson();

			//using (var writer = new StreamWriter(@"route.geojson"))
			//{
			//	route.WriteGeoJson(writer);
			//}
		}

    
    }
}
