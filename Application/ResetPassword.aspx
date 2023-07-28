﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Application.ResetPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            max-width: 400px;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        /* Heading styles */
        h2 {
            font-size: 20px;
            margin-bottom: 20px;
            color: crimson;
            text-align: center;
        }

        /* Label styles */
        label {
            font-weight: bold;
            font-size: 12px;
        }

        /* Input styles */
        .password-input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        /* Button styles */
        input[type="submit"] {
            margin: 20px auto 0;
            width: 100%;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        input[type="submit"]:hover {
            background-color: #45a049;
        }

        /* Paragraph styles */
        p {
            text-align: center;
            margin-top: 20px;
        }

        /* Error message styles */
        .error-message {
            color: red;
            font-size: 14px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- HTML for the ResetPassword.aspx page -->
            <h2>Reset Password</h2>
            <label for="txtNewPassword">Create Password</label>
            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="password-input" TextMode="Password" />
            <br />
            <br />

            <label for="txtConfirmPassword">Confirm Password</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="password-input" TextMode="Password" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Visible="false" />

            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        </div>
    </form>
</body>
</html>
