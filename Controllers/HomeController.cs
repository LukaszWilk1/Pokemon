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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult FormTest(TrainerData trainerData)
    {
        Console.WriteLine($"Dane trenera: imie = ${trainerData.Name}, nazwisko = {trainerData.Surname}, data urodzenia = {trainerData.Birthday.ToString("dd.MM.yyyy")}");
        Console.WriteLine(Int32.Parse((DateTime.Now - trainerData.Birthday).ToString().Split(".")[0])/365);

        var CalculatedAge = Int32.Parse((DateTime.Now - trainerData.Birthday).ToString().Split(".")[0])/365;
        
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

        return RedirectToAction("Index");
    }
}
