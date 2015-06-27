using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Game.Code.Keys;

namespace Millionaire.Game
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string _gameInfo;
        private string _money;
        private string _name;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._gameInfo = this.Request.QueryString["game"];
            this._money = this.Request.QueryString["money"];
            this._name = (string) Session[SessionKeys.USER_KEY];
            ShowInfo();

        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            Session[SessionKeys.STEP_KEY] = 0;
            Response.Redirect("~/GameplayPage.aspx");
        }

        private void ShowInfo()
        {
            switch (this._gameInfo)
            {
                case "lose":
                    btnRes.Text = this._name + ", Ви програли. Ваш виграш " + this._money + "грн.";
                    break;
                case "win":
                    btnRes.Text = this._name + ", Вітаємо, Ви виграли 1 000 000 гривень!";
                    break;
            }
        }
    }
}