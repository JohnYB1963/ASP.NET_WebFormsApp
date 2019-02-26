<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="ASPwNETFrameworkV2.Pages.DeleteCustomer"%>
<asp:Content ID="DeleteCustomer" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/PageScripts/DeleteCustomer.js"></script>
    <h2>Delete Selected Customer</h2>
    <div id="Warning">
        <p>WARNING</p>
        <p>You are about to delete: </p>
        <label id="CustId"></label>
        <label id="CustName"></label>
        <label id="CustPurchase"></label>
        <label id="CustLocation"></label>
        <p>from the live database.</p>
    </div>
    <input type="button" value="DELETE" onclick="DeleteCustomer()"/>
    
</asp:Content>
