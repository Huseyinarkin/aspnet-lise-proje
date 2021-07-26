<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kayit.aspx.cs" Inherits="kayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="kyt">
        <span class="kytbas">Kayıt Formu</span>
        <hr />
        <table align="center">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/profile/water.jpg" CssClass="kprofile"/>     

                    <ul class="kulpro">
                        <li>
                            <asp:RadioButton ID="kprofile1" runat="server" GroupName="pro" OnCheckedChanged="kprofile_Kontrol" AutoPostBack="true" Checked/></li>
                        <li>
                            <asp:RadioButton ID="kprofile2" runat="server" GroupName="pro" OnCheckedChanged="kprofile_Kontrol" AutoPostBack="true"
                                />
                        </li>
                        <li>
                            <asp:RadioButton ID="kprofile3" runat="server" GroupName="pro" OnCheckedChanged="kprofile_Kontrol" AutoPostBack="true"/></li>
                        <li>
                            <asp:RadioButton ID="kprofile4" runat="server" GroupName="pro" OnCheckedChanged="kprofile_Kontrol" AutoPostBack="true"/></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td><span class="tdy">NİCK</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Textnick" runat="server" CssClass="ktext" MaxLength="10"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Textnick" ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="k"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td><span class="tdy">AD</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Textad" runat="server" CssClass="ktext" MaxLength="25"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Textad" ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="k"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><span class="tdy">SOYAD</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Textsad" runat="server" CssClass="ktext" MaxLength="15"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Textsad" ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="k"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><span class="tdy">ŞİFRE</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Textsfr" runat="server" CssClass="ktext" TextMode="Password" MaxLength="30"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Textsfr" ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="k"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><span class="tdy">ŞİFRE TEKRAR</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Texttsfr" runat="server" CssClass="ktext" TextMode="Password" MaxLength="30"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="Texttsfr" ID="RequiredFieldValidator5" ForeColor="Red" ValidationGroup="k"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="k" ControlToCompare="Textsfr" ControlToValidate="Texttsfr" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td><span class="tdy">CİNSİYET</span></td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="cins1" runat="server" GroupName="cns" Checked Text="Bay" />&nbsp;&nbsp;
                    <asp:RadioButton ID="cins2" runat="server" GroupName="cns" Text="Bayan" />
                </td>
            </tr>
        </table>
        <hr />
        <div class="kdb">
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="kb" ValidationGroup="k" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>

