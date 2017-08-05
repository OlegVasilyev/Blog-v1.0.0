using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.ViewModels
{
    public class Quiz
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateBirt { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public int NumberTelephone { get; set; }
        [Required]
        public bool Smoke { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string About { get; set; }
        public bool SendEmail { get; set; }
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