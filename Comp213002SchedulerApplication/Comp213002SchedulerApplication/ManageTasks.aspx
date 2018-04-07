﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTasks.aspx.cs" Inherits="Comp213002SchedulerApplication.ManageTasks" %>

<!DOCTYPE html>
<link href="Content/ManageTask.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Task Management<br />
            <div id="searchConditionBox">
                <span>Subject :<input type="text" name="subject" /></span>
                <span>Description : <input type="text" name="description" /></span><br />
                <span>Date : <input type="date" name="scheduleStart" /> ~ <input type="date" name="scheduleEnd" /></span>
                <span>Actor : <input type="text" name="actorName" /></span><br />
                <span>Status :
                    <select name="status">
                        <option value="S">Scheduled</option>
                        <option value="W">Working</option>
                        <option value="F">Finished</option>
                    </select>
                </span>
                <span><input type="button" value="Search" onclick="javascript: search();" /></span>
            </div>

            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Subject</th>
                        <th>Actor</th>
                        <th>Date</th>
                        <th>Description</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <%
                    foreach (System.Data.DataRow dr in dt.Rows) {
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
            <%=pagingHtml %>
        </div>
    </form>
</body>
<script>
    function search() {
        form1.action = 'ManageTasks.aspx';
        form1.submit();
    }
</script>
</html>
