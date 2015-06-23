using System;
using System.Xml.Serialization;

namespace Millionaire.Game.Code
{
    public class Question
    {
        [XmlElement("Question")]
        public string Issue { get; set; }
        [XmlElement("Answers")]
        public MyAnswer[] Answer { get; set; }

        public Question(string quest, MyAnswer[] answer)
        {
            this.Answer = answer;
            this.Issue = quest;
        }

        public Question()
        {
            Issue = String.Empty;
            Answer = new MyAnswer[4];
        }
    }
}