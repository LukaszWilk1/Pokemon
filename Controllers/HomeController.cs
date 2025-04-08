using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Pokemon.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, AppDbContext context, HttpClient httpClient)
    {
        _logger = logger;
        _context = context;
        _httpClient = httpClient;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Trainers()
    {
        var trainers = _context.Trainers.ToList();
        return View(trainers);
    }

    public async Task<IActionResult> Pokedex(string sortBy, string search, int page=1)
    {
        var apiUrl = $"https://pokeapi.co/api/v2/pokemon/?offset={(page-1)*20}&limit=20";
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
    
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();

            var pokemonData = JsonConvert.DeserializeObject<PokemonResponse>(data);

            if (!string.IsNullOrEmpty(search))
            {
                pokemonData.Results = pokemonData.Results
                    .Where(x => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if(sortBy=="nameAscending"){
                pokemonData.Results = pokemonData.Results.OrderBy(x => x.Name).ToList();
            }
            else if(sortBy=="nameDescending")
            {
                pokemonData.Results = pokemonData.Results.OrderBy(x => x.Name).Reverse().ToList();
            }
            ViewBag.sortBy = sortBy;
            ViewBag.Page = page;

            return View(pokemonData);
        }
        else
        {
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult FormTest(TrainerData trainerData)
    {
        var ageInDays = (DateTime.Now-trainerData.Birthday).Days;
        var CalculatedAge = ageInDays/365;

        if(CalculatedAge > 0)
        {
            Trainer trainer = new Trainer
            {
                Name = trainerData.Name,
                Surname = trainerData.Surname,
                Age = CalculatedAge,
                Birthday = DateTime.SpecifyKind(trainerData.Birthday, DateTimeKind.Utc),
                LegalAge = CalculatedAge > 18 ? true : false
            };
        
        _context.Trainers.Add(trainer);
        _context.SaveChanges();
        Console.WriteLine("Dane dodane");
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int Id)
    {
        var trainer = _context.Trainers.SingleOrDefault(x => x.Id == Id);

        if(trainer != null)
        {
            return View(trainer);
        }
        else
        {
            TempData["errorMessage"] = "Trainer not aviable";
            return RedirectToAction("Trainers");
        }
    }

    [HttpPost]
    public IActionResult Edit(Trainer trainerData)
    {

        var trainer = new Trainer
        {
            Id = trainerData.Id,
            Name = trainerData.Name,
            Surname = trainerData.Surname,
            Age = trainerData.Age,
            Birthday = DateTime.SpecifyKind(trainerData.Birthday, DateTimeKind.Utc),
            LegalAge = trainerData.LegalAge
        };

        _context.Trainers.Update(trainer);
        _context.SaveChanges();
        return RedirectToAction("Trainers");
    }
    
    public IActionResult Delete(int Id)
    {
        var trainer = _context.Trainers.SingleOrDefault(x => x.Id == Id);

        if(trainer != null)
        {
            _context.Trainers.Remove(trainer);
            _context.SaveChanges();
        }

        return RedirectToAction("Trainers");
    }

    public async Task<IActionResult> Pokemon(string name)
    {
        var apiUrl = $"https://pokeapi.co/api/v2/pokemon/{name}";
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();

            var pokemonData = JsonConvert.DeserializeObject<SimplePokemon>(data);
            return View(pokemonData);
        }
        else
        {
            return View("NotFound");
        }
    }
}
