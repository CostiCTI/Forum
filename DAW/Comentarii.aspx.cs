using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;

public partial class Comentarii : System.Web.UI.Page
{
    private List<TextBox> tex = new List<TextBox>();


    protected void tapDelete(object sender, EventArgs e)
    {
        Button myButton = (Button)sender;
        string id2 = myButton.ID;
        string id = id2.Remove(id2.Length - 1);
        string k = myButton.CommandArgument;
        int n = int.Parse(k);

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        string command = "DELETE FROM Comentarii WHERE id =" + id;

        con.Open();
        using (SqlCommand cmd = new SqlCommand(command, con))
        {
            cmd.ExecuteNonQuery();
        }

        con.Close();

        Response.Redirect("Comentarii.aspx");
    }


    protected void tapEdit(object sender, EventArgs e)
    {
        Button myButton = (Button)sender;
        string id = myButton.ID;

        string newCom = "zzz";
        string k = myButton.CommandArgument;
        int n = int.Parse(k);
        newCom = tex[n].Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        string command = "UPDATE Comentarii SET comentariu = @cm WHERE id=" + id;

        con.Open();
        using (SqlCommand cmd = new SqlCommand(command, con))
        {
            cmd.Parameters.AddWithValue("@cm", newCom);
            cmd.ExecuteNonQuery();
        }

        con.Close();

        Response.Redirect("Comentarii.aspx");


    }

    protected void addComment(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        string command = "insert into Comentarii values(@comment,@ids, @iduser, @dat)";

        int id_sub = int.Parse(Global.ImportantData2);
        TextBox t = (TextBox)(LoginView1.FindControl("testB"));
        string text = t.Text;
        string uname = Context.User.Identity.GetUserName().ToString();
        t.Text = "";
        con.Open();

        string userId = "";

        SqlCommand c = new SqlCommand("select Id from AspNetUsers where UserName=" + "'" + uname + "'", con);
       

        SqlDataReader dr = c.ExecuteReader();

        while (dr.Read())
        {
            userId = dr[0].ToString();
        }

        dr.Close();
        con.Close();
        con.Open();
        using (SqlCommand cmd = new SqlCommand(command, con))
            {
                cmd.Parameters.AddWithValue("@comment", text);
                cmd.Parameters.AddWithValue("@ids", id_sub);
                cmd.Parameters.AddWithValue("@iduser", uname);
                cmd.Parameters.AddWithValue("@dat", DateTime.Now);
                cmd.ExecuteNonQuery();
            }

        con.Close();
        

        Response.Redirect("Comentarii.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string s = Global.ImportantData2;


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

        con.Open();
        Int32 idd = Int32.Parse(s);
        cmd = new SqlCommand("select * from Comentarii where id_subiect=" + "'" + idd + "'", con);
        List<string> coms = new List<string>();
        List<string> idsdom = new List<string>();
        List<string> ids = new List<string>();
        List<string> users = new List<string>();
        List<string> dates = new List<string>();


        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);


        foreach (DataRow row in dt.Rows)
        {
            coms.Add(row["comentariu"].ToString());
            idsdom.Add(row["id_subiect"].ToString());
            ids.Add(row["id"].ToString());
            users.Add(row["user_name"].ToString());
            dates.Add(row["data"].ToString());
        }

        con.Close();

        for (var i = 0; i < coms.Count; ++i)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl h5 =
            new System.Web.UI.HtmlControls.HtmlGenericControl("h5");

            h5.InnerHtml = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + coms[i];


            System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDiv.Style.Add("height", "80px");
            createDiv.Style.Add("border", "1px solid #CCC");

            createDiv.Controls.Add(h5);

            createDiv.Style.Add("color", "red");
            createDiv.Style.Add("text-decoration", "none");
            createDiv.Style.Add("background", "#DDD");
            createDiv.Style.Add("box-shadow", "0 0 5px -1px rgba(0, 0, 0, 0.2)");

            Session["color"] = "yellow";
            createDiv.Attributes.Add("ID", "com" + i);
            createDiv.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='" + Session["color"].ToString() + "'");
            createDiv.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#DDD'");


            System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

            System.Web.UI.HtmlControls.HtmlGenericControl h =
            new System.Web.UI.HtmlControls.HtmlGenericControl("h4");
            
            h.InnerHtml = users[i] + "   *   " + dates[i];


            
            Button btn = new Button();
            
            btn.Text = "Edit";
            btn.CssClass = "btn";

            string uname = Context.User.Identity.GetUserName().ToString();
            btn.ID = ids[i];
            btn.CommandArgument = i.ToString();
            btn.Click += new EventHandler(this.tapEdit);
            btn.Style.Add("background", "red");
            btn.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='" + "green" + "'");
            btn.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='red'");
            btn.Style.Add("text-decoration", "overline");
            btn.Style.Add("cursor", "pointer");
            btn.Visible = false;
            string str = Context.User.Identity.GetUserName();

            TextBox tb = new TextBox();
            tb.ID = ids[i] + "t";
            tb.Attributes.Add("runat", "server");
            tb.Visible = false;

            tex.Add(tb);
            if (users[i] == str)
            {
                btn.Visible = true;
                tb.Visible = true;
            }

            Button btn2 = new Button();
            btn2.ID = ids[i] + "x";
            btn2.CommandArgument = i.ToString();
            btn2.Click += new EventHandler(this.tapDelete);
            btn2.Style.Add("background", "yellow");
            

            btn2.Text = "Delete";
            btn2.CssClass = "btn";
            // ----------------------------
            btn2.Visible = User.IsInRole("moderator");
            // ----------------------------

            newDiv.Controls.Add(h);
            newDiv.Controls.Add(createDiv);
            newDiv.Controls.Add(btn);
            comdiv.Controls.Add(new LiteralControl("<br>"));
            newDiv.Controls.Add(tb);

            comdiv.Controls.Add(new LiteralControl("<br>"));
            newDiv.Controls.Add(btn2);

            comdiv.Controls.Add(newDiv);


            comdiv.Controls.Add(new LiteralControl("<br>"));
            comdiv.Controls.Add(new LiteralControl("<br>"));
        }
    }
}