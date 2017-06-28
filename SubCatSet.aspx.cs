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



public partial class SubCatSet : System.Web.UI.Page
{
    #region MySqlConnection Connection and Page Lode
    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                this.lblWelcomeMessage.Text = string.Format("Welcome {0}", Session["UserName"].ToString());
            }
        }
        if (!this.Page.IsPostBack)
        {
            BindGridView();


            string query = "SELECT CatId,Name FROM CategoryMaster";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Name"].ToString();
                            item.Value = sdr["CatId"].ToString();
                           
                            DropDownList1.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
           
        }
    }
    #endregion
    #region show message
    /// <summary>
    /// This function is used for show message.
    /// </summary>
    /// <param name="msg"></param>
    void ShowMessage(string msg)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
    }
    /// <summary>
    /// This Function is used TextBox Empty.
    /// </summary>
    void clear()
    {
        txtName.Text = string.Empty; txtDescription.Text = string.Empty; txtDescription.Text = string.Empty; txtisActive.Text = string.Empty;
        txtName.Focus();
    }
    #endregion
    #region bind data to GridViewStudent
    private void BindGridView()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("Select SubCatId,Name,Description,CatName,isActive from SubCategoryMaster;", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridViewStudent.DataSource = ds;
            GridViewStudent.DataBind();
            lbltotalcount.Text = GridViewStudent.Rows.Count.ToString();
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
    #endregion
    #region Insert Data
    /// <summary>
    /// this code used to Student Data insert in MYSQL Database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into SubCategoryMaster (Name,Description,CatId,CatName,isActive ) values (@Name,@Description,@CatId,@CatName,@isActive)", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@CatId", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@CatName", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@isActive", txtisActive.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Category added successfully......!");
            clear();
            BindGridView();
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    #endregion
    #region SelectedIndexChanged
    /// <summary>
    /// this code used to GridViewRow SelectedIndexChanged value show textBox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewStudent.SelectedRow;
        lblSubCatId.Text = row.Cells[2].Text;
        txtName.Text = row.Cells[3].Text;
        txtDescription.Text = row.Cells[4].Text;
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add(new ListItem("Select", "0", true));
        string query = "SELECT CatId,Name FROM CategoryMaster";
        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Name"].ToString();
                        item.Value = sdr["CatId"].ToString();

                        DropDownList1.Items.Add(item);
                    }
                }
                conn.Close();
            }
        }
        txtisActive.Text = row.Cells[6].Text;
        btnSubmit.Visible = false;
        btnUpdate.Visible = true;
    }
    #endregion
    #region Delete Student Data
    /// <summary>
    /// This code used to GridViewStudent_RowDeleting Student Data Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            conn.Open();
            int SubCatId = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("Delete From SubCategoryMaster where SubCatId='" + SubCatId + "'", conn);
            cmd.Parameters.AddWithValue("SubCatId", SubCatId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("User Data Delete Successfully......!");
            GridViewStudent.EditIndex = -1;
            BindGridView();
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion
    #region student data update
    /// <summary>
    /// This code used to student data update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string SubCatId = lblSubCatId.Text;
            SqlCommand cmd = new SqlCommand("update SubCategoryMaster Set Name=@Name,Description=@Description,CatId=@CatId,CatName=@CatName,isActive=@isActive where SubCatId=@SubCatId", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@CatId", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@CatName", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@isActive", txtisActive.Text);
            cmd.Parameters.AddWithValue("SubCatId", SubCatId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("SubCategory Data Updated Successfully......!");
            GridViewStudent.EditIndex = -1;
            BindGridView(); btnUpdate.Visible = false;
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion
    #region textbox clear
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    #endregion
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

        Response.Redirect("Login.aspx");
    }
}
