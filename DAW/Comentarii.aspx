<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Comentarii.aspx.cs" Inherits="Comentarii" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <br>
    <div>
      <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Comments</h2>
    </div>
    <br>
    <br>

    <asp:LoginView ID="LoginView1" runat="server">
    <RoleGroups>
    <asp:RoleGroup Roles="admin">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testB" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnComm" runat="server" Text="Comment" onclick="addComment" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>

    <asp:RoleGroup Roles="utilizator">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testB" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnComm" runat="server" Text="Comment" onclick="addComment" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>

    <asp:RoleGroup Roles="moderator">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="testB" TextMode="multiline" Columns="200" Rows="5" runat="server"> </asp:TextBox>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnComm" runat="server" Text="Comment" onclick="addComment" style="color: #009900" Width="100px"/>
            </div>
        </ContentTemplate>
    </asp:RoleGroup>


    </RoleGroups>
    </asp:LoginView>
    
    <div ID="comdiv" runat="server">

    </div>
    <asp:Label runat="server" Visible="false" ID="idUserLabel" Text='<%: Context.User.Identity.GetUserName()  %>'></asp:Label>

</asp:Content>

