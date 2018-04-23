<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="Comp213002SchedulerApplication.FeedbackList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
                 <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                </Columns>
            </asp:GridView>
        </div>
        
    </form>
</body>
</html>
