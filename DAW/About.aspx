<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Administration.</h2>

    <asp:LoginView ID="LoginView3" runat="server">
        <AnonymousTemplate>
             
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="admin">
                <ContentTemplate>
                    <h4> Welcome Admin!</h4>
                    <hr>
                    <br>
                    <asp:Button ID="listdb" runat="server" Text="List" onclick="loadDb" />
                    <div id="adminDiv" runat="server">
                    </div>
                    <br>
                    <asp:Button ID="getmod" runat="server" Text="Make Moderator" onclick="getModerator" />
                    <asp:Button ID="getadm" runat="server" Text="Make Admin" onclick="getAdmin" />
                    <asp:Button ID="getuser" runat="server" Text="Make NormalUser" onclick="getNormaluser" />
                    <br>
                    <asp:TextBox ID="tbmod" runat="server" />
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="moderator">
                <ContentTemplate>
                    <h4> Just for ADMIN! Not for Moderator</h4>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="utilizator">
                <ContentTemplate>
                    <h4> Just for ADMIN! Not for NormalUser</h4>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
