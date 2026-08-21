<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PR4.Registration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Registration Form</title>

    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }

        .auto-style3 {
            height: 23px;
            width: 445px;
        }

        .auto-style4 {
            width: 445px;
        }

        .auto-style5 {
            height: 23px;
            width: 445px;
            margin-left: 40px;
        }

        .auto-style6 {
            width: 197px;
            height: 75px;
        }

        .auto-style7 {
            height: 23px;
            width: 748px;
        }

        .auto-style8 {
            width: 748px;
        }

        .error {
            color: red;
        }

        .details {
            margin-top: 30px;
            padding: 15px;
            border: 1px solid black;
            width: 600px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div>
            <asp:Label ID="Label1" runat="server"
                Font-Bold="True"
                Font-Size="30px"
                Text="Event Registration Form">
            </asp:Label>
        </div>

        <br />

        <table class="auto-style2">

            <!-- Name -->
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                </td>

                <td class="auto-style7">
                    <asp:TextBox ID="txtName" runat="server"
                        Height="25px" Width="200px">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        runat="server"
                        ControlToValidate="txtName"
                        ErrorMessage="Name is required"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <!-- Mobile -->
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Text="Mobile No."></asp:Label>
                </td>

                <td class="auto-style8">
                    <asp:TextBox ID="txtMobile" runat="server"
                        Height="25px" Width="200px"
                        MaxLength="10">
                    </asp:TextBox>

                    <!-- Required -->
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2"
                        runat="server"
                        ControlToValidate="txtMobile"
                        ErrorMessage="Mobile number is required"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                    <!-- Exactly 10 digits -->
                    <asp:RegularExpressionValidator
                        ID="MobileValidator"
                        runat="server"
                        ControlToValidate="txtMobile"
                        ErrorMessage="Mobile number must contain exactly 10 digits"
                        ValidationExpression="^[0-9]{10}$"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <!-- Email -->
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                </td>

                <td class="auto-style7">
                    <asp:TextBox ID="txtEmail" runat="server"
                        Height="25px" Width="200px">
                    </asp:TextBox>

                    <!-- Required -->
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Email is required"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                    <!-- Email format -->
                    <asp:RegularExpressionValidator
                        ID="EmailValidator"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Enter a valid email address"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <!-- College -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label5" runat="server" Text="College"></asp:Label>
                </td>

                <td class="auto-style7">
                    <asp:TextBox ID="txtCollege" runat="server"
                        Height="25px" Width="200px">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="CollegeValidator"
                        runat="server"
                        ControlToValidate="txtCollege"
                        ErrorMessage="College is required"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <!-- Department -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label>
                </td>

                <td class="auto-style7">

                    <asp:RadioButton ID="rbCse"
                        runat="server"
                        GroupName="department"
                        Text="CSE" />

                    <br />

                    <asp:RadioButton ID="rbCivil"
                        runat="server"
                        GroupName="department"
                        Text="Civil" />

                    <br />

                    <asp:RadioButton ID="rbIt"
                        runat="server"
                        GroupName="department"
                        Text="IT" />

                    <br />

                    <asp:RadioButton ID="rbElectrical"
                        runat="server"
                        GroupName="department"
                        Text="Electrical" />

                </td>
            </tr>

            <!-- Gender -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label>
                </td>

                <td class="auto-style7">

                    <asp:RadioButton ID="genderMale"
                        runat="server"
                        GroupName="gender"
                        Text="Male" />

                    &nbsp;&nbsp;&nbsp;

                    <asp:RadioButton ID="genderFemale"
                        runat="server"
                        GroupName="gender"
                        Text="Female" />

                </td>
            </tr>

            <!-- Event -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label8" runat="server" Text="Event Name"></asp:Label>
                </td>

                <td class="auto-style7">

                    <asp:DropDownList ID="dropEvent" runat="server">
                        <asp:ListItem>Poster Presentation</asp:ListItem>
                        <asp:ListItem>Quiz</asp:ListItem>
                        <asp:ListItem>Hackathon</asp:ListItem>
                        <asp:ListItem>Treasure Hunt</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>

            <!-- Skills -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label10" runat="server" Text="Skills"></asp:Label>
                </td>

                <td class="auto-style7">

                    <asp:CheckBox ID="checkboxJava"
                        runat="server"
                        Text="Java" />

                    <br />

                    <asp:CheckBox ID="checkboxPython"
                        runat="server"
                        Text="Python" />

                    <br />

                    <asp:CheckBox ID="checkboxC"
                        runat="server"
                        Text="C" />

                    <br />

                    <asp:CheckBox ID="checkboxAndroid"
                        runat="server"
                        Text="Android" />

                </td>
            </tr>

            <!-- Address -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label11" runat="server" Text="Address"></asp:Label>
                </td>

                <td class="auto-style7">

                    <asp:TextBox ID="txtAddress"
                        runat="server"
                        TextMode="MultiLine"
                        CssClass="auto-style6">
                    </asp:TextBox>

                </td>
            </tr>

            <!-- Terms -->
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label12"
                        runat="server"
                        Text="Terms &amp; Conditions">
                    </asp:Label>
                </td>

                <td class="auto-style7">

                    <asp:CheckBox ID="cbTerms"
                        runat="server"
                        Text="Accept Terms &amp; Conditions" />

                </td>
            </tr>

            <!-- Submit -->
            <tr>
                <td class="auto-style5">
                    &nbsp;
                </td>

                <td class="auto-style7">

                    <asp:Button ID="Button1"
                        runat="server"
                        Text="Submit"
                        OnClick="Button1_Click" style="height: 26px" />

                </td>
            </tr>

        </table>

        <!-- Display Details -->
        <asp:Panel ID="pnlDetails" runat="server"
            CssClass="details"
            Visible="false">

            <asp:Label ID="lblDetailsTitle"
                runat="server"
                Text="Registration Details"
                Font-Bold="True"
                Font-Size="25px">
            </asp:Label>

            <br /><br />

            <asp:Label ID="lblDetails"
                runat="server">
            </asp:Label>

        </asp:Panel>

    </form>
</body>
</html>

