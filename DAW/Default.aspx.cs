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

public partial class _Default : Page
{
    protected void addDomeniu(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        string command = "insert into Domenii values(@dom, @desc)";
        
        TextBox t = (TextBox)(LoginView3.FindControl("testD"));
        string text = t.Text;
        t.Text = "";

        TextBox tt = (TextBox)(LoginView3.FindControl("testE"));
        string textt = tt.Text;
        tt.Text = "";

        con.Open();
        using (SqlCommand cmd = new SqlCommand(command, con))
        {
            cmd.Parameters.AddWithValue("@dom", text);
            cmd.Parameters.AddWithValue("@desc", textt);
            cmd.ExecuteNonQuery();
        }

        con.Close();

        Response.Redirect("Default.aspx");
    }


    protected void updateTable()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

        string us = Context.User.Identity.GetUserName().ToString();

        con.Open();

        cmd = new SqlCommand("select * from AspNetUsers", con);
        List<string> users = new List<string>();
        List<string> ids = new List<string>();


        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);


        foreach (DataRow row in dt.Rows)
        {
            users.Add(row["UserName"].ToString());
            ids.Add(row["Id"].ToString());
        }

        string id = "";
        for (var i = 0; i < users.Count; ++i)
        {   
            if (users[i].Equals(us))
            {
                id = ids[i];
            }
        }
        con.Close();

        // -----------------------------------------

        if (!us.Equals(""))
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            con.Open();
            cmd = new SqlCommand("select * from AspNetUserRoles where userId=" + "'" + id + "'", con);
            

            DataTable dta = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter(cmd);
            daa.Fill(dta);

            int count = 0;
            foreach (DataRow row in dta.Rows)
            {
                ++count;
            }
            con.Close();

            if (count == 0)
            {
                // ----------------------------------------------
                string command = "insert into AspNetUserRoles values(@uid, @rid)";

                con.Open();
                using (SqlCommand cmdd = new SqlCommand(command, con))
                {
                    cmdd.Parameters.AddWithValue("@uid", id);
                    cmdd.Parameters.AddWithValue("@rid", 3);
                    cmdd.ExecuteNonQuery();
                }

                con.Close();
            }

            con.Open();
            con.Close();
        }
        

        // -----------------------------------------
    }


    private static bool sortate = true;
    protected void sortDomains(object sender, EventArgs e)
    {
        sortate = !sortate;
        Response.Redirect("Default.aspx");
    }

    protected void tapDomain(object sender, EventArgs e)
    {
        Button myButton = (Button)sender;

        Global.ImportantData = myButton.CommandArgument.ToString();
        Response.Redirect("Subiecte.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        updateTable();
        //string us = Context.User.Identity.GetUserName();
        //AspNetUserRoles.AddUserToRole(us, "Customer");

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

        con.Open();

        cmd = new SqlCommand("select * from Domenii", con);
        List<string> domains = new List<string>();
        List<string> descriptions = new List<string>();
        List<string> ids = new List<string>();


        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);


        foreach (DataRow row in dt.Rows)
        {
            domains.Add(row["domeniu"].ToString());
            descriptions.Add(row["descriere"].ToString());
            ids.Add(row["id"].ToString());
        }

        con.Close();

        int n = domains.Count;
        for (int i=0; i<n-1; ++i) {
            for (int j = i+1; j<n; ++j) {
                if (sortate) {
                    int r = string.Compare(domains[i], domains[j]);
                    if (r > 0) {
                        string aux = domains[i];
                        domains[i] = domains[j];
                        domains[j] = aux;
                        aux = descriptions[i];
                        descriptions[i] = descriptions[j];
                        descriptions[j] = aux;
                        aux = ids[i];
                        ids[i] = ids[j];
                        ids[j] = aux;
                    }
                } else
                {
                    int r = string.Compare(domains[i], domains[j]);
                    if (r < 0)
                    {
                        string aux = domains[i];
                        domains[i] = domains[j];
                        domains[j] = aux;
                        aux = descriptions[i];
                        descriptions[i] = descriptions[j];
                        descriptions[j] = aux;
                        aux = ids[i];
                        ids[i] = ids[j];
                        ids[j] = aux;
                    }
                }
            }
        }

        for (var i = 0; i < domains.Count; ++i)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl h3 =
            new System.Web.UI.HtmlControls.HtmlGenericControl("h3");

            h3.InnerHtml = "&nbsp;&nbsp;&nbsp;" + domains[i];

            System.Web.UI.HtmlControls.HtmlGenericControl p =
            new System.Web.UI.HtmlControls.HtmlGenericControl("p");

            p.InnerHtml = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + descriptions[i];

            System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            createDiv.Style.Add("height", "120px");
            createDiv.Style.Add("border", "1px solid #CCC");

            createDiv.Controls.Add(h3);
            createDiv.Controls.Add(p);

            createDiv.Style.Add("color", "red");
            createDiv.Style.Add("text-decoration", "overline");
            createDiv.Style.Add("background", "#DDD");
            //createDiv.Style.Add("cursor", "pointer");
            createDiv.Style.Add("box-shadow", "0 0 5px -1px rgba(0, 0, 0, 0.2)");

            Session["color"] = "#01DF3A";
            createDiv.Attributes.Add("ID", "domeniu" + i);
            createDiv.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='" + Session["color"].ToString() + "'");
            createDiv.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#DDD'");

            superdiv.Controls.Add(createDiv);

            Button btn = new Button();
            btn.ID = ids[i];
            btn.Text = "Explore...";
            btn.CssClass = "btn";
            btn.CommandArgument = btn.ID;
            btn.Click += new EventHandler(this.tapDomain);
            btn.Style.Add("background", "red");
            btn.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='" + "green" + "'");
            btn.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='red'");
            btn.Style.Add("text-decoration", "overline");
            btn.Style.Add("cursor", "pointer");
            superdiv.Controls.Add(btn);

            superdiv.Controls.Add(new LiteralControl("<br>"));
            superdiv.Controls.Add(new LiteralControl("<br>"));

        }




    }
}
