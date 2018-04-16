<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomizingPage.aspx.cs" Inherits="Comp213002SchedulerApplication.CustomizingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 346px;
            height: 289px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
    <div id="allPage" style="width=300px;height=285">
        <asp:Label ID="title" runat="server" Text="Customizing Page"></asp:Label><br /><br /><hr />
        <asp:Label ID="lbTheme" runat="server" Text="Theme : "></asp:Label> <asp:DropDownList ID="ddTheme" runat="server" OnSelectedIndexChanged="ddTheme_SelectedIndexChanged"></asp:DropDownList><br /><br />
        <asp:Label ID="lbFont" runat="server" Text="Font : "></asp:Label> <asp:DropDownList ID="ddFont" runat="server" OnSelectedIndexChanged="ddFont_SelectedIndexChanged"></asp:DropDownList><br /><br />
        <asp:Label ID="lbFontSize" runat="server" Text="Font Size : "></asp:Label> <asp:DropDownList ID="ddFontSize" runat="server" OnSelectedIndexChanged="ddFontSize_SelectedIndexChanged"></asp:DropDownList><br /><br />
        <asp:Label ID="lbFontColor" runat="server" Text="Font Color : "></asp:Label> <asp:DropDownList ID="ddFontColor" runat="server" OnSelectedIndexChanged="ddFontColor_SelectedIndexChanged"></asp:DropDownList><br /><br />
        &nbsp&nbsp<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Button1_Click" />&nbsp&nbsp&nbsp<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
