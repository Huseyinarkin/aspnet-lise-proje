

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="gir.aspx.cs" Inherits="gir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="kyt">
        <br /><br /><br /><br /><br /><br />
        <span class="kytbas">Giriş</span>
        <hr />
        <table align="center">
            <tr>
                <td><span class="tdy">NİCK</span></td>
            </tr>
            <tr>
              <td>  <asp:TextBox ID="Textnick" runat="server" CssClass="ktext"></asp:TextBox></td>
            </tr>
            <tr>
                <td><span class="tdy">ŞİFRE</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Textsfr" runat="server" CssClass="ktext" TextMode="Password"></asp:TextBox></td>
            </tr>
        </table>
        <hr />
        <div class="hata">
            <asp:Label ID="Label1" runat="server" Text="" CssClass="yanlis" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
        <div class="kdb">
            <asp:Button ID="Button1" runat="server" Text="Giriş" CssClass="kb" OnClick="Button1_Click"/>
        </div>
        <br /><br /><br /><br /><br /><br />
    </div>
</asp:Content>

