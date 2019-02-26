<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="ASPwNETFrameworkV2.Pages.AddCustomer" %>
<asp:Content ID="AddCustomer" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/PageScripts/AddCustomer.js" type="text/javascript"></script>

    <h1>Add a Customer</h1>
    <div id="addCustomerDIV">
            <p>Input Id, Name, Purchase, and City to add customer to database</p>
            <input type="button" onclick="addCustomer()" value="Add Customer"/>
            <input type="text" id="addId" />
            <input type="text" id="addName" />
            <input type="text" id="addPurchase" />
            <input type="text" id="addLocation" />
    </div>


</asp:Content>
