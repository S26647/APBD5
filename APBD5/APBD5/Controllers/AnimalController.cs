using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal { Id = 1, Name = "Hector", Category = "Dog", Mass = 7.5, FurColor = "Black" },
        new Animal { Id = 2, Name = "Filemon", Category = "Cat", Mass = 4, FurColor = "Black"},
        new Animal { Id = 3, Name = "Herring", Category = "Dog", Mass = 12.3, FurColor = "White"}
    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = _animals.FirstOrDefault(s => s.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(s => s.Id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(s => s.Id == id);
        if (animalToDelete == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}