using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Static password validation
            var id = txtId.Text.Trim();
            var pass = txtPass.Text;
            const string staticPassword = "password123";
            if (pass == staticPassword && !string.IsNullOrEmpty(id))
            {
                // store user id in session and redirect
                Session["user"] = id;
                Response.Redirect("Leave.aspx");
            }
            lblMessage.Text = "Invalid credentials";
        }
    }

}