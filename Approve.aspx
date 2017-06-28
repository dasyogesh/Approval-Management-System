<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approve.aspx.cs" Inherits="Approve" %>

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
 <a href="Admin1.aspx">HOME PAGE</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="Admin2.aspx">ADMIN PAGE</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="User1.aspx">TRANSACTION PAGE</a>
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
        <asp:Label ID="Label2" Text="" runat="server" />
                <asp:Button ID="Button4" runat="server" Text="LOG OUT" OnClick="Button5_Click" />
           </p>
            </table>
    
        <h2>APPROVAL PAGE</h2>
    
     

    <div style="padding: 10px; margin: 0px; width: 100%;">
        <p>
            Total Issues Raised:<asp:Label ID="lbltotalcount" runat="server" Font-Bold="true"></asp:Label>
        </p>
        <asp:GridView ID="GridViewStudent" runat="server" DataKeyNames="ReqId"> 
             
            
        </asp:GridView>
       
       <br />
        <br />
        <td>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
          <asp:Button ID="btnSubmit" runat="server" Text="Approve" OnClick="btnSubmit_Click" />
                </td>
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

