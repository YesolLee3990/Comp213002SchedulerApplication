<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Comp213002SchedulerApplication.Report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <!--Tried to use google chart but cannot use entity-->

    <%--            <script src="Scripts/jquery-1.7.1.js"></script>
            <script type="text/javascript" src="https://www.google.com/jsapi"></script>
 
            <script>
                var chartData; // globar variable for hold chart data
                google.load("visualization", "1", { packages: ["corechart"] });
 
                // Here We will fill chartData
 
                $(document).ready(function () {
           
                    $.ajax({
                        url: "GoogleChart.aspx/GetChartData",
                        data: "",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; chartset=utf-8",
                        success: function (data) {
                            chartData = data.d;
                        },
                        error: function () {
                            alert("Error loading data! Please try again.");
                        }
                    }).done(function () {
                        // after complete loading data
                        google.setOnLoadCallback(drawChart);
                        drawChart();
                    });
                });
 
 
                function drawChart() {
                    var data = google.visualization.arrayToDataTable(chartData);
 
                    var options = {
                        title: "Company Revenue",
                        pointSize: 5
                    };
 
                    var pieChart = new google.visualization.PieChart(document.getElementById('chart_div'));
                    pieChart.draw(data, options);
 
                }
 
            </script>--%>

    <style>
        body {
            margin-top: 3%
        }

        .firstGrid {
            background-color: whitesmoke;
        }

        .box {
            border-radius: 10px;
            padding: 10px 10px 40px 10px;
            margin: 10px;
            box-shadow: 1px 2px 10px grey;
        }
    </style>
    <div align="center">
        <asp:Label ID="lbTitle" runat="server" Text="Title"></asp:Label>
        <div class="box">
            <asp:Label ID="lbExcel" runat="server" Text="Excel"></asp:Label>
            <!--Dropdown list for table-->
            <asp:Label ID="lbTable" runat="server" Text="Table : "></asp:Label>
            <asp:DropDownList ID="drpList1" runat="server" AutoPostBack="True">
                <asp:ListItem>...</asp:ListItem>
                <asp:ListItem Value="1">UserInfo</asp:ListItem>
                <asp:ListItem Value="2">Task</asp:ListItem>
                <asp:ListItem Value="3">Transaction</asp:ListItem>
                <asp:ListItem Value="4">Error</asp:ListItem>
            </asp:DropDownList>

            <!--Dropdown list for userId-->
            <asp:DropDownList ID="drpList" runat="server" AppendDataBoundItems="true" DataSourceID="ScheDatabase" DataTextField="Id" DataValueField="Id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">UserId</asp:ListItem>
            </asp:DropDownList>

            <!--Button for Export to Excel-->
            <asp:Button ID="Button2" CssClass="btn" runat="server" OnClick="Button2_Click" Text="Export to Excel" />
            <p></p>


            <!--Gridview for combobox/ Visible is false-->
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ScheDatabase" HeaderStyle-BackColor="#FF9999" BorderColor="White">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType" />
                        <asp:BoundField DataField="EmployeeStatus" HeaderText="EmployeeStatus" SortExpression="EmployeeStatus" />
                        <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" SortExpression="CreateDate" />
                        <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate" SortExpression="UpdateDate" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="ScheDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:esmsDbConnectionStr %>" SelectCommand="SELECT * FROM [UserInfo]"></asp:SqlDataSource>
            </asp:Panel>

            <!--Gridview by user id/Use Asp.net function/ not dynamic-->
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" HeaderStyle-BackColor="#FF9999" BorderColor="White">

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType" />
                        <asp:BoundField DataField="EmployeeStatus" HeaderText="EmployeeStatus" SortExpression="EmployeeStatus" />
                        <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" SortExpression="CreateDate" />
                        <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate" SortExpression="UpdateDate" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:esmsDbConnectionStr %>" SelectCommand="SELECT * FROM [UserInfo] WHERE ([Id] = @Id)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drpList" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>

            <!--Gridview by table/ Dynamic gridview-->
            <asp:Panel ID="Panel5" runat="server">
                <asp:GridView ID="GridView5"
                    runat="server" CellPadding="4" CssClass="table table-striped table-bordered table-condensed" ForeColor="#333333" HeaderStyle-BackColor="#FF9999" BorderColor="White">

                    <Columns>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>


        <div class="box">
            <h3>Chart</h3>

            <!--Using Chart.js but don't know how to put our database...;-->
            <canvas id="myChart"></canvas>

            <!--Asp.net Chart. Connected to table, but looks not good-->
            <asp:Chart ID="Chart1" runat="server" DataSourceID="ScheDatabase"  Palette="Pastel">
               <Series>
                    <asp:Series Name="Series1" XValueMember="UserId" YValueMembers="CreateDate"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
                <BorderSkin BackColor="SandyBrown" BorderColor="Goldenrod" />
            </asp:Chart>

        </div>
    </div>

    <!--Using Chart.js but don't know how to put our database...;-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
    <script>
        var ctx = document.getElementById('myChart').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'bar',


            // The data for our dataset
            data: {
                labels: ["Manager1", "Admin1", "Staff1", "Staff2", "Staff3", "Staff4", "Staff5"],
                datasets: [{
                    label: "My First dataset",
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: [0, 10, 5, 2, 20, 30, 45],
                }]
            },

            // Configuration options go here
            options: {}
        });
    </script>

</asp:Content>
