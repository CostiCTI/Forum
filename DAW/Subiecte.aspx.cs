using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Subiecte : System.Web.UI.Page
{
    protected void addSubject(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        string command = "insert into Subiecte values(@sub, @iddom)";

        int id_dom = int.Parse(Global.ImportantData);
        TextBox t = (TextBox)(LoginView2.FindControl("testA"));
        string text = t.Text;
        t.Text = "";

        con.Open();
        using (SqlCommand cmd = new SqlCommand(command, con))
        {
            cmd.Parameters.AddWithValue("@sub", text);
            cmd.Parameters.AddWithValue("@iddom", id_dom);
            cmd.ExecuteNonQuery();
        }

        con.Close();

        Response.Redirect("Subiecte.aspx");
    }



    protected void tapSubject(object sender, EventArgs e)
    {
        Button myButton = (Button)sender;

        Global.ImportantData2 = myButton.CommandArgument.ToString();
        Response.Redirect("Comentarii.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //int x = _Default.stat;
        string s = Global.ImportantData;


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

        con.Open();
        Int32 idd = Int32.Parse(s);
        cmd = new SqlCommand("select * from Subiecte where id_domeniu=" + "'" + idd + "'", con);
        List<string> subjects = new List<string>();
        List<string> idsdom = new List<string>();
        List<string> ids = new List<string>();


        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);


        foreach (DataRow row in dt.Rows)
        {
            subjects.Add(row["subiect"].ToString());
            idsdom.Add(row["id_domeniu"].ToString());
            ids.Add(row["id"].ToString());
        }

        con.Close();

        for (var i = 0; i < subjects.Count; ++i)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl h4 =
            new System.Web.UI.HtmlControls.HtmlGenericControl("h4");

            h4.InnerHtml = "&nbsp;&nbsp;&nbsp;" + subjects[i];


            System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDiv.Style.Add("height", "80px");
            createDiv.Style.Add("border", "1px solid #CCC");

            createDiv.Controls.Add(h4);

            createDiv.Style.Add("color", "red");
            createDiv.Style.Add("text-decoration", "none");
            createDiv.Style.Add("background", "#DDD");
            //createDiv.Style.Add("cursor", "pointer");
            createDiv.Style.Add("box-shadow", "0 0 5px -1px rgba(0, 0, 0, 0.2)");

            Session["color"] = "yellow";
            createDiv.Attributes.Add("ID", "subiect" + i);
            createDiv.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='" + Session["color"].ToString() + "'");
            createDiv.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#DDD'");

            subdiv.Controls.Add(createDiv);

            Button btn = new Button();
            btn.ID = ids[i];
            btn.Text = "Comment";
            btn.CssClass = "btn";
            btn.CommandArgument = btn.ID;
            btn.Click += new EventHandler(this.tapSubject);
            btn.Style.Add("background", "red");
            btn.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='" + "green" + "'");
            btn.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='red'");
            btn.Style.Add("text-decoration", "overline");
            btn.Style.Add("cursor", "pointer");
            subdiv.Controls.Add(btn);

            subdiv.Controls.Add(new LiteralControl("<br>"));
            subdiv.Controls.Add(new LiteralControl("<br>"));
        }
    }
}