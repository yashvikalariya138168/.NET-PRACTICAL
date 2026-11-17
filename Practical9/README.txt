PRACTICAL 9 - PLACEMENT DASHBOARD USING DATA CONTROLS & CRYSTAL REPORTS
=======================================================================

Project type: ASP.NET Web Forms (C#), .NET Framework 4.8
Project name: Practical9

IMPORTANT
---------
Crystal Reports for Visual Studio is a separate SAP installation. This project
includes the CrystalReportViewer integration code, but the actual .rpt file must
be created in Visual Studio's Crystal Reports designer after installing the
Crystal Reports developer package. Follow the steps below.

REQUIREMENTS
------------
1. Visual Studio 2019/2022/2026 with ASP.NET and web development workload.
2. .NET Framework 4.8 Developer Pack.
3. SQL Server / SQL Server Express and SQL Server Management Studio (SSMS).
4. SAP Crystal Reports, developer version for Visual Studio (matching your VS).
5. SAP Crystal Reports runtime matching the application's platform (32-bit or
   64-bit). Install the developer package first, then runtime if required.

DATABASE SETUP
--------------
1. Open SQL Server Management Studio.
2. Connect to your SQL Server instance.
3. Open Database/PlacementDB.sql and execute it.
4. The script creates PlacementDB and sample student/placement records.

OPEN AND RUN
------------
1. Extract Practical9.zip.
2. Open Visual Studio.
3. Choose File > Open > Web Site.
4. Select the extracted Practical9 folder (the folder containing Web.config).
   Alternatively create an ASP.NET Empty Web Site targeting .NET Framework 4.8
   and add these files.
5. Open Web.config and change the connection string's Data Source to your SQL
   Server instance. Common examples:
      .\SQLEXPRESS
      (localdb)\MSSQLLocalDB
      localhost
6. In Server Explorer, verify the connection if desired.
7. Right-click Dashboard.aspx and choose Set as Start Page.
8. Press Ctrl+F5 or click IIS Express.

WHAT YOU WILL SEE
-----------------
- Dashboard summary cards: total students, placed students, placement rate,
  and average package.
- Drop-down filter by department.
- GridView showing placement records (ASP.NET data control).
- DetailsView showing the selected student record.
- Crystal Reports page with CrystalReportViewer integration.

CREATE THE CRYSTAL REPORT FILE (ONE-TIME SETUP)
-----------------------------------------------
The .rpt file is a designer-generated binary file, so it is not included as a
fake/empty file. Create it after installing SAP Crystal Reports for Visual
Studio:

1. In Solution Explorer, right-click the project > Add > New Item.
2. Select Crystal Reports (or Reporting > Crystal Reports), name it
   PlacementSummary.rpt.
3. Choose "Using the Report Wizard" > Standard Report.
4. Choose Create New Connection > ODBC (RDO) or OLE DB (ADO), then connect to
   your SQL Server and PlacementDB database.
5. Select dbo.Students as the table and add the fields:
   StudentId, StudentName, Department, CompanyName, PackageLPA, PlacementDate.
6. Add Department as a group if desired. Add PackageLPA to a summary (Average)
   and StudentId to a count summary.
7. Finish and save PlacementSummary.rpt in the project root.
8. Select PlacementSummary.rpt in Solution Explorer and set Build Action to
   Content and Copy to Output Directory to Copy if newer.
9. Open CrystalReport.aspx.cs. The code loads ~/PlacementSummary.rpt. Run the
   Crystal Reports page after the report file has been created.

TROUBLESHOOTING
---------------
- If CrystalReportViewer type is not found: install SAP Crystal Reports for
  Visual Studio and add references to CrystalDecisions.CrystalReports.Engine,
  CrystalDecisions.Shared, and CrystalDecisions.Web.
- If the viewer reports a platform mismatch: set Project > Properties >
  Build > Platform target to x86 or x64 to match the installed runtime.
- If SQL login fails: verify Data Source and SQL Server authentication settings.
- Crystal Reports does not support modern .NET (for example .NET 8/9/10) in the
  same way as .NET Framework Web Forms. Use .NET Framework 4.8 for this practical.
