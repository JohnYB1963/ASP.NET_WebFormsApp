<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateCustomer.aspx.cs" Inherits="ASPwNETFrameworkV2.Pages.UpdateCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/PageScripts/UpdateCustomer.js"></script>
    <h2>Update Selected Customer</h2>
    <div id="Warning">
        <p>WARNING</p>
        <p>You are about to update the NAME, PURCHASE, and LOCATION  of: </p>
        <label id="CustId"></label>
        <label id="CustName"></label>
        <label id="CustPurchase"></label>
        <label id="CustLocation"></label>
        <p>to the live database.</p>
    </div>
     <div>
        <input type="text" id="updateName" />
        <input type="text" id="updatePurchase" />
        <input type="text" id="updateLocation" />
        <input type="button" value="Submit Changes" onclick="updateCustomer()"/>
    </div>


</asp:Content>
