<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="BlogManagement.EditPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Edit Post</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>

<body>
    <h1>Edit Blog</h1>
    <form id="formEditPost" runat="server">
       <div>
            <label for="txtTitle">Title :</label>
            <input type="text" id="txtTitle" runat="server" /><br />
            <label for="txtAuthor">Author :</label>
            <input type="text" id="txtAuthor" runat="server" /><br />
            <label for="txtContent">Content :</label>
            <textarea id="txtContent" runat="server"></textarea><br />
            <label for="ddlStatus">Status :</label>
            <select id="ddlStatus" runat="server">
                <option value="Draft">Draft</option>
                <option value="Published">Published</option>
            </select><br />
            <input type="submit" id="btnUpdate" runat="server" value="Update Post" onserverclick="btnUpdate_Click" />
            <input type="submit" id="btnCancel" runat="server" value="Cancel" onserverclick="btnCancel_Click" />
        </div>          
       
    </form>
</body>
</html>
