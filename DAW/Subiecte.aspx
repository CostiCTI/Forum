<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Subiecte.aspx.cs" Inherits="Subiecte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <div>
      <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Subjects</h2>
    </div>
    <br>

    <asp:LoginView ID="LoginView2" runat="server">
    <RoleGroups>
    <asp:RoleGroup Roles="admin">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testA" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnSub" runat="server" Text="Add Subject" onclick="addSubject" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>

    <asp:RoleGroup Roles="moderator">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testA" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnSub" runat="server" Text="Add Subject" onclick="addSubject" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>

    <asp:RoleGroup Roles="utilizator">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testA" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnSub" runat="server" Text="Add Subject" onclick="addSubject" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>
    </RoleGroups>
    </asp:LoginView>



    <div ID="subdiv" runat="server">

    </div>

</asp:Content>
