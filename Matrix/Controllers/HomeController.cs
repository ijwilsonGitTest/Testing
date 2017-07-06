using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace Matrix.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient c = new HttpClient();
            HttpResponseMessage r = await c.GetAsync("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Washington,DC&destinations=New+York+City,NY&key=AIzaSyDeYXutpFUZil3ILjdmM6Szqq6amOmL8MM");
            var s = r.StatusCode;
            var cx = await r.Content.ReadAsStringAsync();
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var routes_list =
                   json_serializer.DeserializeObject(cx);
            return View();
        }
    }
}