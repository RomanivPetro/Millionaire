<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="PrimaryPage.aspx.cs" Inherits="Millionaire.Game.PrimaryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblEnterText" runat="server" Text="Введіть своє ім'я:"></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
                                ErrorMessage="Потрібно ввести своє ім'я" ControlToValidate="txtUserName"
                                ForeColor="Red" Display="Dynamic"/>

    <asp:RegularExpressionValidator ID="revUserName" runat="server"
                                    ErrorMessage="Некоректні дані" ControlToValidate="txtUserName"
                                    ValidationExpression="^[а-яА-Яa-zA-Z]{3,12}$"
                                    ForeColor="Red" Display="Dynamic"/>

    <asp:Button ID="btnNewGame" runat="server" Text="Нова гра" OnClick="btnNewGame_Click" />

</asp:Content>
