<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="zad2.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            nazwa: <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>
        <div>
            email: <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
        <div>
            hasło: <asp:TextBox ID="password" runat="server" TextMode="password"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="registerBtn" Text="Register" OnClick="RegisterBtn_Click" />
        </div>
    </form>
    <div>
        <asp:Label runat="server" ID="message"/>
    </div>
</body>
</html>
