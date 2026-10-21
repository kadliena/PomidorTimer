using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PomidorTimerCode
{
    public partial class Main : System.Web.UI.Page
    {
        // cколько секунд осталось
        private int SecondsLeft
        {
            get { return ViewState["SecondsLeft"] == null ? 0 : (int)ViewState["SecondsLeft"]; }
            set { ViewState["SecondsLeft"] = value; }
        }
        private void UpdateLabel()
        {
            Label1.Text = string.Format("{0:D2}:{1:D2}", SecondsLeft / 60, SecondsLeft % 60);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UpdateLabel();
        }

        protected void Button1_Click(object sender, EventArgs e) 
        { 
            SecondsLeft = 55 * 60; 
            Timer1.Enabled = true; 
            UpdateLabel(); 
        }
        protected void Button2_Click(object sender, EventArgs e) 
        { 
            SecondsLeft = 5 * 60; 
            Timer1.Enabled = true; 
            UpdateLabel(); 
        }
        protected void Button3_Click(object sender, EventArgs e) 
        { SecondsLeft = 20 * 60; 
            Timer1.Enabled = true; 
            UpdateLabel(); 
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (SecondsLeft <= 0)
            {
                Timer1.Enabled = false;
                UpdateLabel();
                return;
            }
            SecondsLeft--;
            UpdateLabel();
        }
    }
}