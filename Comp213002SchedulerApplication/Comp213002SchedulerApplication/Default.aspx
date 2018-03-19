<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp213002SchedulerApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .navbar-inverse {
            display: none;
        }
    </style>
    <script>
        function openNav1() {
            document.getElementById("mySidenav1").style.width = "25%";
            document.getElementById("main").style.marginLeft = "25%";
        }
        function openNav2() {
            document.getElementById("mySidenav2").style.width = "25%";
            document.getElementById("main").style.marginRight = "25%";
            document.getElementById("rightMenu").style.marginLeft = "90%";
        }
        function closeNav1() {
            document.getElementById("mySidenav1").style.width = "0";
            document.getElementById("main").style.marginLeft = "0";
        }
        function closeNav2() {
            document.getElementById("mySidenav2").style.width = "0";
            document.getElementById("main").style.marginRight = "0";
        }

    </script>
    <div id="mySidenav1" class="sidenav1">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav1()">&times;</a>
        <a href="/Report.aspx">Report</a>
        <a href="/Setting.aspx">Setting</a>
    </div>


    <div id="main" align="center">
        <img src="img/logo.png" width="40px" />
        <div>
            <span style="font-size: 30px; cursor: pointer;" onclick="openNav1()">&#9776;</span>
            <span id="rightMenu" style="font-size: 30px; cursor: pointer; margin-left: 90%;" onclick="openNav2()">&#9776;</span>
        </div>

        <asp:Calendar OnDayRender="Calendar1_DayRender" ID="Calendar1" DayStyle-HorizontalAlign="right" DayStyle-VerticalAlign="Top" DayStyle-Height="15%" runat="server" BackColor="White" BorderColor="White" Width="100%" Height="600px">
            <DayHeaderStyle BackColor="#ffbf80" Height="5px" />
            <SelectedDayStyle BackColor="#ffff80" Height="15%" ForeColor="black" HorizontalAlign="Right" VerticalAlign="Top" />
            <TitleStyle BackColor="#ff9f80" Height="5px" />
            <TodayDayStyle BackColor="#ffdf80" ForeColor="Black" Height="15%" />
        </asp:Calendar>

    </div>
    <div id="mySidenav2" class="sidenav2" align="right">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav2()">&times;</a>
        <a>Daily Tasks.</a>
        <div style="background-color: #fff9e6; border-radius: 10px; margin: 10px; padding: 5px; height: 50%">Today</div>
        <div style="background-color: #fff9e6; border-radius: 10px; margin: 10px; padding: 5px; height: 30%">Date</div>
        <div style="background-color: #fff9e6; border-radius: 10px; margin: 10px; padding: 5px; height: 20%">Date</div>
    </div>
</asp:Content>
