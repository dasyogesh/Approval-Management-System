<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
<a href="Login.aspx"></a>
</div>

<div id="sidebar">
<h1><asp:Label ID="lblWelcomeMessage" Text="" runat="server" /></h1>
</div>

<div id="main">
<form id="form1" runat="server">
   <table style="width:100%";">
         <caption class="style1">
             <strong>LOGIN PAGE</strong>
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
             <td></td>
             <td></td>
         <td class="style2">Username:</td>
         <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
             <td></td>
             <td></td>
         <td class="style2">Password:</td>
         <td><asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox></td>
         
         </tr>
         <tr>
              <td></td>
             <td></td>
             <td class="style2"></td>
             <td><asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /></td>
             <td><asp:Label ID="AMS" runat="server"></asp:Label></td>
         </tr>
         </table>
    
    </form>
    </div>


<div id="footer">
&copy;&nbsp;<a> Design by Yogesh Kumar Das</a>
    
</div>

</div>

</body>
</html>

