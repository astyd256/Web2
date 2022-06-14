using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab_2._4.Models;

namespace lab_2._4.Controllers;

public class Home : Controller
{
    private readonly ILogger<Home> _logger;

    public Home(ILogger<Home> logger)
    {
        _logger = logger;
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
}
