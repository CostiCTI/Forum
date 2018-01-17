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
public partial class About : Page
{
    protected void getNormaluser(object sender, EventArgs e)
    {
        TextBox tbox = (TextBox)LoginView3.FindControl("tbmod");
        string user = tbox.Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

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
            ids.Add(row["id"].ToString());
        }

        string idmod = "";
        for (var i = 0; i < users.Count; ++i)
        {
            if (users[i].Equals(user))
            {
                idmod = ids[i];
            }
        }
        con.Close();
        // --------------------------------------------------------------
        con.Open();
        string command = "UPDATE AspNetUserRoles SET RoleId = @cm WHERE UserId='" + idmod.ToString() + "'";

        using (SqlCommand cmdd = new SqlCommand(command, con))
        {
            cmdd.Parameters.AddWithValue("@cm", 3);
            cmdd.ExecuteNonQuery();
        }

        con.Close();

        // ------------------------------

    }

    protected void getAdmin(object sender, EventArgs e)
    {
        TextBox tbox = (TextBox)LoginView3.FindControl("tbmod");
        string user = tbox.Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

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
            ids.Add(row["id"].ToString());
        }

        string idmod = "";
        for (var i = 0; i < users.Count; ++i)
        {
            if (users[i].Equals(user))
            {
                idmod = ids[i];
            }
        }
        con.Close();
        // --------------------------------------------------------------
        con.Open();
        string command = "UPDATE AspNetUserRoles SET RoleId = @cm WHERE UserId='" + idmod.ToString() + "'";

        using (SqlCommand cmdd = new SqlCommand(command, con))
        {
            cmdd.Parameters.AddWithValue("@cm", 1);
            cmdd.ExecuteNonQuery();
        }

        con.Close();

        // ------------------------------

    }

    protected void getModerator(object sender, EventArgs e)
    {
        TextBox tbox = (TextBox)LoginView3.FindControl("tbmod");
        string user = tbox.Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

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
            ids.Add(row["id"].ToString());
        }

        string idmod = "";
        for (var i = 0; i < users.Count; ++i)
        {
            if (users[i].Equals(user))
            {
                idmod = ids[i];
            }
        }
        con.Close();
        // --------------------------------------------------------------
        con.Open();
        string command = "UPDATE AspNetUserRoles SET RoleId = @cm WHERE UserId='" + idmod.ToString() + "'";
        
        using (SqlCommand cmdd = new SqlCommand(command, con))
        {
            cmdd.Parameters.AddWithValue("@cm", 2);
            cmdd.ExecuteNonQuery();
        }

        con.Close();

        // ------------------------------

    }

    protected void loadDb(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = null;

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
            ids.Add(row["id"].ToString());
        }

        System.Web.UI.HtmlControls.HtmlGenericControl adiv =
            (System.Web.UI.HtmlControls.HtmlGenericControl)LoginView3.FindControl("adminDiv");

        // -----------------------------------------

        cmd = new SqlCommand("select * from AspNetUserRoles", con);
        List<string> userids = new List<string>();
        List<string> rolesids = new List<string>();


        DataTable dta = new DataTable();
        SqlDataAdapter daa = new SqlDataAdapter(cmd);
        daa.Fill(dta);


        foreach (DataRow row in dta.Rows)
        {
            userids.Add(row["UserId"].ToString());
            rolesids.Add(row["RoleId"].ToString());
        }

        // -----------------------------------------




        for (var i = 0; i < users.Count; ++i)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl p =
                new System.Web.UI.HtmlControls.HtmlGenericControl("p");

            string role = "X";
            for (var j=0; j<userids.Count; ++j)
            {
                if (ids[i].Equals(userids[j]))
                {
                    if (int.Parse(rolesids[j]) == 1)
                    {
                        role = "Admin";
                    }
                    if (int.Parse(rolesids[j]) == 2)
                    {
                        role = "Moderator";
                    }
                    if (int.Parse(rolesids[j]) == 3)
                    {
                        role = "User";
                    }
                }
            }

            p.InnerHtml = users[i] + " - " + role; 


            adiv.Controls.Add(p);
            adiv.Controls.Add(new LiteralControl("<hr>"));
        }

        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}