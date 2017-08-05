using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateBirt { get; set; }
        public string Sex { get; set; }
        public string NumberTelephone { get; set; }
        public bool Smoke { get; set; }
        public string Position { get; set; }
        public string About { get; set; }
        public override string ToString()
        {
            string smoke = (Smoke) ? "Yes" : "No";
            string result = String.Format("Hello, {0}! \n Result:\n Name: {1}\n" +
                                                                "Surname: {2}\n" +
                                                                 "E-mail: {3}\n" +
                                                                   "Date: {4}\n" +
                                                                    "Sex: {5}\n" +
                                                                  "Smoke: {5}\n" +
                                                              "Telephone: {5}\n" +
                                                               "Position: {5}\n" +
                                                                  "About: {5}\n", Name, Name, Surname, Email, DateBirt, Sex, smoke, NumberTelephone, Position, About);

            return result;
        }
    }
}