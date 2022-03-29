using Microsoft.AspNetCore.Mvc;
using lab_2._2.Models;

namespace lab_2._2.Controllers
{
    public class Calc : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manual()
        {
            return View();
        }
        public IActionResult ManualWithSeprateHandlers()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ModelBindingParameters()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingParameters(int number1, string opperand, int number2)
        {
            ViewBag.number1 = number1;
            ViewBag.number2 = number2;
            ViewBag.opperand = opperand;
            return View("ModelResult");
        }
        [HttpGet]
        public IActionResult ModelBindingSeparateModel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingSeparateModel(MathModel model)
        {
            ViewBag.number1 = model.number1;
            ViewBag.number2 = model.number2;
            ViewBag.opperand = model.opperand;
            return View("ModelResult");
        }


    }
}
