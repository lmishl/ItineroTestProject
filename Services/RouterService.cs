using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;
using System.IO;

namespace ItineroRouterApi.Services
{
	public class RouterService
	{
		public static Router router;
		static RouterService()
		{
			RouterDb routerDb = null;
			using (var stream = new FileInfo(@"ural.routerdb").OpenRead())
			{
				routerDb = RouterDb.Deserialize(stream);
			}
			router = new Router(routerDb);
		}

		public void Init()
		{ }

	}
}
