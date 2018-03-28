﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp213002SchedulerApplication._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <style>
        .navbar-inverse {
            display: none;
        }
        .modalBackground  
        {  
            width:550px;
            height:650px;       
            background-color: #336699;  
            filter: alpha(opacity=80);  
            opacity: 0.8;  
        }   
  
    </style>
    <script type="text/javascript">
        var left = false, right = false;
        function openNav1() {
            if (!left){
                document.getElementById("mySidenav1").style.width = "25%";
                document.getElementById("main").style.marginLeft = "25%";
            } else {
                document.getElementById("mySidenav1").style.width = "0%";
                document.getElementById("main").style.marginLeft = "0%";
            }
            left = !left;
        }
        function openNav2() {
            if (!right) {
                document.getElementById("mySidenav2").style.width = "25%";
                document.getElementById("main").style.marginRight = "25%";
            } else {
                document.getElementById("mySidenav2").style.width = "0%";
                document.getElementById("main").style.marginRight = "0%";
            }
            right = !right;
        }

        function assignTask() {
            window.open('/angular/task/', '', 'width=900,height=600,scrollbars=1,resizable');
        }

        function refreshPage() {
            document.location.href = '/Default.aspx';
        }

        function closeNav1() {
            document.getElementById("mySidenav1").style.width = "0";
            document.getElementById("main").style.marginLeft = "0";
        }
        function closeNav2() {
            document.getElementById("mySidenav2").style.width = "0";
            document.getElementById("main").style.marginRight = "0";
        }
        function ShowModalPopup() {
            $(document).find('popup1').show();
            return false;
        }
        function HideModalPopup() {
            $find('popup1').hide();
            return false;
        }

    </script>
    <div id="mySidenav1" class="sidenav1">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav1()">&times;</a>
        <a href="/Report.aspx">Report</a>
        <a href="/Setting.aspx">Setting</a>
    </div>


    <div id="main" style="margin:auto;">
        <div style="float:right">
            <asp:Label ID="loginInfoLabel" runat="server"></asp:Label>
            <asp:Button ID="logoutBtn" runat="server" Text="Logout" BorderStyle="None" BorderWidth="0px" CausesValidation="False"/>
        </div>
        <div style="margin:auto">
            <img src="img/logo.png" width="40" />
        </div>
        <div>
            <table style="width:100%">
                <tr>
                    <td><span style="font-size: 30px; cursor: pointer;float:left;" onclick="openNav1()">&#9776;</span></td>
                    <td>
                        <span id="rightMenu" style="font-size: 30px; cursor: pointer; float:right;width:30px;" onclick="openNav2()">&#9776;</span>
                        <asp:Button id="assignTaskBtn" CssClass="assignBtn" OnClientClick="assignTask()" Text="Assign Task" runat="server" UseSubmitBehavior="false"/>
                    </td>
                </tr>
            </table>
        </div>

        <asp:Calendar OnDayRender="Calendar1_DayRender" ID="Calendar1" DayStyle-HorizontalAlign="right" DayStyle-VerticalAlign="Top" DayStyle-Height="15%" runat="server" BackColor="White" BorderColor="White" Width="100%" Height="600px" OnSelectionChanged="Calendar1_SelectionChanged">
            <DayHeaderStyle BackColor="#ffbf80" Height="5px" />
            <SelectedDayStyle BackColor="#ffff80" Height="15%" ForeColor="black" HorizontalAlign="Right" VerticalAlign="Top" />
            <TitleStyle BackColor="#ff9f80" Height="5px" />
            <TodayDayStyle BackColor="#ffdf80" ForeColor="Black" Height="15%" />
        </asp:Calendar>
       
        <asp:LinkButton ID="x" runat="server"></asp:LinkButton>
        
        <div id="resPopupDiv">
            <cc1:ModalPopupExtender DropShadow="true" BehaviorID="popup1" ID="ModalPopupExtender1" runat="server"
                CancelControlID="btnClose" PopupControlID="Panel1" TargetControlID="x" BackgroundCssClass="modalBackground" >
            </cc1:ModalPopupExtender>

            <asp:panel id="Panel1" style="display:none;width:550px;height:700px;background-color:antiquewhite" runat="server">
	        <div class="reschedulePopup" style="width:550px;height:650px;">
                <object style="width:550px;height:650px;" type="text/html" data="./reschedulePopup.aspx">
                </object>
                
                <asp:Button ID="btnRequest" runat="server" Text="Request" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" />
            </div>
            </asp:panel>   
        </div>
        
    </div>
    <div id="mySidenav2" class="sidenav2" align="right">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav2()">&times;</a>
        <a>Daily Tasks.</a>
        <div style="background-color: #fff9e6; border-radius: 10px; margin: 10px; padding: 5px; height: 50%">Today</div>
        <div style="background-color: #fff9e6; border-radius: 10px; margin: 10px; padding: 5px; height: 30%">Date</div>
        <div style="background-color: #fff9e6; border-radius: 10px; margin: 10px; padding: 5px; height: 20%">Date</div>
    </div>
</asp:Content>