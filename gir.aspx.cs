using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Class1.gir(Textnick.Text, Textsfr.Text) == true)
        {
            Session["kul"] = Textnick.Text.ToUpper();
            Response.Redirect("profile.aspx?id="+Textnick.Text.ToUpper());
        }
        else
            Label1.Text = "Yanlış <br /> ŞİFRE veya NİCK";
    }
}