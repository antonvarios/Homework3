using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework3.Models {
    public class PersonViewModel {
        public string UserName { get; set; }
        public List<QuestionsList.Question> AnsweredQuestions { get; set; }
    }
}