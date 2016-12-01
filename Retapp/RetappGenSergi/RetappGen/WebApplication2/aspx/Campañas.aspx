<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Campañas.aspx.cs" Inherits="WebApplication2.aspx.Campañas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Activar Campaña" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Invalidar campaña" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Modificar Campaña" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Validar Campaña" />
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Borrar Campaña" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem>ab</asp:ListItem>
            <asp:ListItem>cd</asp:ListItem>
            <asp:ListItem>ef</asp:ListItem>
        </asp:ListBox>
    </form>
</body>
</html>
