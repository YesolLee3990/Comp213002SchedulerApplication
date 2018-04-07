<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTasks.aspx.cs" Inherits="Comp213002SchedulerApplication.ManageTasks" %>

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
                <table>
                    <tr>
                        <td>Subject :
                            <input type="text" name="subject" /></td>
                        <td>Description :
                            <input type="text" name="description" /></td>
                    </tr>
                    <tr>
                        <td>Date :
                            <input type="date" name="scheduleStart" />
                            ~
                            <input type="date" name="scheduleEnd" /></td>
                        <td>Actor :
                            <input type="text" name="actorName" /></td>
                    </tr>
                    <tr>
                        <td>Status :
                            <select name="status">
                                <option value="S">Scheduled</option>
                                <option value="W">Working</option>
                                <option value="F">Finished</option>
                            </select></td>
                        <td>
                            <input type="button" value="Search" onclick="javascript: search();" /></td>
                    </tr>
                </table>

            </div>

            <table id="Content">
                <thead class="tds">
                    <tr class="trc">
                        <th class="tds tdh">ID</th>
                        <th class="tds tdh">Subject</th>
                        <th class="tds tdh">Actor</th>
                        <th class="tds tdh">Date</th>
                        <th class="tds tdh">Description</th>
                        <th class="tds tdh">Status</th>
                    </tr>
                </thead>
                <%
                    foreach (System.Data.DataRow dr in dt.Rows) {
                        string status = (string)dr["STATUS"];
                        if (status == "S") status = "Scheduled";
                        else if (status == "F") status = "Finished";
                        else status = "Working";
                %>
                <tr class="trc">
                    <td class="tds"><%=dr["ID"] %></td>
                    <td class="tds"><%=dr["SUBJECT"] %></td>
                    <td class="tds"><%=dr["USERNAME"] %></td>
                    <td class="tds"><%=dr["SCHEDULESTART"] %>~<%=dr["SCHEDULEEND"] %></td>
                    <td class="tds"><%=dr["DESCRIPTION"] %></td>
                    <td class="tds"><%=status %></td>
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
