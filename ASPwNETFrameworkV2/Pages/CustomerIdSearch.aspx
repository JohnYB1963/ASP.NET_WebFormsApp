<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerIdSearch.aspx.cs" Inherits="ASPwNETFrameworkV2.Pages.CustomerIdSearch" %>
<asp:Content ID="CustomerIdSearch" ContentPlaceHolderID="MainContent" runat="server">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head><title>Add a Customer</title>
        <script src="../Scripts/PageScripts/CustomerIdSearch.js" type="text/javascript"></script>

    </head>
    <body>
        <h2>Enter Customer Id</h2>
        <br />
        <input type="text" id="txtarea" />
        <input type="button" value="Search Id" onclick="getCustomer()"/>
        <div id="customerInfo">
            <label id="custId"></label>
            <label id="custName"></label>
            <label id="custPurchase"></label>
            <label id="custLocation"></label>
        </div>
    </body>
    </html>
</asp:Content>
