<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ecriremessage.aspx.cs" Inherits="prjWebCsAdoOmnivox.ecriremessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 1222px;
        }
        .auto-style3 {
            width: 900px;
            background-color: #A2C0FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1">OMNIVOX TECCART</h1>
        <h2 class="auto-style1">Redaction de Nouveau Message</h2>
        <hr class="auto-style2" />
        <p>
            &nbsp;</p>
        <table align="center" class="auto-style3">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Destinataire : "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboDestinataire" runat="server" Font-Bold="True" Width="668px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Titre : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitre" runat="server" Font-Bold="True" Width="668px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Message : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" Height="461px" TextMode="MultiLine" Width="668px" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEnvoyer" runat="server" Font-Bold="True" OnClick="btnEnvoyer_Click" Text="Envoyer" Width="177px" />
                </td>
                <td>
                    <asp:Button ID="btnRecommencer" runat="server" Font-Bold="True" Text="Recommencer" Width="246px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
