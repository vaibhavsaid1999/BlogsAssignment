<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="BlogManagement.Posts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Blogs</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>   
    <h1>All Blogs</h1> 
    <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/Logout.aspx" Text="Logout" CssClass="logout-link" />
     <form id="PostListForm" runat="server">
        <asp:Button ID="btnCreate" runat="server" Text="Create New Post" OnClick="btnCreate_Click" CssClass="right-align-btn" />
        <div id="postList">
        <asp:GridView ID="gvPosts" runat="server" AutoGenerateColumns="False"  OnRowDeleting="gvPosts_RowDeleting" OnRowCommand="gvPosts_RowCommand" DataKeyNames="Id">
            <Columns>
              <%--  <asp:BoundField DataField="Id" HeaderText="ID" />--%>
                 <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("Id") %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Content" HeaderText="Content" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                <asp:BoundField DataField="PublishedDate" HeaderText="Published Date" />
                <asp:ButtonField Text="Edit" CommandName="Edit" />
                <asp:ButtonField Text="View" CommandName="Details" />
                <asp:ButtonField Text="Delete" CommandName="Delete" />
            </Columns>
        </asp:GridView>
    </div>
    </form> 
</body>
</html>
