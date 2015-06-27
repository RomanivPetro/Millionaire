using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Game.Code;
using Millionaire.Game.Code.Keys;

namespace Millionaire.Game
{
    public partial class PrimaryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewGame_Click(object sender, EventArgs e)
        {
            InitSession();          
            Response.Redirect("~/GameplayPage.aspx");
        }

        private void InitSession()
        {
            var xml = new XmlQuestionRepository(Server.MapPath("/App_Data/questions.xml"));
           
            Session[SessionKeys.USER_KEY] = txtUserName.Text;
            Session[SessionKeys.QUESTIONS_KEY] = xml.GetQuestions();
            Session[SessionKeys.STEP_KEY] = 0;
        }
    }
}