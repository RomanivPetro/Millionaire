using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Game.Code;
using Millionaire.Game.Code.Keys;
using Millionaire.Game.Code.EnumHolder;
using Millionaire.Game.Controllers;

namespace Millionaire.Game
{
    public partial class GameplayPage : System.Web.UI.Page
    {
        #region Private Fields

        private bool _gameOver;
        private Question[] _gameQuestions;
        private Button[] _btnAnswers;
        private int _currentStep;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionKeys.USER_KEY] != null)
            {
                string text = (string)Session[SessionKeys.USER_KEY];
                this._gameQuestions = (Question[]) Session[SessionKeys.QUESTIONS_KEY];
                this._currentStep = (int) Session[SessionKeys.STEP_KEY];          
                LoadQuestions(this._currentStep);
                InitBtnHelpEvent();
                InitButtons(); 
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
        }

        protected void btnHelp2_Click(object sender, EventArgs e)
        {
            SendMailControl.Visible = true;
        }

        protected void btnHelp3_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q=" + _gameQuestions[this._currentStep].Issue + "')", true);
        }

        #endregion

        #region Helpers

        private void CheckAnswer(UsersChoice choice)
        {
            switch (choice)
            {
                case UsersChoice.AnswerA:
                    if (CheckResult(UsersChoice.AnswerA, this._currentStep))
                    {
                        NextStep();
                        LoadQuestions(this._currentStep);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;

                case UsersChoice.AnswerB:
                    if (CheckResult(UsersChoice.AnswerB, this._currentStep))
                    {
                        NextStep();
                        LoadQuestions(this._currentStep);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;

                case UsersChoice.AnswerC:
                    if (CheckResult(UsersChoice.AnswerC, this._currentStep))
                    {
                        NextStep();
                        LoadQuestions(this._currentStep);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;

                case UsersChoice.AnswerD:
                    if (CheckResult(UsersChoice.AnswerD, this._currentStep))
                    {
                        NextStep();
                        LoadQuestions(this._currentStep);
                    }
                    else
                    {
                        GameOver();
                    }
                    break;
            }

        }

        private bool CheckResult(UsersChoice choice, int iteration)
        {
            return (_gameQuestions[iteration].Answer[(int)choice].Res == true);
        }

        private void LoadQuestions(int iteration)
        {
            if (iteration < 15)
            {
                if (iteration != 0)
                {
                   ScoreTableControl.ChangeScore(iteration);  
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
    
        private void GameWin()
        {
            Response.Redirect("~/GameOverPage.aspx?game=win");
        }

        private void GameOver()
        {
            Response.Redirect("~/GameOverPage.aspx?game=lose&money=" + GiveMoney().ToString());
            
        }

        private int GiveMoney()
        {
            int money = 0;
            if (this._currentStep < 5)
            {
                money = 0;
            }
            else if (this._currentStep >= 5 & this._currentStep < 10)
            {
                money = 1000;
            }
            else if (this._currentStep >= 10 & this._currentStep < 15)
            {
                money = 32000;
            }
            else
            {
                money = 1000000;
            }

            return money;
        }

        private void NextStep()
        {
            this._currentStep++;
            Session[SessionKeys.STEP_KEY] = this._currentStep;
        }

        private void InitBtnHelpEvent()
        {
            ScoreTableControl.BtnHelp1.Click += btnHelp1_Click;
            ScoreTableControl.BtnHelp2.Click += btnHelp2_Click;
            ScoreTableControl.BtnHelp3.Click += btnHelp3_Click;
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
                } while (!(!(_gameQuestions.ElementAt(this._currentStep).Answer[answer2].Res) && (answer1 != answer2)));

            } while (_gameQuestions.ElementAt(this._currentStep).Answer[answer1].Res);
            _btnAnswers[answer1].Text = string.Empty;
            _btnAnswers[answer1].Enabled = false;
            _btnAnswers[answer2].Text = string.Empty;
            _btnAnswers[answer2].Enabled = false;
        }

        private void InitButtons()
        {
            _btnAnswers = new Button[] { buttonA, buttonB, buttonC, buttonD };
        }

       


        #endregion
    }
}