<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BlogManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login Page</title>
    <style>
        /* Style for the form container */
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
        }

        #form1 {
            background-color: white;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0px 2px 6px rgba(0, 0, 0, 0.1);
            margin: 20px auto;
            max-width: 300px;
        }

            /* Style for table cells */
            #form1 table td {
                padding: 5px;
            }

        /* Style for the submit button */
        #Submit1 {
            background-color: #333;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin-top: 10px;
            margin-left: 104px;
        }

        h2 {
           text-align:center;
        }
        /* Style for the error message label */
        #Msg {
            color: red;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login</h2>
        <table>
            <tr>
                <td>UserName:</td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" CssClass="text-box" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="UserName"
                        Display="Dynamic"
                        ErrorMessage="Cannot be empty."
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="UserPass" TextMode="Password"
                        runat="server" CssClass="text-box" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        ControlToValidate="UserPass"
                        ErrorMessage="Cannot be empty."
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>Remember me ?</td>
                <td>
                    <asp:CheckBox ID="chkboxPersist" runat="server" CssClass="checkbox" />
                </td>
            </tr>
        </table>
        <asp:Button ID="Submit1" OnClick="Login_Click" Text="Log In"
            runat="server" CssClass="login-button" />
        <p>
            <asp:Label ID="Msg" runat="server" />
        </p>
    </form>
</body>
</html>
