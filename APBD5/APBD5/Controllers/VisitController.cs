using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<Visit> _visits = new()
    {
        new Visit { Date = new DateTime(2020, 1, 12), AnimalId = 1, Description = "deworming", Price = 250 },
        new Visit { Date = new DateTime(2021, 12, 21), AnimalId = 1, Description = "tooth removal", Price = 190 },
        new Visit { Date = new DateTime(2020, 2, 13), AnimalId = 2, Description = "deworming", Price = 250 },
        new Visit { Date = new DateTime(2019, 3, 16), AnimalId = 2, Description = "control visit", Price = 100 },
        new Visit { Date = new DateTime(2022, 9, 7), AnimalId = 3, Description = "paw pain", Price = 350 },
        new Visit { Date = new DateTime(2017, 3, 2), AnimalId = 3, Description = "tooth removal", Price = 190 }
    };
    
    [HttpGet("{id:int}")]
    public IActionResult GetVisits(int id)
    {
        var visit = _visits.FindAll(s => s.AnimalId == id);
        if (visit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(visit);
    }

    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}