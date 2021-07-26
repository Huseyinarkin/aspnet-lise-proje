using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        only.Text= Convert.ToString(Application["KS"]);
        if (Session["kul"]!=null)
        {
            solup.Text = Session["kul"].ToString();
            sagup.Text = "Çıkış";
            HyperLink3.Visible = true;
        }
        else if(Session["kul"]==null)
        {
            solup.Text = "Üye Giriş";
            sagup.Text = "Kayıt Ol";
        }
    }

    protected void solup_click(object sender, EventArgs e)
    {
        if (solup.Text == "Üye Giriş")
            Response.Redirect("gir.aspx");
        else
            Response.Redirect("profile.aspx?id=" + Session["kul"].ToString());
    }

    protected void sagup_click(object sender, EventArgs e)
    {
        if (sagup.Text == "Kayıt Ol")
            Response.Redirect("kayit.aspx");
        else
        {
            Session.Remove("kul");
            Response.Redirect("default.aspx");
        }
    }
}
