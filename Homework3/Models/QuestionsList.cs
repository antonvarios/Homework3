using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework3.Models {
    public static class QuestionsList {
        public class Question {
            public int QuestionId { get; set; }
            [Display(Name = "Question")]
            public string QuestionBody { get; set; }
            public List<Answer> Answers { get; set; }
            public int CorrectAnswerIndex { get; set; }
            public int SelectedAnswer { get; set; }
            public string ValidationMessage { get; set; }
            public int NumberOfAttempts { get; set; }
        }

        public class Answer {
            public int AnswerId { get; set; }
            public string AnswerBody { get; set; }

            public Answer(int id, string body) {
                AnswerId = id;
                AnswerBody = body;
            }
        }

        public static Question[] QList = new Question[] {
            new Question() {
                QuestionId = 0,
                QuestionBody = "What color is the sky?",
                Answers = new List<Answer>(){
                    new Answer(0,"Blue"),
                    new Answer(1, "Yellow"),
                    new Answer(2, "Magenta"),
                    new Answer(3, "Neon Pink")
                },
                CorrectAnswerIndex = 0
            },
            new Question() {
                QuestionId = 1,
                QuestionBody = "How many wheels does a bicycle have?",
                Answers = new List<Answer>(){
                    new Answer(0,"1"),
                    new Answer(1, "2"),
                    new Answer(2, "3"),
                    new Answer(3, "4")
                },
                CorrectAnswerIndex = 1
            },
            new Question() {
                QuestionId = 2,
                QuestionBody = "What part of the body does an Optometrist take care of?",
        
                Answers = new List<Answer>(){
                    new Answer(0,"Heart"),
                    new Answer(1, "Lungs"),
                    new Answer(2, "Eyes"),
                    new Answer(3, "Feet")
                },
                CorrectAnswerIndex = 2
            },
            new Question() {
                QuestionId = 3,
                QuestionBody = "What is the capital of Florida?",
                Answers = new List<Answer>(){
                    new Answer(0,"Miami"),
                    new Answer(1, "Naples"),
                    new Answer(2, "Jacksonville"),
                    new Answer(3, "Tallahassee")
                },
                CorrectAnswerIndex = 3
            }
        };
    }
}