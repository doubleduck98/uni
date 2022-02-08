<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="zad2.WelcomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="message"></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="logoutBtn" Text="log out" OnClick="LogoutBtn_Click" />
        </div>
    </form>
</body>
</html>
