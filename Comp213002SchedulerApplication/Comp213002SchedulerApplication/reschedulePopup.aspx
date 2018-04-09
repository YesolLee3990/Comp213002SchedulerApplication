<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reschedulePopup.aspx.cs" Inherits="Comp213002SchedulerApplication.reschedulePopup" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <link href="Content/jquery-ui.theme.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script>
      $( function f1() {
          $("#txtSdateValue").datepicker({
          showOn: "button",
          buttonImage: "img/calendar.gif",
          buttonImageOnly: true,
          buttonText: "Select Start date",
          dateFormat: "yy-mm-dd",
          showOtherMonths: true,
          selectOtherMonths: true
          });
      } );
    
      $( function f2() {
          $("#txtEdateValue").datepicker({
          showOn: "button",
          buttonImage: "img/calendar.gif",
          buttonImageOnly: true,
          buttonText: "Select End date",
          dateFormat: "yy-mm-dd",
          showOtherMonths: true,
          selectOtherMonths: true
          });
      } );
    </script>

    <title></title>
    </head>
<body style="width: 500px; height: 500px;">
    <form id="form1" runat="server">
        <div id="allpageDiv" style="width: auto; height: auto; margin: 10%;">
            <div id="headerDiv" style="width: auto; height: 40px;">
                <asp:Label ID="lbHeader" runat="server" Text="Your task List"></asp:Label>
            </div>

            <div id="detailDiv" style="width: auto; height: 450px;">
            <asp:DropDownList ID="ddTaskList" runat="server" Height="16px" AutoPostBack="True" OnSelectedIndexChanged="ddTaskList_SelectedIndexChanged" Width="207px"></asp:DropDownList>



                <br />
                <asp:Label ID="lbContents" runat="server" Text=""></asp:Label>


                <br />
                <asp:Label ID="labelSdate" runat="server" Text="Start Date : "></asp:Label>
                <asp:TextBox ID="txtSdateValue" runat="server" OnTextChanged="txtSdateValue_TextChanged"></asp:TextBox>
                <br />
                <asp:Label ID="labelEdate" runat="server" Text="End Date : "></asp:Label>&nbsp
                <asp:TextBox ID="txtEdateValue" runat="server"></asp:TextBox>
                <br />
                <br />


                <asp:TextBox ID="txtComment" runat="server" Height="132px" Width="388px"></asp:TextBox>


                <br />
                <asp:CheckBox ID="cBoxDayOff" runat="server" Text="Request day-off" />
                <br />
                <br />

                <asp:Button ID="Button1" runat="server" OnClick="ButtonRequest_Click" Text="Request" />
                <asp:Label ID="lbErrorMsg" runat="server" ForeColor="#FF0066"></asp:Label>
            </div>



        </div>
    </form>
</body>
</html>
