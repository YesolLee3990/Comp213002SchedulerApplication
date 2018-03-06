<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateMain.aspx.cs" Inherits="Comp213002SchedulerApplication.TemplateMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">Register</asp:HyperLink>

            <asp:HyperLink ID="HyperLink3" runat="server">HyperLink</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server">HyperLink</asp:HyperLink>

            <asp:ListView runat="server" ID="tmplList">
                <LayoutTemplate>
                    <table runat="server" id="table1">
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <%-- Data-bound content. --%>
                            <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
