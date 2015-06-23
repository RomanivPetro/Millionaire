
namespace Millionaire.Game.Code
{
    public class MyAnswer
    {
        public string Answer { get; set; }
        public bool Res { get; set; }

        public MyAnswer()
        {
            Answer = "";
            Res = false;
        }

        public MyAnswer(string ans, bool res)
        {
            this.Answer = ans;
            this.Res = res;
        }

    }
}