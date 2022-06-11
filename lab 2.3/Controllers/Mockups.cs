using Microsoft.AspNetCore.Mvc;
using lab_2._3.Models;

namespace lab_2._3.Controllers
{
    public class Mockups : Controller
    {
        private QuizModel? quizModel;
        private void ShowQuiz ()
        {
            ViewBag.showQuiz = true;
            ViewBag.quizDisplay = "inline-block";
            ViewBag.resultDisplay = "none";
            ViewBag.numberOne = quizModel.numberOne[quizModel.currentQuestion];
            ViewBag.numberTwo = quizModel.numberTwo[quizModel.currentQuestion];
            ViewBag.operand = quizModel.operand[quizModel.currentQuestion];         
        }

        private void ShowResults ()
        {
            ViewBag.showQuiz = false;
            ViewBag.numberOne = quizModel.numberOne;
            ViewBag.numberTwo = quizModel.numberTwo;
            ViewBag.operand = quizModel.operand;
            ViewBag.correctAnswersAmount = quizModel.correctAnswersAmount;
            ViewBag.answersAmount = quizModel.answersAmount;
            ViewBag.userAnswers = quizModel.userAnswers;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("QuizModel"))
            {
                quizModel = HttpContext.Session.Get<QuizModel>("QuizModel");
            }
            else
            {
                quizModel = new QuizModel();
                HttpContext.Session.Set<QuizModel>("QuizModel", quizModel);
            }

            return View();
        }
        
        [HttpPost]
        public IActionResult Quiz(int answer, string button)
        {
            if (HttpContext.Session.Keys.Contains("QuizModel"))
            {
                quizModel = HttpContext.Session.Get<QuizModel>("QuizModel");
                if (button == "next")
                {
                    if (quizModel.currentQuestion == quizModel.answersAmount - 1)
                    {
                        quizModel.CheckAnswer(answer);
                        ShowResults();
                        quizModel.GetNextQuestion();
                        HttpContext.Session.Set<QuizModel>("QuizModel", quizModel);
                    }
                    else
                    {
                        quizModel.CheckAnswer(answer);
                        quizModel.GetNextQuestion();
                        if (quizModel.currentQuestion != quizModel.answersAmount) ShowQuiz();
                        HttpContext.Session.Set<QuizModel>("QuizModel", quizModel); 
                    }
                }
                else if (button == "finish")
                {
                    quizModel.CheckAnswer(answer);
                    ShowResults();
                    quizModel.GetNextQuestion();
                    HttpContext.Session.Set<QuizModel>("QuizModel", quizModel); 
                }
            }
            else
            {
            quizModel = new QuizModel();
            HttpContext.Session.Set<QuizModel>("QuizModel", quizModel);
            ShowQuiz();
            }
            return View();
        }

        public IActionResult Quiz()
        {
            if (HttpContext.Session.Keys.Contains("QuizModel"))
            {
                quizModel = HttpContext.Session.Get<QuizModel>("QuizModel");

                if (ModelState.IsValid && quizModel != null)
                {
                    if (quizModel.currentQuestion == quizModel.answersAmount)
                    {
                        ShowResults();
                    }
                    else
                    {
                        ShowQuiz();
                    }
                }
                else
                {
                    return Content("Model is not valid!");
                }
            }
            else
            {
                QuizModel quizModel = new QuizModel();
                HttpContext.Session.Set<QuizModel>("QuizModel", quizModel);
                ShowQuiz();
            }  
            return View(); 
        }
    }
}
