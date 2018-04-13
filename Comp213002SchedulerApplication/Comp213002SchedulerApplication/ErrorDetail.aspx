<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorDetail.aspx.cs" Inherits="Comp213002SchedulerApplication.ErrorDetail" %>

<!DOCTYPE html>
<link href="Content/ErrorDetail.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
</head>
<body>
    <h3>Error Detail</h3>
    <br />
        <%
            string id = Request["id"];
            System.Data.DataRow dr = Comp213002SchedulerApplication.AppCode.controls.util.DBUtil.SelectOne("SELECT B.USERNAME, A.* FROM ERROR A, USERINFO B WHERE A.ID='" + id + "' AND A.USERID = B.ID ");
        %>
        <div>
            <table id="contentTable">
                <tr>
                    <td style="width:100px;">Id</td>
                    <td><%=dr["ID"] %></td>
                </tr>
                <tr>
                    <td>User Name</td>
                    <td><%=dr["USERNAME"] %></td>
                </tr>
                <tr>
                    <td>Date</td>
                    <td><%=dr["CreateDate"] %></td>
                </tr>
                <tr>
                    <td>Error Detail</td>
                    <td><%=dr["ERRORMSG"] %></td>
                </tr>
            </table>
        </div>
        <div class="searchRightCol"><input type="button" class="button" value="Close" onclick="window.close();" /></div>
</body>
</html>