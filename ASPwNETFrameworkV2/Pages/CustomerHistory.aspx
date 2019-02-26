<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerHistory.aspx.cs" Inherits="ASPwNETFrameworkV2.Pages.CustomerHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../Scripts/PageScripts/CustomerHistory.js"></script>
    <div id="custHistory">
        <input type="button" value="Get Customer Purchase History" onclick="getHistory()"/>
        <table id="purchaseHistory">
            <tbody></tbody>
        </table>


    </div>



</asp:Content>
