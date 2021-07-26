<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        if(request)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Table ID="islem" runat="server" CssClass="basari" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbasari" runat="server" Text="" CssClass="lbasari">İşlem Başarılı</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table3" runat="server" CssClass="menuayar" Visible="false">
        <asp:TableRow>
            <asp:TableCell CssClass="matd">
                <asp:LinkButton ID="mabad" runat="server" CssClass="mab" OnClick="ad_click">AD</asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell CssClass="matd">
                <asp:LinkButton ID="mabsad" runat="server" CssClass="mab" OnClick="sad_click">Soyad</asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell CssClass="matd">
                <asp:LinkButton ID="mabsifre" runat="server" CssClass="mab" OnClick="sifre_click">Şifre</asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell CssClass="matd">
                <asp:LinkButton ID="mabcins" runat="server" CssClass="mab" OnClick="cins_click">Cins</asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell CssClass="matds">
                <asp:LinkButton ID="mabresim" runat="server" CssClass="mab" OnClick="resim_click">Resim</asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table2" runat="server" CssClass="ayar" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ls" runat="server" Text="" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ld" runat="server" Text=""></asp:Label>
                <asp:Image ID="Image2" runat="server" CssClass="g_resim" Visible="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lys" runat="server" Text="" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tdd" runat="server" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tdd" ForeColor="Red" ValidationGroup="b"></asp:RequiredFieldValidator>
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="a" Visible="false" OnCheckedChanged="radio1_click" AutoPostBack="true"/>
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="a" Visible="false" OnCheckedChanged="radio2_click" AutoPostBack="true"/>
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="a" Visible="false" OnCheckedChanged="radio3_click" AutoPostBack="true"/>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="a" Visible="false" OnCheckedChanged="radio4_click" AutoPostBack="true"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="kad" runat="server" Text="Kaydet" CssClass="bb" Visible="false" OnClick="kad_click" ValidationGroup="b" />
                <asp:Button ID="ksad" runat="server" Text="Kaydet" CssClass="bb" Visible="false" OnClick="ksad_click" ValidationGroup="b"/>
                <asp:Button ID="ksifre" runat="server" Text="Kaydet" CssClass="bb" Visible="false" OnClick="ksifre_click" ValidationGroup="b"/>
                <asp:Button ID="kcins" runat="server" Text="Kaydet" CssClass="bb" Visible="false" OnClick="kcins_click" ValidationGroup="b"/>
                <asp:Button ID="kresim" runat="server" Text="Kaydet" CssClass="bb" Visible="false" OnClick="kresim_click" ValidationGroup="b"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div class="dbilgi">
        <asp:Label ID="Label1" runat="server" Text="Link HATALI !!!" Font-Bold="True" Font-Size="50px" ForeColor="Red"></asp:Label>
        <asp:Image ID="Image1" runat="server" CssClass="pro_resim" Visible="false" />
        <asp:Table ID="Table1" runat="server" CssClass="btable" Visible="false">
            <asp:TableRow>
                <asp:TableCell CssClass="btd">
                    <asp:Label ID="blgad" runat="server" Text="" CssClass="lbilgi"></asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="btd">
                    <asp:Label ID="bnick" runat="server" Text="" CssClass="lbilgi"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="btd">
                    <asp:Label ID="blgsad" runat="server" Text="" CssClass="lbilgi"></asp:Label>
                </asp:TableCell>
                <asp:TableCell CssClass="btd">
                    <asp:Label ID="bcins" runat="server" Text="" CssClass="lbilgi"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="duzen" runat="server" Text="Düzenle" Visible="false" CssClass="bb" OnClick="duzen_Click"/>
    </div>
    <hr style="border:#333 solid 2px;"/>
    <div class="p_baslik">
        <asp:Label ID="Label2" runat="server" Text="Başlıklar" CssClass="h1" Visible="false"></asp:Label>
        <asp:Literal ID="gom" runat="server"></asp:Literal>
    </div>
    <div class="sayfa" style="margin-left:auto;margin-right:auto">
        <asp:Literal ID="sayfa" runat="server"></asp:Literal>
    </div>
    <asp:Label ID="focus" runat="server" Text=""></asp:Label>
</asp:Content>

