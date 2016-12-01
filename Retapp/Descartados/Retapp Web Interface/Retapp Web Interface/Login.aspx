<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Retapp_Web_Interface.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <table style="width: 32%; margin-right: 0px;">
        <tr>
            <td style="width: 48px">Username:</td>
            <td>
                <input id="Username" type="text" style="width: 181px" /></td>
        </tr>
        <tr>
            <td style="width: 48px">Password:</td>
            <td>
                <input id="Password" type="password" style="width: 181px" /></td>
        </tr>
        <tr>
            <td style="width: 48px">

                <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion" />

            </td>
        </tr>
    </table>
</asp:Content>
