using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class paylas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["d"]!=null)
        {
            baslik.Enabled = false;
            baslik.Text = Class1.e_cek(Session["d"].ToString(),"baslik");
            entry.Text = Class1.e_cek(Session["d"].ToString(), "konu");
            p_button.Visible = false;
            Button1.Visible = true;
            degisken.Text = Session["d"].ToString();
            Session.Remove("d");
        }
        else
        {
            if (Session["kul"] == null)
            {
                Table1.Visible = false;
                Label1.Visible = true;
            }
        }
    }

    protected void p_button_Click(object sender, EventArgs e)
    {
        Label2.Text = "";
        if ((baslik.Text != "") && (entry.Text != ""))
        {
            if (Class1.ekle_entry(Session["kul"].ToString(), baslik.Text.ToUpper(), entry.Text) == true)
            {
                OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
                baglanti.Open();
                OleDbCommand yy = new OleDbCommand("select id from entry where nick='" + Session["kul"].ToString() + "' order by trh desc", baglanti);
                OleDbDataReader yaz = yy.ExecuteReader();
                yaz.Read();
                string id = yaz[0].ToString();
                yaz.Close();
                baglanti.Close();
                Response.Redirect("entry.aspx?id=" + id);
            }
            else
                Label2.Text = "Tırnak işaretlerini kullanmayın.";
        }
        else
            Label2.Text = "Paylaşmak için birşeyler yazın.";
    }
    protected void p_button_degis(object sender, EventArgs e)
    {
        Class1.e_dzn(degisken.Text, entry.Text);
        Response.Redirect("entry.aspx?id=" + degisken.Text);
    }

}