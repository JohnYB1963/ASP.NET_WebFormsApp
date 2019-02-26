<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDetailSearch.aspx.cs" Inherits="ASPwNETFrameworkV2.Pages.CustomerDetailSearch" %>
<asp:Content ID="CustomerDetailSearch" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/PageScripts/CustomerDetailSearch.js"></script>
    <div id="DetailSearch">
        <h2>Search Customer by Other Info</h2>
        <p>Search by Name, Purchase, or Location</p>
        <%--<input type="button" value="Find Customer" onclick="findMatchingCustomers()"/>
        <input type="text" id="txtName" />
        <input type="text" id="txtPurchase" />
        <input type="text" id="txtLocation" />--%>

        <asp:Button runat="server" Text="Find Customer" OnClick="ResultsRedirect"/>
        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtPurchase"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtLocation"></asp:TextBox>


    </div>
    <label id="numCustomers"></label>
</asp:Content>
