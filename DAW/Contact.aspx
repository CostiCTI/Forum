<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Search</h2>
    <h2>&nbsp;</h2>
    <h2>
        <asp:TextBox ID="searchBox" runat="server"></asp:TextBox>
    </h2>
    <p>
        <asp:Button ID="seacrchButton" runat="server" onclick="pushSearch" Text="Search" />
    </p>
    
    <div id="searchDiv">

    </div>


</asp:Content>
