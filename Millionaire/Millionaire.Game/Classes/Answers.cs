using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millionaire.Game.Classes
{
    public class Answers
    {
        public string Answer { get; set; }
        public bool Res { get; set; }

        public Answers()
        {
            Answer = "";
            Res = false;
        }

        public Answers(string ans, bool res)
        {
            this.Answer = ans;
            this.Res = res;
        }

    }
}