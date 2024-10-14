using KazanSession5Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KazanSession5Api.Controllers
{
    public class tempWellLayer
    {
        public int Id { get; set; }
        public int WellId { get; set; }
        public int RockTypeId { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public string RockName { get; set; }
        public string BackgroundColor { get; set; }
    }

    public class tempWell
    {
        public int Id { get; set; }
        public int WellTypeId { get; set; }
        public string WellName { get; set; }
        public int GasOilDepth { get; set; }
        public int Capacity { get; set; }
        public List<tempWellLayer> WellLayers { get; set; } = new List<tempWellLayer>();
        public string WellTypeName { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WellController : Controller
    {
        Wsc2019Session5Context context = new Wsc2019Session5Context();

        [HttpGet]
        public IActionResult GetWell()
        {
            try
            {
                var wells = context.Wells
                    .Select(x => new
                    {
                        x.Id,
                        x.WellTypeId,
                        x.WellName,
                        x.GasOilDepth,
                        x.Capacity,
                        wellLayers = x.WellLayers.Select(y => new
                        {
                            y.Id,
                            y.WellId,
                            y.RockTypeId,
                            y.StartPoint,
                            y.EndPoint,
                            rockName = y.RockType.Name,
                            rockColor = y.RockType.BackgroundColor
                        }),
                        wellTypeName = x.WellType.Id
                    });

                return Ok(wells);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public IActionResult CreateWell(tempWell well)
        {
            try
            {
                var newWell = new Well
                {
                    WellTypeId = well.WellTypeId,
                    WellName = well.WellName,
                    GasOilDepth = well.GasOilDepth,
                    Capacity = well.Capacity
                };
                context.Wells.Add(newWell);
                context.SaveChanges();

                var wellLayers = well.WellLayers.Select(x => new WellLayer
                {
                    WellId = newWell.Id,
                    RockTypeId = x.RockTypeId,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint
                })
                    .ToList();


                context.WellLayers.AddRange(wellLayers);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateWell(tempWell well)
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

                var wellLayers = well.WellLayers.Select(x => new WellLayer
                {
                    Id = x.Id,
                    WellId = x.WellId,
                    RockTypeId = x.RockTypeId,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint
                })
                    .ToList();


                context.Wells.Add(newWell);
                context.WellLayers.AddRange(wellLayers);
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
