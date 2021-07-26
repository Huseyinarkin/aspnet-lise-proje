<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="paylas.aspx.cs" Inherits="paylas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script >
        function uzunluk(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)
                        e.returnValue = false;
                    else
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="paylas">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>başlık</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="baslik" runat="server" CssClass="baslik" MaxLength="50"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>entry</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="entry" runat="server" CssClass="entry" TextMode="MultiLine" MaxLength='19' onkeyDown="uzunluk(this,event,'400');"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" CssClass="align_sag">
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="paddir"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Değiştir" CssClass="kb" OnClick="p_button_degis" Visible="false"/>
                    <asp:Button ID="p_button" runat="server" Text="Paylaş" CssClass="kb" OnClick="p_button_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="degisken" runat="server" Text="" CssClass="hayalet"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Link HATALI !!!" Font-Bold="True" Font-Size="50px" ForeColor="Red" Visible="false"></asp:Label>
    </div>
</asp:Content>

