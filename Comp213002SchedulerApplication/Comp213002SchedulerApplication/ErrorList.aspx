﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorList.aspx.cs" Inherits="Comp213002SchedulerApplication.ErrorList" %>

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
            String errorMsg = (qs["errorMsg"]==null?"":qs["errorMsg"]);
            String errorDate = (qs["errorDate"]==null?"":qs["errorDate"]);
            String userId = (qs["userId"]==null?"":qs["userId"]);
        %>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Error List"></asp:Label>
            <div id="searchConditionBox">
                <div class="searchError">
                    <asp:Label ID="Label1" runat="server" Text="ErrorMsg : "></asp:Label><input type="text" id="txtErrMsg" name="errorMsg" value="<%=errorMsg %>"/></div>
                <div class="searchError">
                    <asp:Label ID="Label2" runat="server" Text="Date : "></asp:Label><input type="date" id="txtErrDate" name="errorDate" value="<%=errorDate %>"/> </div>
                <div class="searchError">
                    <asp:Label ID="Label3" runat="server" Text="User Name : "></asp:Label>
                    <select name="userId" id="selectUserID">
                        <option value="A" <%if ("A" == userId) Response.Write("selected"); %> >All</option>
                        <%
                            foreach(System.Data.DataRow dr in userList.Rows) {
                        %>
                        <option value="<%=dr["ID"] %>" <%if (""+dr["ID"] == userId) Response.Write("selected"); %> ><%=dr["USERNAME"] %></option>
                        <%
                            }
                        %>
                    </select>
                </div><br />
                <div class="searchRightCol"><input type="button" id="btnSearch" class="button" style="top:-80px;" value="Search" onclick="javascript: search();" /></div>
            </div><br />
            <table id="contentTable">
                <thead>
                    <tr>
                        <th style="width:50px;">ID</th>
                        <th style="width:100px;">Date</th>
                        <th style="width:100px;">User</th>
                        <th>ErrorMsg</th>
                    </tr>
                </thead>
                <%
                    foreach (System.Data.DataRow dr in dt.Rows) {
                %>
                <tr onclick="javascript:showErrorInfo('<%=dr["ID"] %>');">
                    <td><%=dr["ID"] %></td>
                    <td><%=dr["CREATEDATE"] %></td>
                    <td><%=dr["USERNAME"] %></td>
                    <td><%=dr["ERRORMSG"] %></td>
                </tr>
                <%
                    }
                %>
            </table>
        </div>
    </form>
</body>
<script>
    function search() {
        form1.action = 'ErrorList.aspx';
        form1.submit();
    }

    function showErrorInfo(id) {
        window.open('ErrorDetail.aspx?id=' + id, '', 'width=900,height=600,scrollbars=1,resizable');
    }

    $('#contentTable td').each(function () {
        $(this).prop('title', $(this).html());
    });
</script>
</html>
