<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="WebApplication2.Leave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblWelcome" runat="server" Font-Size="Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Label ID="lblType" runat="server" Text="Type:"></asp:Label>
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Text="Sick" Value="Sick"></asp:ListItem>
                <asp:ListItem Text="Casual" Value="Casual"></asp:ListItem>
                <asp:ListItem Text="Emergency" Value="Emergency"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <asp:Label ID="lblApproved" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
