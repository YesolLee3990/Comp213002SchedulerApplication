<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestDetail.aspx.cs" Inherits="Comp213002SchedulerApplication.RequestDetail"%>

<!DOCTYPE html>
<link href="Content/ErrorDetail.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
</head>
<body>
    <h3>Request Detail</h3>
    <br />
        <%
            string id = Request["id"];
            string sql = " SELECT D.SUBJECT, D.ID AS 'TASKID', B.USERNAME, A.* " +
                        " FROM REQUESTTRANSACTION A, USERINFO B, TASK D " +
                        " WHERE A.ASSIGNEE = B.ID " +
                        " AND A.TASKID = D.ID" +
                        " AND A.ID = " + id;

            System.Data.DataRow dr = Comp213002SchedulerApplication.AppCode.controls.util.DBUtil.SelectOne(sql);
        %>
    <div>
        <table id="contentTable">
            <tr>
                <td style="width:100px;">Task Subject</td>
                <td style="cursor:pointer;color:blue" onclick="javascript:showTaskInfo();"><%=dr["SUBJECT"] %></td>
            </tr>
            <tr>
                <td style="width:100px;">Requester</td>
                <td><%=dr["USERNAME"] %></td>
            </tr>
            <tr>
                <td>Day off</td>
                <td><%Response.Write("T".Equals(dr["DAYOFFYN"]) ? "Yes" : "No"); %></td>
            </tr>
            <tr>
                <td>Request Date</td>
                <td><%=dr["NEWSTARTDATE"] %>~<%=dr["NEWENDDATE"] %></td>
            </tr>
            <tr>
                <td>Original Date</td>
                <td><%=dr["ORIGINALSTARTDATE"] %>~<%=dr["ORIGINALENDDATE"] %></td>
            </tr>
            <tr>
                <td>Commnet</td>
                <td><%=dr["COMMENT"] %></td>
            </tr> 
        </table>
    </div>
    <div class="searchRightCol">
        <input type="button" class="button" value="Reject" onclick="process('R');" />
        <input type="button" class="button" value="Accept" onclick="process('A');" />
    </div>
</body>
    <script>
        function process(type) {
            var msg;
            if (type == 'A') {
                if(confirm('Do you want to accept this request?')){
                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("requestDetail.aspx/Accept") %>',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ id: '<%=Request["id"]%>', taskId: '<%=dr["TASKID"]%>', dayoff: '<%=dr["DAYOFFYN"]%>' }), 
                        success: function (result, textStatus, jqXHR) {
                            if (result.d.Success) {
                                alert('Successfully accepted');
                                window.close();
                            } else {
                                alert('System failure! See detail : ' + result.d.ErrorMsg);
                            }
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            } else {
                if(confirm('Do you want to reject this request?')){
                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("requestDetail.aspx/Reject") %>',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ id: '<%=Request["id"]%>' }),
                        success: function (result, textStatus, jqXHR) {
                            if (result.d.Success) {
                                alert('Successfully rejected');
                                window.close();
                            } else {
                                alert('System failure! See detail : ' + result.d.ErrorMsg);
                            }
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            }
        }

        function showTaskInfo() {
            window.open('/angular/task?id=<%=dr["TASKID"]%>&mode=managerUpdate', '', 'width=900,height=600,scrollbars=1,resizable');
        }
    </script>
</html>