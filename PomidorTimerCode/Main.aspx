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
            height: 275px;
        }
        .auto-style6 {
            position: absolute;
            top: 50%;
            left: 50%;
            height: 283px;
            width: 507px;
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

            <asp:Panel ID="Panel1" runat="server" Height="316px" Width="532px" BorderStyle="Ridge" style="position:absolute; top:50%; left:50%; transform:translate(-50%,-50%);" HorizontalAlign="Center">
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
                                <asp:Button ID="Button1" runat="server" Text="55 минут" Width="160px" OnClick="Button1_Click" Height="61px" />
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="5 минут" Width="160px" OnClick="Button2_Click" Height="61px" />
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="20 минут" Width="160px" OnClick="Button3_Click" Height="61px" />
                            </td>
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