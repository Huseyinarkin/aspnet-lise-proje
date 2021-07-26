<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="entry.aspx.cs" Inherits="entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="e_all" runat="server" id="ee">

        <asp:Panel ID="p2" runat="server" CssClass="kul_yetki" Visible="false">

            <asp:Button ID="bdzn" runat="server" Text="Düzenle" CssClass="endzn" OnClick="dznle"  Visible="false"/>
            <asp:Button ID="bsil" runat="server" Text="Sil" CssClass="ensil" OnClick="sil" Visible="false"/>
            <asp:Button ID="bay" runat="server" Text="Ayarlar" CssClass="bayar" OnClick="ayar" />
        </asp:Panel>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <asp:Panel ID="p1" runat="server">
        </asp:Panel>
    </div>

</asp:Content>

