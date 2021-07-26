using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;

public partial class profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(Session["islem"]!=null)
            {
                islem.Visible = true;
                Session.Remove("islem");
            }
            if(Session["ee"]!=null)
            {
                islem.Visible = true;
                lbasari.Text = "Entry başarıyla silindi.";
                Session.Remove("ee");
            }
            if (Class1.kntrl(Request.QueryString["id"].ToString()) == true)
            {
                Label2.Visible = true;
                Label1.Visible = false;
                OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
                baglanti.Open();
                string kk = Request.QueryString["id"].ToString();
                OleDbCommand cek = new OleDbCommand("select * from uye where nick='" + kk + "'", baglanti);
                OleDbDataReader yaz = cek.ExecuteReader();
                while (yaz.Read())
                {
                    bnick.Text =yaz[0].ToString();
                    blgad.Text =Class1.nokta(yaz[1].ToString(),12);
                    blgsad.Text = Class1.nokta(yaz[2].ToString(), 12);
                    bcins.Text = yaz[4].ToString();
                    Image1.ImageUrl = yaz[5].ToString();
                }
                if (bcins.Text == "BAY")
                    bcins.ForeColor = System.Drawing.Color.Aqua;
                else
                    bcins.ForeColor = System.Drawing.Color.Pink;
                Image1.Visible = true;
                Table1.Visible = true;
                if (Session["kul"] != null)
                {
                    if (Session["kul"].ToString() == kk.ToUpper())
                        duzen.Visible = true;
                }

                // 1 sayfada kaç kişi görünücek
                int kac = 4;
                //Null deyimini kullan.
                OleDbCommand sec;
                sec = new OleDbCommand("select nick,baslik,trh,id from entry where nick='"+Request.QueryString["id"].ToUpper()+"' order by trh desc", baglanti);
                OleDbDataReader yx = sec.ExecuteReader();
                StringBuilder hep = new StringBuilder();
                int d_page = 1;
                int d_kac = 0;
                int pp = 1;
                int sayac_kac = 1;
                if (Request.QueryString["page"] != null)
                    pp = Convert.ToInt32(Request.QueryString["page"]);

                while (yx.Read())
                {
                    if ((pp == d_page) && (d_kac < kac))
                    {
                        d_kac += 1;
                        hep.Append("<a href=\"entry.aspx?id="+yx[3].ToString()+"\" class=\"a\"><div class=\"b_baslik\"><table><tr><th>Başlık</th><td>" +Class1.br(yx[1].ToString(),30) + "</td></tr><tr><th>Tarih</th><td>" + yx[2].ToString() + "</td></tr></table></div></a>");
                        if (d_kac == kac)
                            break;
                    }
                    else if (kac == sayac_kac)
                    {
                        sayac_kac = 0;
                        d_page += 1;
                    }
                    sayac_kac += 1;
                }

                yaz.Close();
                baglanti.Close();
                gom.Text = hep.ToString();
                sayfa.Text = Class1.kutu_p("nick", "entry", kac, "profile.aspx",Request.QueryString["id"].ToString().ToUpper());
                if (gom.Text == "")
                    gom.Text = "<h2 style=\"padding-left:30px;\">Bu kullanıcı hiç entry girmemiş.</h2>";
            }
        }
        catch (Exception)
        {
        }
    }

    protected void duzen_Click(object sender, EventArgs e)
    {
        if (duzen.Text == "Düzenle")
        {
            Table3.Visible = true;
            Table2.Visible = true;
            duzen.Text = "Geri";
            islem.Visible = false;
        }
        else
        {
            Table3.Visible = false;
            Table2.Visible = false;
            duzen.Text = "Düzenle";
        }
    }
    protected void ad_click(object sender, EventArgs e)
    {
        ls.Text = "Ad: ";
        lys.Text = "Yeni Ad: ";
        ld.Text = blgad.Text;
        tdd.Visible = true;
        //Label
        ld.Visible = true;
        //Buttonlar
        kad.Visible = true;
        ksad.Visible = false;
        ksifre.Visible = false;
        kcins.Visible = false;
        kresim.Visible = false;
        //radio button
        RadioButton1.Visible = false;
        RadioButton2.Visible = false;
        RadioButton3.Visible = false;
        RadioButton4.Visible = false;
        //Image
        Image2.Visible = false;
    }
    protected void sad_click(object sender, EventArgs e)
    {
        ls.Text = "Soyad: ";
        lys.Text = "Yeni Soyad: ";
        ld.Text = blgsad.Text;
        tdd.Visible = true;
        //Label
        ld.Visible = true;
        //Buttonlar        
        kad.Visible = false;
        ksad.Visible = true;
        ksifre.Visible = false;
        kcins.Visible = false;
        kresim.Visible = false;
        //radio button
        RadioButton1.Visible = false;
        RadioButton2.Visible = false;
        RadioButton3.Visible = false;
        RadioButton4.Visible = false;
        //Image
        Image2.Visible = false;
    }
    protected void sifre_click(object sender, EventArgs e)
    {
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand sorgu = new OleDbCommand("select sifre from uye where nick='" + Session["kul"].ToString() + "'", baglanti);
        OleDbDataReader sfr = sorgu.ExecuteReader();
        sfr.Read();
        string ss = sfr[0].ToString();
        baglanti.Close();
        ls.Text = "Şifre: ";
        lys.Text = "Yeni Şifre: ";
        ld.Text = ss;
        tdd.Visible = true;
        //Label
        ld.Visible = true;
        //Buttonlar
        kad.Visible = false;
        ksad.Visible = false;
        ksifre.Visible = true;
        kcins.Visible = false;
        kresim.Visible = false;
        //radio button
        RadioButton1.Visible = false;
        RadioButton2.Visible = false;
        RadioButton3.Visible = false;
        RadioButton4.Visible = false;
        //Image
        Image2.Visible = false;
    }
    protected void cins_click(object sender, EventArgs e)
    {
        ls.Text = "Cins: ";
        lys.Text = "Yeni Cins: ";
        ld.Text = bcins.Text;
        tdd.Visible = false;
        //Label
        ld.Visible = true;
        //Buttonlar
        kad.Visible = false;
        ksad.Visible = false;
        ksifre.Visible = false;
        kcins.Visible = true;
        kresim.Visible = false;
        //radio button
        RadioButton1.Visible = true;
        RadioButton2.Visible = true;
        RadioButton3.Visible = false;
        RadioButton4.Visible = false;
        //Image
        Image2.Visible = false;
        //radio ayari
        RadioButton1.Text = "BAY";
        RadioButton2.Text = "BAYAN";
        if (bcins.Text == "BAY")
            RadioButton1.Checked = true;
        else
            RadioButton2.Checked = true;
    }
    protected void resim_click(object sender, EventArgs e)
    {
        ls.Text = "Resim: ";
        lys.Text = "Yeni Resim: ";
        Image2.ImageUrl = Image1.ImageUrl.ToString();
        //text
        tdd.Visible = false;
        //Label
        ld.Visible = false;
        //Buttonlar
        kad.Visible = false;
        ksad.Visible = false;
        ksifre.Visible = false;
        kcins.Visible = false;
        kresim.Visible = true;
        //radio button
        RadioButton1.Visible = true;
        RadioButton2.Visible = true;
        RadioButton3.Visible = true;
        RadioButton4.Visible = true;
        //Image
        Image2.Visible = true;
        //radio ayari
        RadioButton1.Text = "Köpek";
        RadioButton2.Text = "Güneş";
        RadioButton3.Text = "Deniz";
        RadioButton4.Text = "Gül";
        if (Image1.ImageUrl.ToString() == "~/profile/dog.jpg")
            RadioButton1.Checked = true;
        else if (Image1.ImageUrl.ToString() == "~/profile/sun.jpg")
            RadioButton2.Checked = true;
        else if (Image1.ImageUrl.ToString() == "~/profile/water.jpg")
            RadioButton3.Checked = true;
        else if (Image1.ImageUrl.ToString() == "~/profile/rose.jpg")
            RadioButton4.Checked = true;

    }
    protected void kad_click(object sender, EventArgs e)
    {
        Class1.guncelle("ad", tdd.Text, Session["kul"].ToString());
        Session["islem"] = true;
        Response.Redirect("profile.aspx?id=" + Session["kul"]);       
    }
    protected void ksad_click(object sender, EventArgs e)
    {
        Class1.guncelle("sad", tdd.Text, Session["kul"].ToString());
        Session["islem"] = true;
        Response.Redirect("profile.aspx?id=" + Session["kul"]);
    }
    protected void ksifre_click(object sender, EventArgs e)
    {
        Class1.guncelle("sifre", tdd.Text, Session["kul"].ToString());
        Session["islem"] = true;
        Response.Redirect("profile.aspx?id=" + Session["kul"]);
    }
    protected void kcins_click(object sender, EventArgs e)
    {
        string cc = "";
        if (RadioButton1.Checked)
            cc = "BAY";
        else if (RadioButton2.Checked)
            cc = "BAYAN";
        Class1.guncelle("cins",cc, Session["kul"].ToString());
        Session["islem"] = true;
        Response.Redirect("profile.aspx?id=" + Session["kul"]);
    }
    protected void kresim_click(object sender, EventArgs e)
    {
        Class1.guncelle("resim",Image2.ImageUrl.ToString(), Session["kul"].ToString());
        Session["islem"] = true;
        Response.Redirect("profile.aspx?id=" + Session["kul"]);
    }
    protected void radio1_click(object sender,EventArgs e)
    {
        Image2.ImageUrl = "~/profile/dog.jpg";
    }
    protected void radio2_click(object sender, EventArgs e)
    {
        Image2.ImageUrl = "~/profile/sun.jpg";
    }
    protected void radio3_click(object sender, EventArgs e)
    {
        Image2.ImageUrl = "~/profile/water.jpg";
    }
    protected void radio4_click(object sender, EventArgs e)
    {
        Image2.ImageUrl = "~/profile/rose.jpg";
    }
}