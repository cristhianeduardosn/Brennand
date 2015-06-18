<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


    <div>

        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox> </br>

        <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox> </br>
        <asp:Button ID="btnLogin" runat="server" Text="Button" />
        </br>
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>

        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="Button" />
    </div>
    </form>


</body>
</html>
