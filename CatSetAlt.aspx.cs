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
public partial class CatSetAlt : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lvEmployee.DataSource = GetEmployee("Select * from CategoryMaster");
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
        lvEmployee.DataSource = GetEmployee("Select * from CategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        string CatId = "", Name = "",Description = "", isActive = "";
        Label lbl = (lvEmployee.Items[e.ItemIndex].FindControl("CatId")) as Label;
        if (lbl != null)
            CatId = lbl.Text;
        TextBox txt = (lvEmployee.Items[e.ItemIndex].FindControl("Name")) as TextBox;
        if (txt != null)
            Name = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("Description")) as TextBox;
        if (txt != null)
            Description = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("isActive")) as TextBox;
        if (txt != null)
            isActive = txt.Text;
        string UpdateQuery = "UPDATE CategoryMaster SET Name = '" + Name + "', Description = '" + Description + "', isActive = '" + isActive + "' WHERE CatId = '" + CatId + "'";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(UpdateQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from CategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from CategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        string CatId = "";
        Label lbl = (lvEmployee.Items[e.ItemIndex].FindControl("CatId")) as Label;
        if (lbl != null)
            CatId = lbl.Text;
        string DeleteQuery = "Delete from CategoryMaster WHERE CatId = '" + CatId + "'";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(DeleteQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from CategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        string Name = "", Description = "",isActive = "";
        TextBox txt = (e.Item.FindControl("Name")) as TextBox;
        if (txt != null)
            Name = txt.Text;
        txt = (e.Item.FindControl("Description")) as TextBox;
        if (txt != null)
            Description = txt.Text;
        txt = (e.Item.FindControl("isActive")) as TextBox;
        if (txt != null)
            isActive = txt.Text;
        string INSERTQuery = "INSERT INTO CategoryMaster (Name,Description,isActive) VALUES ('" + Name + "','" + Description + "','" + isActive + "')";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(INSERTQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from CategoryMaster");
        lvEmployee.DataBind();
    }
}