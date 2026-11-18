<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="PomidorTimerCode.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

    .auto-style1 {
        text-align: center;
            font-size: xx-large;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            font-size: xx-large;
        }
        .auto-style5 {
            height: 155px;
        }
        .auto-style6 {
            position: absolute;
            top: 50%;
            left: 50%;
            height: 424px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div>
            <br />
            <br />
            <br />
            <br />
        </div>
        <div class="auto-style1">
            <strong>Помидорковый таймер</strong></div>
        <div class="auto-style3">
            <br />
            <br />
            <br />
        </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

            <asp:Panel ID="Panel1" runat="server" Height="400px" Width="700px" BorderStyle="Ridge" style="position:absolute; top:50%; left:50%; transform:translate(-50%,-50%);" HorizontalAlign="Center">
                <div class="auto-style5">
                    <strong>
                    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <br />
                    <asp:Label ID="Label1" runat="server" ClientIDMode="Static" CssClass="auto-style4" Font-Bold="True" Font-Size="XX-Large" Text="00:00"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="25 минут" Width="150px" OnClick="Button1_Click" Height="50px" Visible="False" />
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="5 минут" Width="150px" OnClick="Button2_Click" Height="50px" Visible="False" />
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="15 минут" Width="150px" OnClick="Button3_Click" Height="50px" Visible="False" />
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Старт" Height="60px" Width="170px" OnClick="Button4_Click" />

                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Height="60px" Text="Пауза" Width="170px" OnClick="Button5_Click" />

                            </td>
                            <td>
                                <asp:Button ID="Button6" runat="server" Height="60px" Text="Продолжить" Width="170px" OnClick="Button6_Click" />
                            </td>
                        </tr>
                         <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Height="60px" Text="Сброс" Width="170px" OnClick="Button7_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </strong>
                </div>
            </asp:Panel>

                </ContentTemplate>
            </asp:UpdatePanel>

    </form>
</body>
</html>