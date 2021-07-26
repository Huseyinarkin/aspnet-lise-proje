using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;

public partial class entry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            if (Class1.kntrl_b(Request.QueryString["id"]) == true)
            {
                OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
                baglanti.Open();
                OleDbCommand hh = new OleDbCommand("select nick,baslik,konu,trh from entry where id=" + Request.QueryString["id"].ToString() + "", baglanti);
                OleDbDataReader kk = hh.ExecuteReader();
                kk.Read();
                bool bgn_kul = false;
                if (Session["kul"] != null)
                {
                    bgn_kul = true;
                    if ((Session["kul"].ToString() == kk[0].ToString())||(Class1.admin(Session["kul"].ToString())==true))
                    {
                        p2.Visible = true;
                    }
                }
                bgn_ekle(bgn_kul);
                int wid = kk[0].ToString().Length * 15;
                wid += 60;
                Literal1.Text = "<div class=\"e_p\" style=\"width:" + wid + "px\"><a href=\"profile.aspx?id=" + kk[0].ToString() + "\"><img src=\"" + Class1.photo(kk[0].ToString()) + "\" /><span>" + kk[0].ToString() + "</span></a></div><div class=\"e_i\"><div class=\"e_i_b\">" + Class1.br(kk[1].ToString(), 25) + "</div><p>" + Class1.br(kk[2].ToString(), 52) + "</p><div class=\"eia\"><span>" + kk[3].ToString() + "</span></div></div>";
                kk.Close();
                baglanti.Close();
            }
            else
                ee.Visible = false;
        }
        else
            ee.Visible = false;
    }
    protected void begen(object sender, EventArgs e)
    {
        Class1.begen_button(Session["kul"].ToString(), Request.QueryString["id"].ToString());
        Response.Redirect("entry.aspx?id=" + Request.QueryString["id"].ToString());
    }
    protected void ayar(object sender, EventArgs e)
    {
        if (bdzn.Visible == false)
        {
            bdzn.Visible = true;
            bsil.Visible = true;
        }
        else
        {
            bdzn.Visible = false;
            bsil.Visible = false;
        }
    }
    protected void sil(object sender, EventArgs e)
    {
        Class1.entry_sil(Request.QueryString["id"].ToString());
        Session["ee"] = true;
        Response.Redirect("profile.aspx?id=" + Session["kul"].ToString());

    }
    protected void dznle(object sender, EventArgs e)
    {
        Session["d"] = Request.QueryString["id"].ToString();
        Response.Redirect("paylas.aspx");
    }
    public void bgn_ekle(bool kul)
    {
        Button btn = new Button();
        btn.CssClass = "bgn";
        btn.Text = "Begen " + " " + " " + Class1.begen_kac(Request.QueryString["id"].ToString());
        btn.ID = "bbggnn";
        if (kul == true)
        {
            btn.Click += new EventHandler(begen);
            if (Class1.begen_knt(Session["kul"].ToString(), Request.QueryString["id"].ToString()) == true)
                btn.ForeColor = System.Drawing.Color.Blue;
        }
        else
            btn.Enabled = false;
        p1.Controls.Add(btn);
    }
}