<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Retapp_Web_Interface.WebForm2" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <table style="width:100%;">
        <!--tr es fila y td es columna-->
        <tr>
            <td style="width: 306px; height: 467px;">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="text-align: right">
                    <Columns>
                        <asp:ButtonField DataTextField="Campaña" Text="Botón" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RetappGenNHibernateConnectionString %>" SelectCommand="SELECT [Campaña] FROM [Concurso]"></asp:SqlDataSource>
            </td>
            <td style="height: 467px;"></td>
        </tr>
        <tr>
            <td style="height: 28px; width: 306px;">
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Invalidar Campaña" Width="573px" />
                </div>
            </td>
            <td style="height: 28px; text-align: left;">
                <div>
                    <asp:Button ID="Button2" runat="server" Text="Activar Campaña" Width="378px" />
                    <asp:Button ID="Button4" runat="server" Text="Validar Campaña" Width="378px" />
                </div>
                <div>
                    <asp:Button ID="Button3" runat="server" Text="Modificar Campaña" Width="378px" />
                    <asp:Button ID="Button5" runat="server" Text="Borrar Campaña" style="text-align: center" Width="378px" />
                </div>

                
            </td>

        </tr>
        
    </table>
</asp:Content>
