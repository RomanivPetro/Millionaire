<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMailControl.ascx.cs" Inherits="Millionaire.Game.Controllers.SendMailControl" %>
 <label for="email">Email</label>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
<asp:Button ID="btnSend" runat="server" Text="Відправити" OnClick="btnSend_Click" />
<asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ErrorMessage="Потрібно ввести email отримувача" ControlToValidate="txtEmail"
                                ForeColor="Red" Display="Dynamic"/>

<asp:RegularExpressionValidator ID="revEmail" runat="server"
                                    ErrorMessage="Некоректні дані" ControlToValidate="txtEmail"
                                    ValidationExpression="^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
                                    ForeColor="Red" Display="Dynamic"/>