<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPwNETFrameworkV2.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
    </head>
    <body>        
        <div>
            <h1>Enter your login credentials</h1>
            <asp:TextBox runat="server" ID="Username"></asp:TextBox>
            <asp:TextBox runat="server" ID="Password"></asp:TextBox>
            <asp:Button runat="server" OnClick="CheckCredentials" Text="Submit"/>
            <asp:Label runat="server" ID="txtResponse"></asp:Label>
        </div>
    </body>
    </html>
</asp:content>