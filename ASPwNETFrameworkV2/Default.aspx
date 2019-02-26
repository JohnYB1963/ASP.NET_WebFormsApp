<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPwNETFrameworkV2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <div id="Default">    
        <script src="Scripts/PageScripts/Default.js"></script>    
    

        <h1>Current Selected Customer</h1>
        <br />
        <br />
        <div>
            <label id="CustomerId"></label>
            <label id="CustomerName"></label>
            <label id="CustomerPurchase"></label>
            <label id="CustomerLocation"></label>
        </div>
    </div>
    <asp:Label runat="server" ID="txtResponse"></asp:Label>


</asp:Content>
