<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="uyeler.aspx.cs" Inherits="uyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="uye_all">
        <div class="uye_ara">
            <table align="right">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Nick" Font-Bold="True" Font-Size="30px" ForeColor="#333333"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="ktext"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ara" CssClass="kb" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:center;">
                        <asp:Label ID="aramasonuc" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Literal ID="gom" runat="server"></asp:Literal>
        <div class="sayfa">
            <asp:Literal ID="sayfa" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

