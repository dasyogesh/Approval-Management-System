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

public partial class Request : System.Web.UI.Page
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
        if (!this.Page.IsPostBack)
        {



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



    void ShowMessage(string msg)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            ShowMessage("Issue Raised added successfully......!");
            conn.Open();
            
            SqlCommand cmd = new SqlCommand("Insert into Request (CatName,SubCatName,Remarks,Date) values (@CatName,@SubCatName,@Remarks,@Date)", conn);
            
            cmd.Parameters.AddWithValue("@CatName", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@SubCatName", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Remarks", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Date", Calendar1.SelectedDate.ToShortDateString());
            cmd.ExecuteNonQuery();
            cmd.Dispose();
           
           

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            string query = "SELECT SubCatId,Name FROM SubCategoryMaster where CatId=@CatId";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.AddWithValue("CatId", DropDownList1.SelectedItem.Value);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Name"].ToString();
                            item.Value = sdr["SubCatId"].ToString();

                            DropDownList2.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }



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