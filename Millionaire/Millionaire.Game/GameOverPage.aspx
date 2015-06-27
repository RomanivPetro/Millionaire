<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="GameOverPage.aspx.cs" Inherits="Millionaire.Game.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="dMessage">
        <asp:Button CssClass ="gameovermsg" id="btnRes" runat="server" BorderStyle="None" Enabled="False"/>
    </div>
    <div id="dRestart">
    <asp:Button ID="btnRestart" CssClass="Restart" runat="server" Text="" OnClick="btnRestart_Click" BorderStyle="None" />
    </div>
</asp:Content>

