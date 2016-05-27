using System.Web.Mvc;

namespace StudentTrackASP.Net.Controllers
{
    using System.Threading;

    using StudentTrackASP.Net.Models;

    public class JPController : Controller
    {

        public ActionResult Hallo2()
        {
            return this.Content("<h1>Mijn pagina</h1>" + "<p>Hallo</p>");
        }
        public ActionResult Hallo()
        {
            WeerModel weer = new WeerModel()
            {
                City = "Ede",
                MinTemp = 276.597M,
                MaxTemp = 276.597M
            };

            return this.View(weer);

        }

        public ActionResult AddWeer()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddWeer(WeerModel model)
        {
            Thread.Sleep(5000);
                
            if (this.ModelState.IsValid)
            {
                return this.Content("weer info : " + model.City + ": " + model.MaxTemp);
            }
            return this.View();
        }


    }
}