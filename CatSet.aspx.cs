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



public partial class CatSet : System.Web.UI.Page
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
        try
        {
            if (!Page.IsPostBack)
            {
                BindGridView();

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
        txtName.Text = string.Empty; txtDescription.Text = string.Empty; txtisActive.Text = string.Empty;
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
            SqlCommand cmd = new SqlCommand("Select * from CategoryMaster;", conn);
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
            SqlCommand cmd = new SqlCommand("Insert into CategoryMaster (Name,Description,isActive ) values (@Name,@Description,@isActive)", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
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
        lblCatId.Text = row.Cells[2].Text;
        txtName.Text = row.Cells[3].Text;
        txtDescription.Text = row.Cells[4].Text;
        txtisActive.Text = row.Cells[5].Text;
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
            int CatId = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("Delete From CategoryMaster where CatId='" + CatId + "'", conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Category Data Delete Successfully......!");
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
            string CatId = lblCatId.Text;
            SqlCommand cmd = new SqlCommand("update CategoryMaster Set Name=@Name,Description=@Description,isActive=@isActive where CatId=@CatId", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@isActive", txtisActive.Text);
            cmd.Parameters.AddWithValue("CatId", CatId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Category Data Updated Successfully......!");
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
