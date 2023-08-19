<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="BlogManagement.CreatePost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Post</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
    <h1>Create Blog</h1>
    <form id="formPost" runat="server">
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
            <input type="submit" id="btnSubmit" runat="server" value="Create Post" onserverclick="btnSubmit_Click"/>
            <input type="submit" id="btnCancel" runat="server" value="Cancel" onserverclick="btnCancel_Click" />
        </div>   
    </form> 
</body>
</html>
