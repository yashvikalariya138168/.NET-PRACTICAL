using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical5
{
    public partial class Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // require login
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Welcome, " + Session["user"].ToString();
            }
        }
        // Submit: approve leave immediately and show approval on same page
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var date = txtDate.Text.Trim();
            var type = ddlType.SelectedValue;
            var approver = Session["user"] != null ? Session["user"].ToString() : "(unknown)";

            lblApproved.Text = "Approved by: " + approver + "<br/>Name: " + name + "<br/>Date: " + date + "<br/>Type: " + type + "<br/>Status: Approved";
            lblApproved.Visible = true;

            // disable inputs after approval
            txtName.Enabled = false;
            txtDate.Enabled = false;
            ddlType.Enabled = false;
            btnSubmit.Enabled = false;
        }
    }
}