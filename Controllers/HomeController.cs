using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;

namespace Pokemon.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
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
}
