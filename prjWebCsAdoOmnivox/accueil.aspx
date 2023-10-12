<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accueil.aspx.cs" Inherits="prjWebCsAdoOmnivox.accueil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
            align-content:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">OMNIVOX - ACCUEIL</h1>
            <asp:Label ID="lblInfo" runat="server" ></asp:Label>
        </div>
        <div class="auto-style2">
            <asp:Table ID="tabMessages" runat="server" BackColor="#C4E1FF" BorderColor="#0033CC" BorderStyle="Solid" GridLines="Both" Width="1074px">
                <asp:TableRow runat="server" BackColor="#D0E8FF">
                    <asp:TableCell runat="server">Titres :</asp:TableCell>
                    <asp:TableCell runat="server">Provenance :</asp:TableCell>
                    <asp:TableCell runat="server">Actions :</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnMessage" runat="server" BackColor="#3333CC" Font-Bold="True" Font-Italic="False" ForeColor="White" OnClick="btnMessage_Click" Text="Composer un Nouveau Message" Width="467px" />
    </form>
</body>
</html>
