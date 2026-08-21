using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PR4
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Check all validation controls
            if (Page.IsValid)
            {
                string name = txtName.Text;
                string mobile = txtMobile.Text;
                string email = txtEmail.Text;
                string college = txtCollege.Text;
                string address = txtAddress.Text;
                string eventName = dropEvent.SelectedValue;

                // Department
                string department = "";

                if (rbCse.Checked)
                    department = "CSE";
                else if (rbCivil.Checked)
                    department = "Civil";
                else if (rbIt.Checked)
                    department = "IT";
                else if (rbElectrical.Checked)
                    department = "Electrical";
                else
                    department = "Not Selected";

                // Gender
                string gender = "";

                if (genderMale.Checked)
                    gender = "Male";
                else if (genderFemale.Checked)
                    gender = "Female";
                else
                    gender = "Not Selected";

                // Skills
                string skills = "";

                if (checkboxJava.Checked)
                    skills += "Java, ";

                if (checkboxPython.Checked)
                    skills += "Python, ";

                if (checkboxC.Checked)
                    skills += "C, ";

                if (checkboxAndroid.Checked)
                    skills += "Android, ";

                if (skills != "")
                    skills = skills.TrimEnd(',', ' ');
                else
                    skills = "No Skill Selected";

                // Terms
                string terms = cbTerms.Checked ? "Accepted" : "Not Accepted";

                // Display all details
                lblDetails.Text =
                    "<b>Name:</b> " + Server.HtmlEncode(name) + "<br/>" +
                    "<b>Mobile No:</b> " + Server.HtmlEncode(mobile) + "<br/>" +
                    "<b>Email:</b> " + Server.HtmlEncode(email) + "<br/>" +
                    "<b>College:</b> " + Server.HtmlEncode(college) + "<br/>" +
                    "<b>Department:</b> " + Server.HtmlEncode(department) + "<br/>" +
                    "<b>Gender:</b> " + Server.HtmlEncode(gender) + "<br/>" +
                    "<b>Event:</b> " + Server.HtmlEncode(eventName) + "<br/>" +
                    "<b>Skills:</b> " + Server.HtmlEncode(skills) + "<br/>" +
                    "<b>Address:</b> " + Server.HtmlEncode(address) + "<br/>" +
                    "<b>Terms & Conditions:</b> " + terms;

                // Show details panel
                pnlDetails.Visible = true;
            }
            else
            {
                // Do not show details if validation fails
                pnlDetails.Visible = false;
            }
        }
    }
}