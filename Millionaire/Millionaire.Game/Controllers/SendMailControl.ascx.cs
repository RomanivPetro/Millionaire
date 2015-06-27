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

namespace Millionaire.Game.Controllers
{
    public partial class SendMailControl : System.Web.UI.UserControl
    {
        private Question[] _gameQuestions;      
        private int _currentStep;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._gameQuestions = (Question[])Session[SessionKeys.QUESTIONS_KEY];
            this._currentStep = (int)Session[SessionKeys.STEP_KEY];      
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SendMail(txtEmail.Text);
            this.Visible = false;
        }

        private void SendMail(string recipient)
        {                     
            var xml = new XmlQuestionRepository(HttpContext.Current.Server.MapPath("/App_Data/questions.xml"));
            IEnumerable<Question> questions = xml.GetQuestions();
            var fromAddress = new MailAddress("olegpavlukua@gmail.com", "Перший мільйон");
            var toAddress = new MailAddress(recipient, "Друг");

            const string fromPassword = "oleg2580";
            const string subject = "Допомога друга";
            string body = "Запитання: " + questions.ElementAt(this._currentStep).Issue + " Відповіді: A: " + _gameQuestions.ElementAt(this._currentStep).Answer[0].Answer +
                 ", B: " + _gameQuestions.ElementAt(this._currentStep).Answer[1].Answer + ", C: " + _gameQuestions.ElementAt(this._currentStep).Answer[2].Answer + ", D: " + _gameQuestions.ElementAt(this._currentStep).Answer[3].Answer + ". ";

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