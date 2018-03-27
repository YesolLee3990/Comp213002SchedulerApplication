<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reschedulePopup.aspx.cs" Inherits="Comp213002SchedulerApplication.reschedulePopup" enableeventvalidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width:500px;height:500px;">
    <form id="form1" runat="server">
    <div id="allpageDiv" style="width:auto;height:auto;">
        <div id="headerDiv" style="width:auto;height:40px;">
            <asp:Label ID="lbHeader" runat="server" Text="Your task List"></asp:Label>
        </div>

        <div id="detailDiv" style="width:auto;height:580px;">
            <asp:Label ID="lbContents" runat="server" Text=""></asp:Label>
            

            <br />
            <asp:Label ID="labelSdate" runat="server" Text="Start Date : "></asp:Label><asp:TextBox ID="txtSdate" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="labelEdate" runat="server" Text="End Date : "></asp:Label>&nbsp<asp:TextBox ID="txtEdate" runat="server"></asp:TextBox>
            

            
        </div>
        <asp:DropDownList ID="ddTaskList" runat="server" Height="16px" AutoPostBack="True" OnSelectedIndexChanged="ddTaskList_SelectedIndexChanged" Width="207px"></asp:DropDownList>
        
        

    </div>
    </form>
</body>
</html>
