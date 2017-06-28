<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubCatSetAlt.aspx.cs" Inherits="SubCatSetAlt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SUB CATEGORY MASTER SETTINGS</title>
<script type="text/javascript">
    function deleteConfirm(pubid) {
        var result = confirm('Do you want to delete ' + pubid + ' ?');
        if (result) {
            return true;
        }
        else {
            return false;
        }
    }
</script>
</head>
<body>
     <h2>SUB CATEGORY SETTINGS</h2>
    <form id="form1" runat="server">
<div>
<asp:ListView ID="lvEmployee" runat="server"    
    onitemediting="lvEmployee_ItemEditing"
    onitemupdating="lvEmployee_ItemUpdating"
    onitemcanceling="lvEmployee_ItemCanceling"
    onitemdeleting="lvEmployee_ItemDeleting"
    InsertItemPosition="LastItem"
    oniteminserting="lvEmployee_ItemInserting">
<LayoutTemplate>
<table id="Table1" runat="server">
    <tr id="Tr1" runat="server">
<td id="Td1" runat="server">
    <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
<tr id="Tr2" runat="server" style="">
<th id="Th1" runat="server">
        </th>
<th id="Th2" runat="server">
    SubCategoryId</th>
<th id="Th3" runat="server">
     Name</th>
<th id="Th4" runat="server">
     Description</th>
<th id="Th5" runat="server">
     CatId</th>
        <th id="Th6" runat="server">
     isActive</th>
</tr>
<tr ID="itemPlaceholder" runat="server">
</tr>
     </table>
</td>
    </tr>
    <tr id="Tr3" runat="server">
<td id="Td2" runat="server" style="">
</td>
    </tr>
</table>
</LayoutTemplate>
<ItemTemplate>
        <tr style="">
    <td>
<asp:Button ID="DeleteButton" runat="server" CommandName="Delete"
    Text="Delete" />
        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
    </td>
            <td>
<asp:Label ID="SubCatId" runat="server" Text='<%# Eval("SubCatId") %>' />
    </td>
    <td>
<asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>' />
    </td>
    <td>
<asp:Label ID="Description" runat="server"
    Text='<%# Eval("Description") %>' />
    </td>
            <td>
<asp:Label ID="CatId" runat="server" Text='<%# Eval("CatId") %>' />
            </td>
        <td>
<asp:Label ID="isActive" runat="server" Text='<%# Eval("isActive") %>' />
    </td>
</tr>
</ItemTemplate>
<EditItemTemplate>
<tr style="">
    <td>
        <asp:Button ID="UpdateButton" runat="server" CommandName="Update"
    Text="Update" />
       
<asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
    Text="Cancel" />
         
    </td>
    <td>
<asp:Label ID="SubCatId" runat="server" Text='<%# Eval("SubCatId") %>' />
    </td>
    <td>
<asp:TextBox ID="Name" runat="server" Text='<%# Bind("Name") %>' />
    </td>
    <td>
<asp:TextBox ID="Description" runat="server"
    Text='<%# Bind("Description") %>' />
            </td>
    <td>
<asp:Label ID="CatId" runat="server" Text='<%# Eval("CatId") %>' />
    </td>
        <td>
<asp:TextBox ID="isActive" runat="server" Text='<%# Bind("isActive") %>' />
    </td>
</tr>
</EditItemTemplate>
<InsertItemTemplate>
<tr style="">
    <td>
<asp:Button ID="InsertButton" runat="server" CommandName="Insert"
    Text="Insert" />
<asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
    Text="Clear" />
        
    </td>
    <td>
        &nbsp;</td>
    <td>
<asp:TextBox ID="Name" runat="server" Text='<%# Bind("Name") %>' />
    </td>
    <td>
<asp:TextBox ID="Description" runat="server"
    Text='<%# Bind("Description") %>' />
    </td>
    <td>
    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
        </asp:DropDownList>
        </td>
           <td>
<asp:TextBox ID="isActive" runat="server" Text='<%# Bind("isActive") %>' />
    </td>
</tr>
</InsertItemTemplate>
</asp:ListView>
    <br />
    <br />
    <br />
    <a href="Admin1.aspx">HOME PAGE</a> &nbsp &nbsp <a href="Admin2.aspx">ADMIN PAGE</a> &nbsp &nbsp <a href="SubCatSetAlt.aspx">USER MASTER SETTINGS:HOME PAGE</a>
    
    </div>
        </form>
</body>
</html>