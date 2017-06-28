<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin2.aspx.cs" Inherits="Admin2" %>

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
 <a href="Admin1.aspx">HOME PAGE</a>
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
         <caption class="style1">
             <h2>ADMIN PAGE</h2>
         </caption>
        <br />
        
        <h8>SELECT OPTION:</h8> 
        <br />
        <br />
        <tr>
             <td class="style2"></td>
             <td><asp:Button ID="Button1" runat="server" Text="USER MASTER" OnClick="Button2_Click" /></td>
             
         
       &nbsp&nbsp&nbsp;
        
             <td class="style2"></td>
             <td><asp:Button ID="Button2" runat="server" Text="CATEGORY MASTER" OnClick="Button3_Click" /></td>
             &nbsp&nbsp&nbsp;
        
             <td class="style2"></td>
             <td><asp:Button ID="Button3" runat="server" Text="SUBCATEGORY MASTER" OnClick="Button4_Click" /></td>
             
         </tr>
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

