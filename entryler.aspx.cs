using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;

public partial class entryler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 1 sayfada kaç kişi görünücek
        int kac = 5;
        //Null deyimini kullan.
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand sec;
        sec = new OleDbCommand("select nick,baslik,trh,id from entry order by trh desc", baglanti);
        OleDbDataReader yaz = sec.ExecuteReader();
        StringBuilder hep = new StringBuilder();
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
                hep.Append("<a href=\"entry.aspx?id="+yaz[3].ToString()+"\"><div class=\"b_baslik\"><table><tr><th>Başlık</th><td>"+Class1.br(yaz[1].ToString(),30)+"</td></tr><tr><th>Yazar</th><td>"+yaz[0].ToString()+"</td></tr><tr><th>Tarih</th><td>"+yaz[2].ToString()+"</td></tr></table></div></a>");
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
        sayfa.Text = Class1.kutu_sayfa("nick", "entry", kac, "entryler.aspx");
    }
}