<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="MainWindow.aspx.cs" Inherits="Millionaire.Game.MainWindow" EnableViewState="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Game</title>
    <link href="/Style/Styles.css" type="text/css" rel="stylesheet" />
    <script src="/Scripts/SendMail.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $("[id*=btnHelp2]").live("click", function () {
            dialog = $("#modal_dialog").dialog({
                title: "Дзвінок другу",
                buttons: {                                 
                    "Send": function () {
                        var email = document.getElementById("email").value;
                        if (email == '' || !validateEmail(email)) {
                            alert('Please enter a valid email address.');
                            return false;
                        }
                        else {
                            $(this).dialog('close');
                            SendMail(document.getElementById("email").value);
                        }
                    }
                },                                      
                modal: true
            });         
            return false;
        });
</script>
    
</head>
<body>   
    <form id="form1" runat="server">
        <div class="logimg">         
            <img src="/Resources/logo.png" />           
            <div id="modal_dialog" style="display: none">
                <label for="email">Email</label>
                <input type="text" name="email" id="email" />                                                
            </div>
            <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods ="true" />           
        </div>
                
        <div>
            <table id="scoretable" runat="server">
                <tr>
                    <td><asp:Button  ID="btnHelp1" CssClass="help1" runat="server" BorderStyle="None" OnClick="btnHelp1_Click" /></td>
                    <td><asp:Button  ID="btnHelp2" CssClass="help2" runat="server" BorderStyle="None" OnClick="btnHelp2_Click" EnableViewState="true" /></td>
                    <td><asp:Button  ID="btnHelp3" CssClass="help3" runat="server" BorderStyle="None" OnClick="btnHelp3_Click" /></td>
                </tr>
                <tr id="row15" class="orangetext">
                    <td>15</td>
                    <td colspan="2">1 000 000</td>
                </tr>
                 <tr id="row14">
                    <td>14</td>
                    <td colspan="2">500 000</td>
                </tr>
                 <tr id="row13">
                    <td>13</td>
                    <td colspan="2">250 000</td>
                </tr>
                 <tr id="row12">
                    <td>12</td>
                    <td colspan="2">125 000</td>
                </tr>
                 <tr id="row11">
                    <td>11</td>
                    <td colspan="2">64 000</td>
                </tr>
                 <tr id="row10" class="ld">
                    <td>10</td>
                    <td colspan="2">32 000</td>
                </tr>
                 <tr id="row9">
                    <td>9</td>
                    <td colspan="2">16 000</td>
                </tr>
                 <tr id="row8">
                    <td>8</td>
                    <td colspan="2">8 000</td>
                </tr>
                 <tr id="row7">
                    <td>7</td>
                    <td colspan="2">4 000</td>
                </tr>
                 <tr id="row6">
                    <td>6</td>
                    <td colspan="2">2 000</td>
                </tr>
                 <tr id="row5" class="ld">
                    <td>5</td>
                    <td colspan="2">1 000</td>
                </tr>
                 <tr id="row4">
                    <td>4</td>
                    <td colspan="2">500</td>
                </tr>
                 <tr id="row3">
                    <td>3</td>
                    <td colspan="2">300</td>
                </tr>
                 <tr id="row2">
                    <td>2</td>
                    <td colspan="2">200</td>
                </tr>
                 <tr id="row1">
                    <td>1</td>
                    <td colspan="2">100</td>
                </tr>

            </table>
        </div>

        <div id ="questions">     
        <table id="qtable">
            <tr>              
                <td colspan="2"><asp:Button CssClass ="questpanel" id="lblQuest" runat="server" BorderStyle="None" OnClick="lblQuest_Click" EnableViewState="false"/></td>
            </tr>
            <tr>
                <td class="leftblock"><asp:Button CssClass="butA" ID="buttonA" runat="server" BorderStyle="None" OnClick="buttonA_Click" Text="A"/></td>
                <td class="rightblock"><asp:Button CssClass="butB" ID="buttonB" runat="server" BorderStyle="None" OnClick="buttonB_Click" Text="B"/></td>

            </tr>
            <tr>
                <td class="leftblock"><asp:Button CssClass="butC" ID="buttonC" runat="server" BorderStyle="None" OnClick="buttonC_Click" Text="C"/></td>
                <td class="rightblock"><asp:Button CssClass="butD" ID="buttonD" runat="server" BorderStyle="None" OnClick="buttonD_Click" Text="D"/></td>

            </tr>
        </table>

        </div>
    </form>
</body>
</html>
