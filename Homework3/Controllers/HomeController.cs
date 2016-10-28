using Homework3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Questions() {
            QuestionsList.Question model = null;
            //get user
            PersonViewModel p = HttpContext.Session[User.Identity.Name] as PersonViewModel;
            if (model == null) {
                model = new QuestionsList.Question();
            }

            if (p == null) {
                p = new PersonViewModel();
                p.UserName = User.Identity.Name;
                p.AnsweredQuestions = new List<QuestionsList.Question>();
                Session[p.UserName] = p;
            }

            //create question for users


            Random r = new Random();
            QuestionsList.Question chosenQuestion = null;
            while (chosenQuestion == null && p.AnsweredQuestions.Count < QuestionsList.QList.Length) {
                int i = r.Next(0, QuestionsList.QList.Length);
                QuestionsList.Question q = QuestionsList.QList[i];
                bool qExists = false;
                foreach (QuestionsList.Question question in p.AnsweredQuestions) {
                    if (question.QuestionId == q.QuestionId) {
                        qExists = true;
                        break;
                    }
                }
                if (!qExists) {
                    chosenQuestion = q;
                }
            }

            if (chosenQuestion == null) {
                model = new QuestionsList.Question() {
                    QuestionId = -1,
                    QuestionBody = "",
                    Answers = new List<QuestionsList.Answer>(),
                    ValidationMessage = "All questions complete so far..."
                };
            }
            else {
                model = new QuestionsList.Question() {
                    QuestionId = chosenQuestion.QuestionId,
                    QuestionBody = chosenQuestion.QuestionBody,
                    Answers = chosenQuestion.Answers,
                };
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Questions(QuestionsList.Question model) {
            model.NumberOfAttempts++;
            if (model.SelectedAnswer == QuestionsList.QList[model.QuestionId].CorrectAnswerIndex) {
                //get user
                PersonViewModel p = HttpContext.Session[User.Identity.Name] as PersonViewModel;

                if (p == null) {
                    p = new PersonViewModel();
                    p.UserName = User.Identity.Name;
                    p.AnsweredQuestions = new List<QuestionsList.Question>();
                }

                p.AnsweredQuestions.Add(
                    new QuestionsList.Question() {
                        QuestionId = QuestionsList.QList[model.QuestionId].QuestionId,
                        QuestionBody = QuestionsList.QList[model.QuestionId].QuestionBody,
                        Answers = QuestionsList.QList[model.QuestionId].Answers,
                        SelectedAnswer = model.SelectedAnswer,
                        NumberOfAttempts = model.NumberOfAttempts
                    });
                Session[p.UserName] = p;


                Random r = new Random();
                QuestionsList.Question chosenQuestion = null;

               
                while (chosenQuestion == null && p.AnsweredQuestions.Count < QuestionsList.QList.Length) {
                    int i = r.Next(0, QuestionsList.QList.Length);
                    QuestionsList.Question q = QuestionsList.QList[i];
                    bool qExists = false;
                    foreach (QuestionsList.Question question in p.AnsweredQuestions) {
                        if (question.QuestionId == q.QuestionId) {
                            qExists = true;
                            break;
                        }
                    }
                    if (!qExists) {
                        chosenQuestion = q;
                    }
                }

                if (chosenQuestion == null) {
                    model = new QuestionsList.Question() {
                        QuestionId = -1,
                        QuestionBody = "",
                        Answers = new List<QuestionsList.Answer>(),
                        ValidationMessage = "All questions complete so far..."
                    };
                }
                else {
                    model = new QuestionsList.Question() {
                        QuestionId = chosenQuestion.QuestionId,
                        QuestionBody = chosenQuestion.QuestionBody,
                        Answers = chosenQuestion.Answers,
                        NumberOfAttempts = model.NumberOfAttempts,
                        ValidationMessage = "Correct. Here's another question:"
                    };
                }
            }
            else {
                model = new QuestionsList.Question() {
                    QuestionId = QuestionsList.QList[model.QuestionId].QuestionId,
                    QuestionBody = QuestionsList.QList[model.QuestionId].QuestionBody,
                    Answers = QuestionsList.QList[model.QuestionId].Answers,
                    SelectedAnswer = model.SelectedAnswer,
                    NumberOfAttempts = model.NumberOfAttempts,
                    ValidationMessage = "Incorrect. Please try again..."
                };

            }

            ModelState.Clear();

            return View(model);
        }


        [Authorize]
        public ActionResult Results() {
            //get user
            PersonViewModel p = HttpContext.Session[User.Identity.Name] as PersonViewModel;

            if (p == null) {
                p = new PersonViewModel();
                p.UserName = User.Identity.Name;
                p.AnsweredQuestions = new List<QuestionsList.Question>();
            }
            Session[p.UserName] = p;



            return View(p);
        }
    }
}