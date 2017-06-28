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


public partial class UserSet : System.Web.UI.Page
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
        txtName.Text = string.Empty; txtPassword.Text = string.Empty; txtEmail.Text = string.Empty; txtisActive.Text = string.Empty;
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
            SqlCommand cmd = new SqlCommand("Select * from UserMaster;", conn);
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
            SqlCommand cmd = new SqlCommand("Insert into UserMaster (Name,Password,Email,isActive ) values (@Name,@Password,@Email,@isActive)", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@isActive", txtisActive.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("User added successfully......!");
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
        lblUserId.Text = row.Cells[2].Text;
        txtName.Text = row.Cells[3].Text;
        txtPassword.Text = row.Cells[4].Text;
        txtEmail.Text = row.Cells[5].Text;
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
            int UserId = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("Delete From UserMaster where UserId='" + UserId + "'", conn);
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
            string UserId = lblUserId.Text;
            SqlCommand cmd = new SqlCommand("update UserMaster Set Name=@Name,Password=@Password,Email=@Email,isActive=@isActive where UserId=@UserId", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@isActive", txtisActive.Text);
            cmd.Parameters.AddWithValue("UserId", UserId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("User Data Updated Successfully......!");
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
