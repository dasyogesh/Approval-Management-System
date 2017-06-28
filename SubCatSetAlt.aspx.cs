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
public partial class SubCatSetAlt : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {
            lvEmployee.DataSource = GetEmployee("Select * from SubCategoryMaster");
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
        lvEmployee.DataSource = GetEmployee("Select * from SubCategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        string SubCatId = "", Name = "", Description = "",CatId="", isActive = "";
        Label lbl = (lvEmployee.Items[e.ItemIndex].FindControl("SubCatId")) as Label;
        if (lbl != null)
            SubCatId = lbl.Text;
        TextBox txt = (lvEmployee.Items[e.ItemIndex].FindControl("Name")) as TextBox;
        if (txt != null)
            Name = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("Description")) as TextBox;
        if (txt != null)
            Description = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("CatId")) as TextBox;
        if (txt != null)
            CatId = txt.Text;
        txt = (lvEmployee.Items[e.ItemIndex].FindControl("isActive")) as TextBox;
        if (txt != null)
            isActive = txt.Text;
        string UpdateQuery = "UPDATE SubCategoryMaster SET Name = '" + Name + "', Description = '" + Description + "',CatId='"+CatId+"', isActive = '" + isActive + "' WHERE SubCatId = '" + SubCatId + "'";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(UpdateQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from SubCategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from SubCategoryMaster");
        lvEmployee.DataBind();
    }
    protected void lvEmployee_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        string SubCatId = "";
        Label lbl = (lvEmployee.Items[e.ItemIndex].FindControl("SubCatId")) as Label;
        if (lbl != null)
            SubCatId = lbl.Text;
        string DeleteQuery = "Delete from SubCategoryMaster WHERE CatId = '" + SubCatId + "'";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(DeleteQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from SubCategoryMaster");
        lvEmployee.DataBind();
    }
    private DataSet GetData(string query)
    {
        
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }
    protected void lvEmployee_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        DropDownList DropDownList1 = (e.Item.FindControl("CatId") as DropDownList);
        DropDownList1.DataSource = GetData("SELECT * FROM CategoryMaster");
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "CatId";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select Category"));
        
                 
        string Name = "", Description = "",CatId="", isActive = "";
        TextBox txt = (e.Item.FindControl("Name")) as TextBox;
        if (txt != null)
            Name = txt.Text;
        txt = (e.Item.FindControl("Description")) as TextBox;
        if (txt != null)
            Description = txt.Text;
        txt = (e.Item.FindControl("CatId")) as TextBox;
        if (txt != null)
           CatId = txt.Text;
        txt = (e.Item.FindControl("isActive")) as TextBox;
        if (txt != null)
            isActive = txt.Text;
        string INSERTQuery = "INSERT INTO SubCategoryMaster (Name,Description,CatId,isActive) VALUES ('" + Name + "','" + Description + "','"+CatId+"','" + isActive + "')";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand(INSERTQuery, con);
        com.ExecuteNonQuery();
        con.Close();
        lvEmployee.EditIndex = -1;
        lvEmployee.DataSource = GetEmployee("Select * from SubCategoryMaster");
        lvEmployee.DataBind();
    }
    

}