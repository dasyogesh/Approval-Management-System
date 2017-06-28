<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Request.aspx.cs" Inherits="Request" %>

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
 <a href="Admin1.aspx">HOME PAGE</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="Admin2.aspx">ADMIN PAGE</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="User1.aspx">TRANSACTION PAGE</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="Request.aspx">RAISE ISSUE PAGE</a>
</div>

<div id="sidebar">
<h1><asp:Label ID="lblWelcomeMessage" Text="" runat="server" /></h1>
</div>

<div id="main">
<form id="form1" runat="server">
   <table>
        <tr>
            <td class="td">Category :</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
        </asp:DropDownList></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Go" OnClick="btnSave_Click" />
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="td">SubCategory :</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="100px">
        </asp:DropDownList></td>
            <td>&nbsp;</td>
        </tr>
         <tr>
             
         <td class="style2">Remarks:</td>
         <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
             
         <td class="style2">Date:</td>
         <td><asp:Calendar ID = "Calendar1" runat = "server"></asp:Calendar></td>
         
         </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            <td></td>
        </tr>
    </table>

    
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

