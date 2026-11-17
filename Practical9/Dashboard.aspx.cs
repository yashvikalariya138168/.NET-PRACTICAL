using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    private string ConnectionString => ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartments();
            BindDashboard();
            BindStudents();
        }
    }

    private DataTable GetTable(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    private void BindDepartments()
    {
        DataTable dt = GetTable("SELECT DISTINCT Department FROM dbo.Students ORDER BY Department");
        ddlDepartment.DataSource = dt;
        ddlDepartment.DataTextField = "Department";
        ddlDepartment.DataValueField = "Department";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("All Departments", ""));
    }

    private void BindDashboard()
    {
        DataTable dt = GetTable(@"SELECT COUNT(*) TotalStudents,
            SUM(CASE WHEN Status='Placed' THEN 1 ELSE 0 END) PlacedStudents,
            AVG(CASE WHEN Status='Placed' THEN PackageLPA END) AveragePackage
            FROM dbo.Students");
        int total = Convert.ToInt32(dt.Rows[0]["TotalStudents"]);
        int placed = dt.Rows[0]["PlacedStudents"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["PlacedStudents"]);
        decimal avg = dt.Rows[0]["AveragePackage"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["AveragePackage"]);
        lblTotal.Text = total.ToString();
        lblPlaced.Text = placed.ToString();
        lblRate.Text = (total == 0 ? 0 : placed * 100.0 / total).ToString("0.0") + "%";
        lblAverage.Text = "₹" + avg.ToString("0.00") + " LPA";
    }

    private void BindStudents()
    {
        string sql = "SELECT StudentId, StudentName, Department, CompanyName, PackageLPA, Status FROM dbo.Students";
        if (!String.IsNullOrEmpty(ddlDepartment.SelectedValue))
        {
            sql += " WHERE Department=@Department";
            gvStudents.DataSource = GetTable(sql + " ORDER BY StudentId",
                new SqlParameter("@Department", ddlDepartment.SelectedValue));
        }
        else gvStudents.DataSource = GetTable(sql + " ORDER BY StudentId");
        gvStudents.DataBind();
        dvStudent.DataSource = null;
        dvStudent.DataBind();
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e) { BindStudents(); }

    protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(gvStudents.SelectedDataKey.Value);
        DataTable dt = GetTable("SELECT * FROM dbo.Students WHERE StudentId=@Id", new SqlParameter("@Id", id));
        dvStudent.DataSource = dt;
        dvStudent.DataBind();
    }
}
