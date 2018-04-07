<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTasks.aspx.cs" Inherits="Comp213002SchedulerApplication.ManageTasks" %>

<!DOCTYPE html>
<link href="Content/ManageTask.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" method="get" action="ManageTasks.aspx">
        <%
            NameValueCollection qs = (NameValueCollection)Comp213002SchedulerApplication.AppCode.controls.util.SessionUtil.getSessionInfo("searchCondition");
            String subject = (qs["subject"]==null?"":qs["subject"]);
            String description = (qs["description"]==null?"":qs["description"]);
            String scheduleStart = (qs["scheduleStart"]==null?"":qs["scheduleStart"]);
            String scheduleEnd = (qs["scheduleEnd"]==null?"":qs["scheduleEnd"]);
            String actorName = (qs["actorName"]==null?"":qs["actorName"]);
            String status = (qs["status"]==null?"":qs["status"]);
        %>
        <div>
            <h3>Task Management</h3><br />
            <div id="searchConditionBox">
                <div class="searchLeftCol">Subject :<input type="text" name="subject" value="<%=subject %>"/></div>
                <div class="searchRightCol">Description : <input type="text" name="description"  value="<%=description %>"/></div>
                <div class="searchLeftCol">Date : <input type="date" name="scheduleStart" value="<%=scheduleStart %>"/> 
                    ~ <input type="date" name="scheduleEnd"  value="<%=scheduleEnd %>"/></div>
                <div class="searchRightCol">Actor : <input type="text" name="actorName"  value="<%=actorName %>"/></div>
                <div class="searchLeftCol" style="float:none;">Status :
                    <select name="status">
                        <option value="A" <%if ("A" == status) Response.Write("selected"); %> >All</option>
                        <option value="S" <%if ("S" == status) Response.Write("selected"); %> >Scheduled</option>
                        <option value="W" <%if ("W" == status) Response.Write("selected"); %> >Working</option>
                        <option value="F" <%if ("F" == status) Response.Write("selected"); %> >Finished</option>
                    </select>
                </div>
                <div class="searchRightCol"><input type="button" class="button" value="Search" onclick="javascript: search();" /></div>
            </div>
            <br />
            <table id="contentTable">
                <thead>
                    <tr>
                        <th style="width:50px;">ID</th>
                        <th>Subject</th>
                        <th>Actor</th>
                        <th>Date</th>
                        <th style="width:200px">Description</th>
                        <th style="width:100px">Status</th>
                    </tr>
                </thead>
                <%
                    foreach (System.Data.DataRow dr in dt.Rows) {
                        string statusz = (string)dr["STATUS"];
                        if (statusz == "S") statusz = "Scheduled";
                        else if (statusz == "F") statusz = "Finished";
                        else statusz = "Working";
                %>
                <tr onclick="javascript:showTaskInfo('<%=dr["ID"] %>');">
                    <td><%=dr["ID"] %></td>
                    <td><%=dr["SUBJECT"] %></td>
                    <td><%=dr["USERNAME"] %></td>
                    <td><%=dr["SCHEDULESTART"] %>~<%=dr["SCHEDULEEND"] %></td>
                    <td><%=dr["DESCRIPTION"] %></td>
                    <td><%=statusz %></td>
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
