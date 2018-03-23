<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requestRescheduling.aspx.cs" Inherits="Comp213002SchedulerApplication.requestRescheduling" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 545px;
            height: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="allPages" style="width:550px;height:350px">

        <p> Comment about request </p>
        <asp:Label ID="labelTaskInfo" runat="server" Text=""></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>&nbsp&nbsp&nbsp
        <asp:Button ID="btnStartDate" runat="server" Text="StartDate" OnClick="btnStartDate_Click" />&nbsp&nbsp
        <asp:Button ID="btnEndDate" runat="server" Text="EndDate" OnClick="btnEndDate_Click" />

        <textarea id="TextArea1" class="auto-style1" name="S1"></textarea>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Request Send" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />

    
    </div>
    </form>
</body>
</html>
