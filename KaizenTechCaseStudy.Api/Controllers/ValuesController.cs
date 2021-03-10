using KaizenTechCaseStudy.Dal.Manager.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KaizenTechCaseStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (var context = new DatabaseContext())
            {
                //Creates the database if not exists
                context.Database.EnsureCreated();
            }
            return Ok();
        }
    }
}
