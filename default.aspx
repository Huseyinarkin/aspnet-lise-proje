<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="resimdiv">
        <asp:Image ID="Image1" runat="server" ImageUrl="resim/moon.jpg" CssClass="resim" />
    </div>
    <div class="alt">
        <h1>AMACIMIZ</h1>
        <p>
            İnsanların sanal dünyada bir araya gelerek bilgilerini, tecrübelerini, doğrularını, yanlışlarını, hatalarını, eksiklerinive aklınıza gelebilecek her konuda topic(konu) ve yorum yazarak paylaştığı yazıların bütünüdür.
        </p>
        <p>
            Diğer bir deyişle forum sanal dünyanın sosyalleşmiş siteleridir. Günümüz forumlarında insanlar bir araya gelerek sanal etkinlikler dışında bir çok konuda etkinlikler düzenlemektedirler. Bunların başında; webmaster forumlarında bulunan üyeler 1. sırayı alıyor. Üyeler bir araya gelerek seminerler, kurumlara yardım, alış - veriş, tatil, eğlence gibi çeşitli etkinlikler düzenlemektedir.
        </p>
    </div>
</asp:Content>

