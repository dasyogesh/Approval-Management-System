using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class UserSetAlt : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lvEmployee.DataSource = GetEmployee("Select * from UserMaster");
            lvEmployee.DataBind();
        }
    }

    public DataTable GetEmployee(string query)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlDataAdapter ada = new SqlDataAdapter(query, con);
        DataTable dtEmp = new DataTable();
        ada.Fill(dtEmp);
        return dtEmp;
    }
    protected void lvEmployee_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        lvEmployee.EditIndex = e.NewEditIndex;
        lvEmployee.DataSource = GetEmployee("Select * from UserMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        string UserId = "", Name = "", Password = "", Email = "", isActive = "";
        Label lbl = (lvEmployee.Items[e.ItemIndex].FindControl("UserId")) as Label;
        if (lbl != null)
            UserId = lbl.Text;
        TextBox txt = (lvEmployee.Items[e.ItemIndex].FindControl("Name")) as TextBox;
        if (txt != null)
            Name = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("Password")) as TextBox;
        if (txt != null)
            Password = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("Email")) as TextBox;
        if (txt != null)
            Email = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("isActive")) as TextBox;
        if (txt != null)
            isActive = txt.Text;
        string UpdateQuery = "UPDATE UserMaster SET Name = '" + Name + "', Password = '" + Password + "', Email = '" + Email + "', isActive = '" + isActive + "' WHERE UserId = '" + UserId + "'";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(UpdateQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from UserMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from UserMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        string UserId = "";
        Label lbl = (lvEmployee.Items[e.ItemIndex].FindControl("UserId")) as Label;
        if (lbl != null)
            UserId = lbl.Text;
        string DeleteQuery = "Delete from UserMaster WHERE UserId = '" + UserId + "'";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(DeleteQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from UserMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        string Name = "", Password = "", Email = "", isActive = "";
        TextBox txt = (e.Item.FindControl("Name")) as TextBox;
        if (txt != null)
            Name = txt.Text;
        txt = (e.Item.FindControl("Password")) as TextBox;
        if (txt != null)
            Password = txt.Text;
        txt = (e.Item.FindControl("Email")) as TextBox;
        if (txt != null)
            Email = txt.Text;
        txt = (e.Item.FindControl("isActive")) as TextBox;
        if (txt != null)
            isActive = txt.Text;
        string INSERTQuery = "INSERT INTO UserMaster (Name,Password,Email,isActive) VALUES ('" + Name + "','" + Password + "','" + Email + "','" + isActive + "')";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(INSERTQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from UserMaster");
        lvEmployee.DataBind();
    }
}