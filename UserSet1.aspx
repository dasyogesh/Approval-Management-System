<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSet1.aspx.cs" Inherits="UserSet1" %>

<!DOCTYPE html>
<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table style="width:100%";">
         <caption class="style1">
             <strong>ADD USER PAGE</strong>
         </caption>
         <tr>
             <td class="style2">

           </td>
             <td>

             </td>
             <td>

             </td>
         </tr>
         <tr>
         <td class="style2">Name:</td>
         <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
         <td class="style2">Password:</td>
         <td><asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
         <td class="style2">E-mail Id:</td>
         <td><asp:TextBox ID="TextBox3"  runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
         <td class="style2">Is Active:</td>
         <td><asp:TextBox ID="TextBox4"  runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
             <td class="style2"></td>
             <td><asp:Button ID="Button1" runat="server" Text="ADD USER" OnClick="Button1_Click" /></td>
             <td><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
         </tr>
         </table>
    </div>
    </form>
</body>
</html>

