<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <br>
    <div>
      <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Domains</h2>
    </div>
    <br>
    <br>

    <asp:LoginView ID="LoginView3" runat="server">
    <RoleGroups>
    <asp:RoleGroup Roles="admin">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testD" TextMode="multiline" Columns="200" Rows="2" runat="server"> </asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="testE" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnDom" runat="server" Text="Add Domain" onclick="addDomeniu" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>
    </RoleGroups>
    </asp:LoginView>
    <br>

    <asp:Button ID="sb" Text="Sort" runat="server" onclick="sortDomains" />
    <br>
    <br>
    
    <div ID="superdiv" runat="server">

    </div>


</asp:Content>
