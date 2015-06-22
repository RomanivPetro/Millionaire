using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Millionaire.Game.Classes
{

    public class Question
    {
        [XmlElement("Question")]
        public string Issue { get; set; }
        [XmlElement("Answers")]
        public Answers[] Answer { get; set; }

        public Question(string quest, Answers[] answer)
        {
            this.Answer = answer;
            this.Issue = quest;
        }

        public Question()
        {
            Issue = "";
            Answer = new Answers[15];
        }
    }
}