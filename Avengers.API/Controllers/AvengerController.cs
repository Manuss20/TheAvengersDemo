using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Avengers.Models;
using Microsoft.AspNetCore.Cors;

namespace Avengers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvengerController : ControllerBase
    {
        public static List<Avenger> avengers = new List<Avenger>
        {
            new Avenger {
                Id = 1, 
                Name = "Spider Man", 
                FirstName = "Peter", 
                LastName = "Parker", 
                Place = "New York City"
            },
            new Avenger {
                Id = 2, 
                Name = "Ironman", 
                FirstName = "Tony", 
                LastName = "Stark", 
                Place = "Long Island"
            },
            new Avenger {
                Id = 3, 
                Name = "Captain America", 
                FirstName = "Steve", 
                LastName = "Rogers", 
                Place = "New York City"
            },
            new Avenger {
                Id = 4, 
                Name = "Thor", 
                FirstName = "Thor", 
                LastName = "Odinson", 
                Place = "New Asgard"
            },
            new Avenger {
                Id = 5, 
                Name = "Hulk", 
                FirstName = "Robert Bruce", 
                LastName = "Banner", 
                Place = "Manhattan"
            },
            new Avenger {
                Id = 6, 
                Name = "Ant-Man", 
                FirstName = "Henry Jonathan", 
                LastName = "Pym", 
                Place = "New York City"
            },
            new Avenger {
                Id = 7, 
                Name = "Hawkeye", 
                FirstName = "Clinton Francis", 
                LastName = "Barton", 
                Place = "New York City"
            },
            new Avenger {
                Id = 8, 
                Name = "Black Widow", 
                FirstName = "Natasha Alianovna", 
                LastName = "Romanoff", 
                Place = "New York City"
            },
            new Avenger {
                Id = 9, 
                Name = "Scarlet Witch", 
                FirstName = "Wanda", 
                LastName = "Maximoff", 
                Place = "New York City"
            },
            new Avenger {
                Id = 10, 
                Name = "Scarlet Witch", 
                FirstName = "Wanda", 
                LastName = "Maximoff", 
                Place = "New York City"
            },
            new Avenger {
                Id = 11, 
                Name = "Dr. Stephen Strange", 
                FirstName = "Stephen", 
                LastName = "Strange", 
                Place = "Manhattan"
            },
            new Avenger {
                Id = 12, 
                Name = "Star-Lord", 
                FirstName = "Peter", 
                LastName = "Quill", 
                Place = "Universe"
            },
            new Avenger {
                Id = 13, 
                Name = "Gamora", 
                FirstName = "Zen Whoberi", 
                LastName = "Ben Titan", 
                Place = "Universe"
            },
            new Avenger {
                Id = 14, 
                Name = "Gamora", 
                FirstName = "Zen Whoberi", 
                LastName = "Ben Titan", 
                Place = "Universe"
            },
            new Avenger {
                Id = 15, 
                Name = "Rocket Raccoon", 
                FirstName = "Rocket", 
                LastName = "Raccoon", 
                Place = "Universe"
            },
            new Avenger {
                Id = 16, 
                Name = "Nebula", 
                FirstName = "Nebula", 
                LastName = "Unknown", 
                Place = "Universe"
            },
            new Avenger {
                Id = 17, 
                Name = "Groot", 
                FirstName = "Nebula", 
                LastName = "Unknown", 
                Place = "Universe"
            },
            new Avenger {
                Id = 18, 
                Name = "Drax", 
                FirstName = "Arthur Sampson", 
                LastName = "Douglas", 
                Place = "Universe"
            },
            new Avenger {
                Id = 19, 
                Name = "Mantis", 
                FirstName = "Mantis", 
                LastName = "Unknown", 
                Place = "Universe"
            },
            new Avenger {
                Id = 20, 
                Name = "Loki", 
                FirstName = "Loki", 
                LastName = "Laufeyson", 
                Place = "Universe"
            }
        };
        
        [HttpGet]
        public async Task<ActionResult<List<Avenger>>> Get()
        {
            return Ok(await Task.FromResult(avengers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avenger>> Get(int id)
        {
            var avenger = avengers.Find(h => h.Id == id);
            if (avenger == null)
                return BadRequest("Avenger not found");
            return Ok(await Task.FromResult(avenger));
        }

        [HttpPost]
        public async Task<ActionResult<List<Avenger>>> AddAvenger(Avenger avenger)
        {
            avengers.Add(avenger);
            return Ok(await Task.FromResult(avengers));
        }

        [HttpPut]
        public async Task<ActionResult<List<Avenger>>> UpdateAvenger(Avenger request)
        {
            var avenger = avengers.Find(h => h.Id == request.Id);
            if (avenger == null)
                return BadRequest("Avenger not found");
            
            avenger.Name = request.Name;
            avenger.FirstName = request.FirstName;
            avenger.LastName = request.LastName;
            avenger.Place = request.Place;
            
            return Ok(await Task.FromResult(avengers));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Avenger>>> Delete(int id)
        {
            var avenger = avengers.Find(h => h.Id == id);
            if (avenger == null)
                return BadRequest("Avenger not found");
            avengers.Remove(avenger);
            return Ok(await Task.FromResult(avenger));
        }

    }
}