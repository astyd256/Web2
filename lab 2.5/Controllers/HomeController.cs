using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab_2._5.Models;

namespace lab_2._5.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
