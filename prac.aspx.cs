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



public partial class prac : System.Web.UI.Page
{
    
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
  
    void ShowMessage(string msg)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
    }
    
    private void BindGridView()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * from Request;", conn);
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
    
   

   
    protected void GridViewStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            conn.Open();
            int ReqId = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("update Request Set Status=replace(Status,'RFA','Approved') where ReqId='" + ReqId + "'", conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Raised Issue has been Approved Successfully......!");
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
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

        Response.Redirect("Login.aspx");
    }

}
