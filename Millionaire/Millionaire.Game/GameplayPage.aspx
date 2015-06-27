<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="GameplayPage.aspx.cs" Inherits="Millionaire.Game.GameplayPage" %>

<%@ Register Src="~/Controllers/ScoreTableControl.ascx" TagPrefix="uc1" TagName="ScoreTableControl" %>
<%@ Register Src="~/Controllers/SendMailControl.ascx" TagPrefix="uc1" TagName="SendMailControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/Style/Styles.css" type="text/css" rel="stylesheet" />
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">              
    <div id ="scoretablectrl">
    <uc1:ScoreTableControl runat="server" id="ScoreTableControl" />
    <uc1:SendMailControl runat="server" id="SendMailControl" Visible="false" />
    </div>

    <div id ="questions">     
        <table id="questionstable">
            <tr>              
                <td colspan="2"><asp:Button CssClass ="questpanel" id="lblQuest" runat="server" BorderStyle="None" Enabled="False" /></td>
            </tr>
            <tr>
                <td class="leftblock"><asp:Button CssClass="butA" ID="buttonA" runat="server" BorderStyle="None"  Text="A" OnClick="buttonA_Click"/></td>
                <td class="rightblock"><asp:Button CssClass="butB" ID="buttonB" runat="server" BorderStyle="None"  Text="B" OnClick="buttonB_Click"/></td>

            </tr>
            <tr>
                <td class="leftblock"><asp:Button CssClass="butC" ID="buttonC" runat="server" BorderStyle="None"  Text="C" OnClick="buttonC_Click"/></td>
                <td class="rightblock"><asp:Button CssClass="butD" ID="buttonD" runat="server" BorderStyle="None"  Text="D" OnClick="buttonD_Click"/></td>

            </tr>
        </table>

        </div>
</asp:Content>
