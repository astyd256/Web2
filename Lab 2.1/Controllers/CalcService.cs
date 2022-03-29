using Microsoft.AspNetCore.Mvc;

namespace lab_2._1.Controllers
{
    public class CalcService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassUsingModel()
        {
            var model = new lab_2._1.Models.RandModel();
            return View(model);
        }

        public IActionResult PassUsingViewData()
        {
            var model = new lab_2._1.Models.RandModel();
            ViewData["firstval"] = model.firstval;
            ViewData["secondval"] = model.secondval;
            ViewData["Add"] = model.Add();
            ViewData["Sub"] = model.Sub();
            ViewData["Mult"] = model.Mult();
            ViewData["Div"] = model.Div();
            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            var model = new lab_2._1.Models.RandModel();
            ViewBag.firstval = model.firstval;
            ViewBag.secondval = model.secondval;
            ViewBag.Add = model.Add();
            ViewBag.Sub = model.Sub();
            ViewBag.Mult = model.Mult();
            ViewBag.Div = model.Div();
            return View();
        }
        public IActionResult AccesServiceDirectly()
        {
            return View();
        }
    }
}
