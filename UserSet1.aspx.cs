using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Text;

public partial class UserSet1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        


}
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
       
        SqlCommand cmd = new SqlCommand("insert into UserMaster(Name,Password,E-mail Id,isActive) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        
    }
   
    
}