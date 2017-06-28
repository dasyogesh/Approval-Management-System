<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSet.aspx.cs" Inherits="UserSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="author" content="realitysoftware.ca" />
<title></title>
<link rel="stylesheet" type="text/css" href="style.css"/>
</head>

<body>

<div id="container">

<div id="header">
<a href="#">APPROVAL MANAGEMENT SYSTEM</a>
</div>

<div id="menu">
 <a href="Admin1.aspx">HOME PAGE</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="Admin2.aspx">ADMIN PAGE</a>
</div>

<div id="sidebar">
<h1><asp:Label ID="lblWelcomeMessage" Text="" runat="server" /></h1>
</div>

<div id="main">
<form id="form1" runat="server">
   <table>
            <tr>
               
            <asp:Label ID="Label1" Text="" runat="server" />
                </tr>
           <p align="right">
        
               <asp:Button ID="Button4" runat="server" Text="LOG OUT" OnClick="Button5_Click" />
           </p>
            </table>
    
        <h2>USER MASTER SETTINGS</h2>
    <div>
     <table>
        <tr>
            <td class="td">Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td class="td">Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="td">E-mail Id:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="td">isActive:</td>
            <td>
                <asp:TextBox ID="txtisActive" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Insert" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
            <td></td>
        </tr>
    </table>

    <div style="padding: 10px; margin: 0px; width: 100%;">
        <p>
            Total Count:<asp:Label ID="lbltotalcount" runat="server" Font-Bold="true"></asp:Label>
        </p>
        <asp:GridView ID="GridViewStudent" runat="server" DataKeyNames="UserId" 
            OnSelectedIndexChanged="GridViewStudent_SelectedIndexChanged" OnRowDeleting="GridViewStudent_RowDeleting">
            <Columns>
                <asp:CommandField HeaderText="Update" ShowSelectButton="True" SelectText="Edit" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
   
    </div>
        

 <br />
    <br />
    <br />
    </form>
    </div>


<div id="footer">
&copy;&nbsp;<a> Design by Yogesh Kumar Das</a>
</div>

</div>

</body>
</html>

