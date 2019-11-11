using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AspNetApplication
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected TextBox txt1;
        //page_Init, Page_Load, Page_Prerender, Page_Unload, Page_Disposed    
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            base.OnInit(e);
        }

        // public delegate void system.EventHandler(object sender, EventArgs e)
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.txt1.Text = "Enter your name here.";
        }
        public void btn1_Click(object sender, EventArgs e)
        {
            this.txt1.Text = this.txt1.Text.ToUpper();
        }
    }
}