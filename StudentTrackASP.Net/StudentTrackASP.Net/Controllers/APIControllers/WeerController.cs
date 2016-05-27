namespace StudentTrackASP.Net.Controllers.APIControllers
{
    using System.Web.Http;

    using StudentTrackASP.Net.Models;

    public class WeerController : ApiController
    {

        public WeerModel Get()
            {

            WeerModel model = new WeerModel()
            {
                City = "Veenendaal",
                MaxTemp = 280.5M,
                MinTemp = 275.6M
            };
            return model;

        }

        public void Post(WeerModel model)
        {

        }

    }
}
