using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Contact : Page
{
    protected void pushSearch(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

        con.Open();

        cmd = new SqlCommand("select * from Subiecte", con);
        List<string> subiecte = new List<string>();
        List<string> idd = new List<string>();
        List<string> ids = new List<string>();


        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);


        foreach (DataRow row in dt.Rows)
        {
            subiecte.Add(row["subiect"].ToString());
            idd.Add(row["id_domeniu"].ToString());
            ids.Add(row["id"].ToString());
        }

        con.Close();

        string sub = searchBox.Text;

        for (var i = 0; i < subiecte.Count; ++i)
        {
            if (subiecte[i] == sub)
            {
                Global.ImportantData2 = ids[i];
                Response.Redirect("Comentarii.aspx"); 
            }
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {


    }
}