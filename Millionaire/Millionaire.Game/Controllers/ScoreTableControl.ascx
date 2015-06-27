<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScoreTableControl.ascx.cs" Inherits="Millionaire.Game.Controllers.ScoreTableControl" %>
<div>
    <table id="scoretable" class="scoretable" runat="server">
        <tr>
            <td><asp:Button  ID="btnHelp1" CssClass="help1" runat="server" BorderStyle="None" OnClick="btnHelp1_Click"  /></td>
            <td><asp:Button  ID="btnHelp2" CssClass="help2" runat="server" BorderStyle="None" OnClick="btnHelp2_Click"  /></td>
            <td><asp:Button  ID="btnHelp3" CssClass="help3" runat="server" BorderStyle="None" OnClick="btnHelp3_Click"  /></td>
        </tr>
        <tr class="orangetextcolor">
            <td>15</td>
            <td colspan="2">1 000 000</td>
        </tr>
         <tr>
            <td>14</td>
            <td colspan="2">500 000</td>
        </tr>
         <tr>
            <td>13</td>
            <td colspan="2">250 000</td>
        </tr>
         <tr>
            <td>12</td>
            <td colspan="2">125 000</td>
        </tr>
         <tr>
            <td>11</td>
            <td colspan="2">64 000</td>
        </tr>
         <tr class="orangetextcolor">
            <td>10</td>
            <td colspan="2">32 000</td>
        </tr>
         <tr>
            <td>9</td>
            <td colspan="2">16 000</td>
        </tr>
         <tr>
            <td>8</td>
            <td colspan="2">8 000</td>
        </tr>
         <tr>
            <td>7</td>
            <td colspan="2">4 000</td>
        </tr>
         <tr>
            <td>6</td>
            <td colspan="2">2 000</td>
        </tr>
         <tr class="orangetextcolor">
            <td>5</td>
            <td colspan="2">1 000</td>
        </tr>
         <tr>
            <td>4</td>
            <td colspan="2">500</td>
        </tr>
         <tr>
            <td>3</td>
            <td colspan="2">300</td>
        </tr>
         <tr>
            <td>2</td>
            <td colspan="2">200</td>
        </tr>
         <tr>
            <td>1</td>
            <td colspan="2">100</td>
        </tr>

    </table>

</div>