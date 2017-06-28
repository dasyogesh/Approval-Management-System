<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prac.aspx.cs" Inherits="prac" %>

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
<a href="Login.aspx">LOGIN</a> &nbsp; &nbsp; &nbsp; &nbsp; <a href="Admin1.aspx">HOME PAGE</a> &nbsp; &nbsp; &nbsp; &nbsp; <a href="User1.aspx">TRANSACTION PAGE</a>
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
    
        
     

    <div style="padding: 10px; margin: 0px; width: 100%;">
        <p>
            Total Issues Raised:<asp:Label ID="lbltotalcount" runat="server" Font-Bold="true"></asp:Label>
        </p>
        <asp:GridView ID="GridViewStudent" runat="server" DataKeyNames="ReqId" 
             OnRowDeleting="GridViewStudent_RowDeleting">
            <Columns>
                
                <asp:CommandField HeaderText="Approve" ShowDeleteButton="True" DeleteText="Select" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
     
    </div>
    </form>
</div>

<div id="footer">
&copy;&nbsp; Design by Yogesh Kumar Das</a>
</div>

</div>

</body>
</html>

