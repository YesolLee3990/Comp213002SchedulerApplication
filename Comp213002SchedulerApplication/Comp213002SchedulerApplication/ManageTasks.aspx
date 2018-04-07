<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTasks.aspx.cs" Inherits="Comp213002SchedulerApplication.ManageTasks" %>

<!DOCTYPE html>
<link href="Content/ManageTask.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Task Management</h3><br />
            <div id="searchConditionBox">
                <div class="searchLeftCol">Subject :<input type="text" name="subject" /></div>
                <div class="searchRightCol">Description : <input type="text" name="description" /></div>
                <div class="searchLeftCol">Date : <input type="date" name="scheduleStart" /> ~ <input type="date" name="scheduleEnd" /></div>
                <div class="searchRightCol">Actor : <input type="text" name="actorName" /></div>
                <div class="searchLeftCol">Status :
                    <select name="status">
                        <option value="S">Scheduled</option>
                        <option value="W">Working</option>
                        <option value="F">Finished</option>
                    </select>
                </div>
                <div class="searchRightCol"><input type="button" class="button" value="Search" onclick="javascript: search();" /></div>
            </div>
            <br />
            <table id="contentTable">
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
                <tr onclick="javascript:showTaskInfo('<%=dr["ID"] %>');">
                    <td style="width=50px;"><%=dr["ID"] %></td>
                    <td><%=dr["SUBJECT"] %></td>
                    <td><%=dr["USERNAME"] %></td>
                    <td><%=dr["SCHEDULESTART"] %>~<%=dr["SCHEDULEEND"] %></td>
                    <td style="width:200px"><%=dr["DESCRIPTION"] %></td>
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

    function showTaskInfo(id) {
        window.open('/angular/task?id=' + id, '', 'width=900,height=600,scrollbars=1,resizable');
    }

    $('#contentTable td').each(function () {
        $(this).prop('title', $(this).html());
    });
</script>
</html>
