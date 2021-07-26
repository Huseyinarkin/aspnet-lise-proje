using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class kayit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void kprofile_Kontrol(object sender, EventArgs e)
    {
        if (kprofile1.Checked)
            Image1.ImageUrl = "~/profile/water.jpg";
        if (kprofile2.Checked)
            Image1.ImageUrl = "~/profile/sun.jpg";
        if (kprofile3.Checked)
            Image1.ImageUrl = "~/profile/dog.jpg";
        if (kprofile4.Checked)
            Image1.ImageUrl = "~/profile/rose.jpg";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        string c;
        if (cins1.Checked)
            c = "BAY";
        else
            c = "BAYAN";
        switch (Class1.ekle_uye(Textnick.Text, Textad.Text, Textsad.Text, Textsfr.Text, c, Image1.ImageUrl))
        {
            case "0":
                Session["kul"] = Textnick.Text.ToUpper();
                Response.Redirect("profile.aspx?id=" + Session["kul"].ToString());
                break;
            case "1":
                Label1.Text = "Böyle bir NİCK var.";
                Textnick.Focus();
                break;
            case "2":
                Label2.Text = "Yanlış karakter girdiniz.";
                break;
        }
    }
}