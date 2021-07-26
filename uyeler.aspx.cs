using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;

public partial class uyeler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 1 sayfada kaç kişi görünücek
        int kac = 3;
        //Null deyimini kullan.
        aramasonuc.Text = "";
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand sec;
        if (Request.QueryString["ara"] != null)
        {
            if (Class1.kntrl(Request.QueryString["ara"].ToString()) == true)
            {
                sec = new OleDbCommand("select nick,ad,Mid(soyad,1,7),cins,Mid(photo,3,50) from uye where nick='" + Request.QueryString["ara"].ToString() + "'", baglanti);
            }
            else
            {
                aramasonuc.Text = "Böyle bir nick yok";
                sec = new OleDbCommand("select nick,ad,Mid(soyad,1,7),cins,Mid(photo,3,50) from uye", baglanti);
            }
        }
        else
            sec = new OleDbCommand("select nick,ad,soyad,cins,Mid(photo,3,50) from uye", baglanti);
        OleDbDataReader yaz = sec.ExecuteReader();
        StringBuilder hep = new StringBuilder();
        string rnk;
        int d_page = 1;
        int d_kac = 0;
        int pp = 1;
        int sayac_kac = 1;
        if (Request.QueryString["page"] != null)
            pp = Convert.ToInt32(Request.QueryString["page"]);

        while (yaz.Read())
        {
            if ((pp == d_page) && (d_kac < kac))
            {
                d_kac += 1;
                if (yaz[3].ToString() == "BAY")
                    rnk = "aqua";
                else
                    rnk = "Pink";
                hep.Append("<a href=\"profile.aspx?id=" + yaz[0] + "\"><div class=\"gomulu\"><img src=" + yaz[4] + " /><table><tr><td>"+Class1.nokta(yaz[1].ToString(),12) +"<br />"+ Class1.nokta(yaz[2].ToString(),12) + "</td><td><font color=" + rnk + ">" + yaz[0] + "</font></td></tr></table></div></a>");
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
        sayfa.Text = Class1.kutu_sayfa("nick","uye",kac,"uyeler.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        aramasonuc.Text = "";
        Response.Redirect("uyeler.aspx?ara=" + TextBox1.Text);
    }
}