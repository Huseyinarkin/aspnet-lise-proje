using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    public Class1()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string ekle_uye(string nick, string ad, string soyad, string sifre, string cins, string resim)
    {
        string e;
        try
        {
            if (kntrl(nick) == false)
            {
                OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
                baglanti.Open();
                OleDbCommand ekle = new OleDbCommand("insert into uye(nick,ad,soyad,sifre,cins,photo) values('" + nick.ToUpper() + "','" + ad + "','" + soyad + "','" + sifre + "','" + cins + "','" + resim + "')", baglanti);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                e = "0";
            }
            else
                e = "1";
            return e;
        }
        catch
        {
            e = "2";
            return e;
        }
    }
    public static bool admin(string nick)
    {
        bool sonuc = false;
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand ss = new OleDbCommand("select admin from uye where nick='"+nick+"'",baglanti);
        OleDbDataReader aa = ss.ExecuteReader();
        aa.Read();
        if (aa[0].ToString() == "1")
            sonuc = true;
        aa.Close();
        baglanti.Close();
        return sonuc;
    }
    public static bool ekle_entry(string nick, string baslik, string konu)
    {
        bool gg = false;
        try
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand kk = new OleDbCommand("insert into entry(nick,baslik,konu,trh) values('" + nick.ToString() + "','" + baslik.ToString().ToUpper() + "','" + konu.ToString() + "',Now())", baglanti);
            kk.ExecuteNonQuery();
            baglanti.Close();
            gg = true;
            return gg;
        }
        catch
        {
            return gg;
        }
    }
    public static bool kntrl(string nick)
    {
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand kk = new OleDbCommand("select nick from uye", baglanti);
        OleDbDataReader oku = kk.ExecuteReader();
        bool gg = false;
        while (oku.Read())
        {
            if (oku[0].ToString().ToUpper() == nick.ToUpper())
                gg = true;
        }
        baglanti.Close();
        return gg;
    }
    public static bool kntrl_b(string b)
    {
        bool gg = false;
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand kk = new OleDbCommand("select id from entry", baglanti);
        OleDbDataReader oku = kk.ExecuteReader();
        while (oku.Read())
        {
            if (oku[0].ToString() == b)
            {
                gg = true;
                break;
            }
        }
        oku.Close();
        baglanti.Close();
        return gg;
    }
    public static bool gir(string nick, string sfr)
    {
        bool sonuc;
        if (kntrl(nick) == true)
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand sf = new OleDbCommand("select sifre from uye where nick='" + nick + "'", baglanti);
            OleDbDataReader es = sf.ExecuteReader();
            es.Read();
            if (es[0].ToString() == sfr)
                sonuc = true;
            else
                sonuc = false;
            baglanti.Close();
            return sonuc;
        }
        else
            sonuc = false;
        return sonuc;

    }
    public static void guncelle(string ne, string tt, string nick)
    {
        if (ne == "ad")
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand gg = new OleDbCommand("update uye set ad='" + tt + "' where nick='" + nick + "'", baglanti);
            gg.ExecuteNonQuery();
            baglanti.Close();
        }
        else if (ne == "sad")
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand gg = new OleDbCommand("update uye set soyad='" + tt + "' where nick='" + nick + "'", baglanti);
            gg.ExecuteNonQuery();
            baglanti.Close();
        }
        else if (ne == "sifre")
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand gg = new OleDbCommand("update uye set sifre='" + tt + "' where nick='" + nick + "'", baglanti);
            gg.ExecuteNonQuery();
            baglanti.Close();
        }
        else if (ne == "cins")
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand gg = new OleDbCommand("update uye set cins='" + tt + "' where nick='" + nick + "'", baglanti);
            gg.ExecuteNonQuery();
            baglanti.Close();
        }
        else if (ne == "resim")
        {
            OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
            baglanti.Open();
            OleDbCommand gg = new OleDbCommand("update uye set photo='" + tt + "' where nick='" + nick + "'", baglanti);
            gg.ExecuteNonQuery();
            baglanti.Close();
        }
    }
    public static int sayfa(string alan, string tablo, int gorunen, string sorgu)
    {
        int page = 0;
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand sec = new OleDbCommand();
        if (sorgu == null)
        {
            sec.Connection = baglanti;
            sec.CommandText = "select count(" + alan + ") from " + tablo + "";
        }
        else
        {
            sec.Connection = baglanti;
            sec.CommandText = "select count(" + alan + ") from " + tablo + " where nick='" + sorgu + "'";
        }
        OleDbDataReader yy = sec.ExecuteReader();
        yy.Read();
        int stun = Convert.ToInt32(yy[0]);
        while (stun > gorunen)
        {
            page += 1;
            stun = stun - gorunen;
        }
        if (stun != 0)
            page += 1;
        baglanti.Close();
        return page;
    }
    public static string kutu_sayfa(string alan, string tablo, int gorunen, string sayfa)
    {
        int pp = Class1.sayfa(alan, tablo, gorunen, null);
        StringBuilder s_p = new StringBuilder();
        if (pp.ToString() != null)
        {
            for (int ss = 1; ss <= pp; ss++)
            {
                s_p.Append("<a href=\"" + sayfa + "?page=" + ss + "\"><span>" + ss + "</span></a>");
            }
        }
        return s_p.ToString();
    }
    public static string kutu_p(string alan, string tablo, int gorunen, string sayfa, string nick)
    {
        int pp = Class1.sayfa(alan, tablo, gorunen, nick);
        StringBuilder s_p = new StringBuilder();
        if (pp.ToString() != null)
        {
            for (int ss = 1; ss <= pp; ss++)
            {
                s_p.Append("<a href=\"" + sayfa + "?id=" + nick + "&page=" + ss + "\"><span>" + ss + "</span></a>");
            }
        }
        return s_p.ToString();
    }
    public static string br(string yazi, byte uzunluk)
    {
        if (yazi.Length > uzunluk)
        {
            string son = "";
            byte space = 0;
            int s = 0;
            int don = yazi.Length / uzunluk;
            for (byte g = 1; g <= don; g++)
            {
                space = 0;
                while (s < g * uzunluk)
                {
                    if (yazi[s].ToString() == " ")
                        space += 1;
                    son += yazi[s].ToString();
                    s += 1;
                }
                if (space == 0)
                    son += "<br/>";
            }
            while (s < yazi.Length)
            {
                son += yazi[s].ToString();
                s += 1;
            }
            return son;
        }
        else
            return yazi;
    }
    public static string photo(string nick)
    {
        string resim = "";
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand ss = new OleDbCommand("select Mid(photo,3,50) from uye where nick='" + nick + "'", baglanti);
        OleDbDataReader s1 = ss.ExecuteReader();
        s1.Read();
        resim = s1[0].ToString();
        s1.Close();
        baglanti.Close();
        return resim;
    }
    public static bool begen_knt(string nick, string id)
    {
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand kk = new OleDbCommand("select id from begen where nick='" + nick + "'", baglanti);
        OleDbDataReader k1 = kk.ExecuteReader();
        bool bb = false;
        while (k1.Read())
        {
            if (k1[0].ToString() == id.ToString())
            {
                bb = true;
                break;
            }

        }
        k1.Close();
        baglanti.Close();
        return bb;
    }
    public static bool begen_button(string nick, string id)
    {
        bool son = false;
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        if (Class1.begen_knt(nick,id) == false)
        {
            
            OleDbCommand ek = new OleDbCommand("insert into begen(id,nick) values(" + id + ",'" + nick + "')",baglanti);
            ek.ExecuteNonQuery();
            son = true;
            
        }
        else
        {
            OleDbCommand sil = new OleDbCommand("delete from begen where id="+id+" and nick='"+nick+"'",baglanti);
            sil.ExecuteNonQuery();
        }
        baglanti.Close();
        return son;
    }
    public static string begen_kac(string id)
    {
        string kac;
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand tt = new OleDbCommand("select COUNT(id) from begen where id="+id+"", baglanti);
        OleDbDataReader t1 = tt.ExecuteReader();
        t1.Read();
        kac = t1[0].ToString();
        t1.Close();
        baglanti.Close();
        return kac;
    }
    public static string nokta(string yazi,int max)
    {
        string son="";
        if (yazi.Length > max)
        {
            int gg = 0;
            while (gg < max-3)
            {
                son += yazi[gg].ToString();
                gg += 1;
            }
            son += "...";
        }
        else
            son = yazi;
        return son;
        //Üç nokta konulucak.
    }
    public static void entry_begen_sil(string id)
    {
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand bb = new OleDbCommand("delete from begen where id="+id+"",baglanti);
        bb.ExecuteNonQuery();
        baglanti.Close();
    }
    public static void entry_sil(string id)
    {
        entry_begen_sil(id);
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand ee = new OleDbCommand("delete from entry where id="+id+"",baglanti);
        ee.ExecuteNonQuery();
        baglanti.Close();
    }
    public static string e_cek(string id,string cek)
    {
        string son = "";
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand bb = new OleDbCommand("select "+cek+" from entry where id=" + id + "", baglanti);
        OleDbDataReader bby = bb.ExecuteReader();
        bby.Read();
        son = bby[0].ToString();
        bby.Close();
        baglanti.Close();
        return son;
    }
    public static void e_dzn(string id,string dd)
    {
        OleDbConnection baglanti = new OleDbConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cdb"].ConnectionString);
        baglanti.Open();
        OleDbCommand deg = new OleDbCommand("update entry set konu='"+dd+"' where id="+id+"", baglanti);
        deg.ExecuteNonQuery();
        baglanti.Close();
    }
}