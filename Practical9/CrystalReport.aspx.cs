using System;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class CrystalReportPage : System.Web.UI.Page
{
    private ReportDocument report;

    protected void Page_Load(object sender, EventArgs e)
    {
        string reportPath = Server.MapPath("~/PlacementSummary.rpt");
        if (!File.Exists(reportPath))
        {
            lblMessage.Text = "Create PlacementSummary.rpt using the Crystal Reports designer. See README.txt for the exact steps.";
            CrystalReportViewer1.Visible = false;
            return;
        }

        if (!IsPostBack)
        {
            report = new ReportDocument();
            report.Load(reportPath);
            CrystalReportViewer1.ReportSource = report;
            Session["PlacementReport"] = report;
        }
        else
        {
            report = Session["PlacementReport"] as ReportDocument;
            if (report != null) CrystalReportViewer1.ReportSource = report;
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // Keep the report in Session for viewer paging/export postbacks.
        // Dispose it when the session ends in a production application.
    }
}
