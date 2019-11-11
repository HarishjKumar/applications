<%@ Page Language="C#" AutoEventWireup="false"
    CodeBehind="~/FirstPage.aspx.cs" Inherits="AspNetApplication.FirstPage" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>ASP.NET Application ASPX</title>
    <style>
        .label {
            background-color: red;
            color: yellow;
            padding: 5px;
        }
    </style>
    <script runat="server">      

    </script>
</head>
<body>
    <h2>Welcome to ASP.NET Application (Html based) </h2>
    <form runat="server">
        <%--        <label for="username">User Name</label>
        <input type="text" name="username"/>
        <br/>
        <label for="password">Password</label>
        <input type="password" name="password" />
        <br/>
        <button type="button">Submit</button>
        --%>
        <asp:Label ID="lbl1" runat="server" Text="User name: " />
        <asp:TextBox ID="txt1" runat="server" />
        <br />
        <asp:Label ID="lbl2" runat="server" Text="Password : " />
        <asp:TextBox ID="txt2" runat="server" TextMode="password" />
        <br />
        <asp:Button ID="btn1" runat="server" Text="submit" OnClick="btn1_Click" CssClass="label" />
    </form>
</body>
</html>
