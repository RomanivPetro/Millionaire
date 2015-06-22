using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Game.Classes;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net.Mail;
using System.Net;

namespace Millionaire.Game
{
    public enum UsersChoice
    {
        AnswerA,
        AnswerB,
        AnswerC,
        AnswerD
    }

    public partial class MainWindow : System.Web.UI.Page
    {
        #region Private Fields
        private static Question[] _gameQuestions;
        private static int _count = 0;
        private Button[] _btnAnswers;
        private static bool _gameOver;
        private static bool _flagSend;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {                             
            InitButtons();
            if (_count == 0)
            {
                _gameQuestions = Deserialization();
                scoretable.Rows[15].BgColor = "#D2691E";
                LoadQuestions(_count);
                SetButnColor();
            }
            if (_flagSend)
            {
                btnHelp2.CssClass = "help2u";
                btnHelp2.Enabled = false;
            }
                      
        }

        #region Answer buttons event      
        protected void buttonA_Click(object sender, EventArgs e)
        {                         
            CheckAnswer(UsersChoice.AnswerA);                               
        }
        protected void buttonB_Click(object sender, EventArgs e)
        {                
            CheckAnswer(UsersChoice.AnswerB);
            
        }
        protected void buttonC_Click(object sender, EventArgs e)
        {                     
            CheckAnswer(UsersChoice.AnswerC);
        }
        protected void buttonD_Click(object sender, EventArgs e)
        {                    
            CheckAnswer(UsersChoice.AnswerD);
        }
        #endregion

        #region Help buttons event
        protected void btnHelp1_Click(object sender, EventArgs e)
        {
            DeleteTwoAnswer();
            btnHelp1.CssClass = "help1u";
            btnHelp1.Enabled = false;
        }
        protected void btnHelp2_Click(object sender, EventArgs e)
        {  
            btnHelp2.CssClass = "help2u";
            btnHelp2.Enabled = false;
        }
        protected void btnHelp3_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q="+_gameQuestions[_count].Issue +"')", true);
            btnHelp3.CssClass = "help3u";
            btnHelp3.Enabled = false;
        }
        #endregion

        private void CheckAnswer(UsersChoice choice)
        {     
            switch (choice)
            {
                case UsersChoice.AnswerA:
                    if (CheckResult(UsersChoice.AnswerA))
                    {                      
                        _count++;
                        LoadQuestions(_count);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;

                case UsersChoice.AnswerB:
                    if (CheckResult(UsersChoice.AnswerB))
                    {                       
                        _count++;
                        LoadQuestions(_count);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;

                case UsersChoice.AnswerC:
                    if (CheckResult(UsersChoice.AnswerC))
                    {                    
                        _count++;
                        LoadQuestions(_count);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;

                case UsersChoice.AnswerD:
                    if (CheckResult(UsersChoice.AnswerD))
                    {                     
                        _count++;
                        LoadQuestions(_count);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;              
            }

        }

        private bool CheckResult(UsersChoice choice)
        {
            return _gameQuestions[_count].Answer[(int)choice].Res == true;
        }

        private Question[] Deserialization()
        {
            Question[] questions;
            var xmlFormat = new XmlSerializer(typeof(Question[]));
            using (var fstream = new FileStream(Server.MapPath("/Resources/questions.xml"),
                FileMode.Open, FileAccess.Read, FileShare.None))
            {
                questions = (Question[])xmlFormat.Deserialize(fstream);
            }

            return questions;
        }

        private void LoadQuestions(int iteration)
        {
            if (_count < 15)
            {
                if (_count != 0)
                {
                    ChangeScore();
                }
                buttonA.Enabled = true;
                buttonB.Enabled = true;
                buttonC.Enabled = true;
                buttonD.Enabled = true;
                lblQuest.Text = _gameQuestions[iteration].Issue;
                buttonA.Text = _gameQuestions[iteration].Answer[0].Answer;
                buttonB.Text = _gameQuestions[iteration].Answer[1].Answer;
                buttonC.Text = _gameQuestions[iteration].Answer[2].Answer;
                buttonD.Text = _gameQuestions[iteration].Answer[3].Answer;
            }
            else
            {
                GameWin();
            }
           
        }

        private void ChangeScore()
        {         
            scoretable.Rows[15 - _count + 1].Attributes.Clear();
            scoretable.Rows[15 - _count + 1].Attributes.Add("class", "passedscore");
            scoretable.Rows[15 - _count].Attributes.Add("class", "currentscore");
        }

        private void GameWin()
        {
            lblQuest.Text = "Ти виграв!!   Твій виграш - " + GiveMoney().ToString() + " Рестарт?";
            lblQuest.Enabled = true;
            foreach (Button but in _btnAnswers)
            {
                but.Enabled = false;
            }
        }

        private void GameOver()
        {
            _gameOver = true;
            lblQuest.Text = "Ти програв(  Твій виграш - " + GiveMoney().ToString() + " Рестарт?";
            lblQuest.Enabled = true;
            int i = 0;
            while (!_gameQuestions[_count].Answer[i].Res)
            {
                i++;
            }
            switch (i)
            {
                case 0:
                    buttonA.CssClass = "correctA";
                    break;
                case 1:
                    buttonB.CssClass = "correctB";
                    break;
                case 2:
                    buttonC.CssClass = "correctC";
                    break;
                case 3:
                    buttonD.CssClass = "correctD";
                    break;
            }
            foreach (Button but in _btnAnswers)
            {
                but.Enabled = false;
            }
        }

        private int GiveMoney()
        {
            int money = 0;
            if (_count < 5)
            {
                money = 0;
            }
            else if (_count >= 5 & _count < 10)
            {
                money = 1000;
            }
            else if (_count >= 10 & _count < 15)
            {
                money = 32000;
            }
            else
            {
                money = 1000000;
            }

            return money;
        }

        private void InitButtons()
        {
            _btnAnswers = new Button[] { buttonA, buttonB, buttonC, buttonD };
        }

        private void DeleteTwoAnswer()
        {
            Random rnd;
            int answer1;
            int answer2;
            do
            {
                rnd = new Random();
                answer1 = rnd.Next(0, 3);
                do
                {
                    rnd = new Random();
                    answer2 = rnd.Next(0, 3);
                } while (!(!(_gameQuestions[_count].Answer[answer2].Res) && (answer1 != answer2)));

            } while (_gameQuestions[_count].Answer[answer1].Res);
            _btnAnswers[answer1].Text = string.Empty;
            _btnAnswers[answer1].Enabled = false;
            _btnAnswers[answer2].Text = string.Empty;
            _btnAnswers[answer2].Enabled = false;
        }

        protected void lblQuest_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            CleareScoreTable(_count);
            _count = 0;
            _flagSend = false;
            _gameOver = false;
            lblQuest.Enabled = false;
            RefreshHelpBtn();
            Page_Load(this, EventArgs.Empty);
        }

        private void CleareScoreTable(int iteration)
        {
            for (int i = 0; i <= iteration; i++)
            {
                scoretable.Rows[15 - i].Attributes.Clear();
            }

        }

        private void SetButnColor()
        {
            buttonA.CssClass = "butA";
            buttonB.CssClass = "butB";
            buttonC.CssClass = "butC";
            buttonD.CssClass = "butD";
        }

        private void RefreshHelpBtn()
        {
            btnHelp1.Enabled = true;
            btnHelp1.CssClass = "help1";
            btnHelp2.Enabled = true;
            btnHelp2.CssClass = "help2";
            btnHelp3.Enabled = true;
            btnHelp3.CssClass = "help3";
        }
     
        [WebMethod()]
        [ScriptMethod()]
        public static void SendMail(string recipient)
        {
            _flagSend = true;
            var fromAddress = new MailAddress("olegpavlukua@gmail.com", "Перший мільйон");
            var toAddress = new MailAddress(recipient, "Друг");

            const string fromPassword = "oleg2580";
            const string subject = "Допомога друга";
            string body = "Запитання: " + _gameQuestions[_count].Issue + " Відповіді: A: " + _gameQuestions[_count].Answer[0].Answer +
                 ", B: " + _gameQuestions[_count].Answer[1].Answer + ", C: " + _gameQuestions[_count].Answer[2].Answer + ", D: " + _gameQuestions[_count].Answer[3].Answer + ". ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }                  
        }
    }
}