using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab_2._4.Models;

namespace lab_2._4.Controllers;

public class Controls : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TextBox()
    {
        ViewBag.Submit = false;
        return View();
    }
    [HttpPost]
    public IActionResult TextBox(string data)
    {
        ViewBag.Submit = true;
        ViewBag.data = data;
        return View();
    }
    public IActionResult TextArea()
    {
        ViewBag.Submit = false;
        return View();
    }
    [HttpPost]
    public IActionResult TextArea(string data)
    {
        ViewBag.Submit = true;
        ViewBag.data = data;
        return View();
    }
    public IActionResult CheckBox()
    {
        ViewBag.Submit = false;
        return View();
    }
    [HttpPost]
    public IActionResult CheckBox(bool isActive)
    {
        ViewBag.Submit = true;
        ViewBag.isActive = isActive;
        return View();
    }
    public IActionResult Radio()
    {
        ViewBag.Submit = false;
        return View();
    }
    [HttpPost]
    public IActionResult Radio(string data)
    {
        ViewBag.Submit = true;
        ViewBag.data = data;
        return View();
    }
    public IActionResult DropDownList()
    {
        ViewBag.Submit = false;
        return View();
    }
    [HttpPost]
    public IActionResult DropDownList(string data)
    {
        ViewBag.Submit = true;
        ViewBag.data = data;
        return View();
    }
    public IActionResult ListBox()
    {
        ViewBag.Submit = false;
        return View();
    }
    [HttpPost]
    public IActionResult ListBox(string data)
    {
        ViewBag.Submit = true;
        ViewBag.data = data;
        return View();
    }

}
