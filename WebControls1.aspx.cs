using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetApplication
{
    public partial class WebControls1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> interestsList = new List<string>
            {
                "Art" , "Automobiles", "Technology", "Fashion", "Science", "Cuisines", "Sports", "Dance", "Music" };
            if (!IsPostBack)
            {
                chkInterests.DataSource = interestsList;
                chkInterests.DataBind();//bind the string items to the list-item
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<section class='alert alert-info'>");
            sb.AppendFormat("Hi, <b>{0}</b>!<br/>", txtName.Text)
                .Append("Welcome to our site. You are located in")
                .AppendFormat("<strong>{0}</strong>",ddlLocation.SelectedItem.ToString())
                .AppendFormat("<address>{0}</address>", txtAddress.Text)
                .Append("<br>Your interests are: ")
                .Append("<ul>");
            foreach (ListItem item in chkInterests.Items)
            {
                if (item.Selected)
                    sb.AppendFormat("<li>{0}</li>", item.Text);
            }
            sb.Append("</ul>");
            sb.Append("</section>");
            literal1.Text = sb.ToString();
        }
    }
}