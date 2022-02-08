<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="zad2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            email: <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
        <div>
            hasło: <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="loginBtn" Text="Log in" OnClick="LoginBtn_Click" />
            <asp:Button runat="server" ID="regBtn" Text="Register" OnClick="RegBtn_Click" />
        </div>
    </form>
    <div>
        <asp:Label ID="message" runat="server"></asp:Label>
    </div>
</body>
</html>
