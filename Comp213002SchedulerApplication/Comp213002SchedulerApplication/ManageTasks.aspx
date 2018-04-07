<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTasks.aspx.cs" Inherits="Comp213002SchedulerApplication.ManageTasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <%
                foreach(System.Data.DataRow dr in dt.Rows) {
                    string status = (string)dr["STATUS"];
                    if (status == "S") status = "Scheduled";
                    else if (status == "F") status = "Finished";
                    else status = "Working";
            %>
            <tr>
                <td><%=dr["ID"] %></td>
                <td><%=dr["SUBJECT"] %></td>
                <td><%=dr["USERNAME"] %></td>
                <td><%=dr["SCHEDULESTART"] %>~<%=dr["SCHEDULEEND"] %></td>
                <td><%=dr["DESCRIPTION"] %></td>
                <td><%=status %></td>
            </tr>
            <%
                }
            %>
        </table>
    </div>
    </form>
</body>
</html>
