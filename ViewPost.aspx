<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="BlogManagement.ViewPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>View Post</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
     <h1>Blog Details</h1>
    <form id="formViewPost" runat="server">        
         <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="right-align-btn" />
        <div class="post-details">
            <!-- Display post details -->
             <h3>Title : <asp:Literal ID="txtTitle" runat="server"></asp:Literal></h3>
             <h3>Author : <asp:Literal ID="txtAuthor" runat="server"></asp:Literal></h3>
             <h3>Content : <asp:Literal ID="txtContent" runat="server"></asp:Literal></h3>
             <h3>Status : <asp:Literal ID="ddlStatus" runat="server"></asp:Literal></h3>
             <h3>PublishedDate : <asp:Literal ID="PublishedDate" runat="server"></asp:Literal></h3>            
            <!-- Display other post details -->
        </div>
    </form>
</body>
</html>
