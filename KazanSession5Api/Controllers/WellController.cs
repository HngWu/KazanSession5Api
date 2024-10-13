using KazanSession5Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KazanSession5Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WellController : Controller
    {

        public class TempWell
        {
            public long Id { get; set; }

            public long WellTypeId { get; set; }

            public string WellName { get; set; } = null!;

            public long GasOilDepth { get; set; }

            public long Capacity { get; set; }

        }


        Wsc2019Session5Context context = new Wsc2019Session5Context();

        [HttpGet]
        public IActionResult GetWell()
        {
            try
            {
                var wells = context.Wells.ToList();


                return Ok(wells);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }

        [HttpPost]
        public IActionResult CreateWell(TempWell well)
        {
            try
            {
                var newWell = new Well
                {
                    Id = well.Id,
                    WellTypeId = well.WellTypeId,
                    WellName = well.WellName,
                    GasOilDepth = well.GasOilDepth,
                    Capacity = well.Capacity
                };

                context.Wells.Add(newWell);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }




    }
}
