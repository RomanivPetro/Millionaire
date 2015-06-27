using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Millionaire.Game.Controllers
{
    public partial class ScoreTableControl : System.Web.UI.UserControl
    {
        #region Public properties

        public Button BtnHelp1
        {
            get { return this.btnHelp1; }
        }

        public Button BtnHelp2
        {
            get { return this.btnHelp2; }
        }

        public Button BtnHelp3
        {
            get { return this.btnHelp3; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            scoretable.Rows[15].BgColor = "#D2691E";
        }

        #region Help Buttons Event

        protected void btnHelp1_Click(object sender, EventArgs e)
        {
            btnHelp1.Enabled = false;
            btnHelp1.CssClass = "help1u";
        }

        protected void btnHelp2_Click(object sender, EventArgs e)
        {
            btnHelp2.Enabled = false;
            btnHelp2.CssClass = "help2u";
        }

        protected void btnHelp3_Click(object sender, EventArgs e)
        {
            btnHelp3.Enabled = false;
            btnHelp3.CssClass = "help3u";
        }

        public void ChangeScore(int iteration)
        {
            scoretable.Rows[15 - iteration + 1].Attributes.Clear();
            scoretable.Rows[15 - iteration + 1].Attributes.Add("class", "passedscore");
            scoretable.Rows[15 - iteration].Attributes.Add("class", "currentscore");
        }

        #endregion
    }
}