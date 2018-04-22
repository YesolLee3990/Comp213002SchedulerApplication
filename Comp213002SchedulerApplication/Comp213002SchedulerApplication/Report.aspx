<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Comp213002SchedulerApplication.Report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Popup container - can be anything you want */
        .popup {
            cursor: pointer;
        }

            /* The actual popup */
            .popup .popuptext {
                visibility: hidden;
                width: 40%;
                height: 300px;
                top:24%;
                left: 29%;
                background-color: white;
                box-shadow: 1px 2px 10px grey;
                color: #fff;
                text-align: center;
                border-radius: 6px;
                position: absolute;
                z-index: 1;
            }

                /* Popup arrow */
                /* Popup arrow */
                .popup .popuptext::after {
                    content: "";
                    position: absolute;
                    top: -30px;
                    margin-left: -5px;
                    border-width: 15px;
                    border-style: solid;
                    border-color: transparent transparent grey transparent;
                }


            /* Toggle this class - hide and show the popup */
            .popup .show {
                visibility: visible;
                -webkit-animation: fadeIn 1s;
                animation: fadeIn 1s;
            }

        /* Add animation (fade in the popup) */
        @-webkit-keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }
        /*=-===============================================*/
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

        <asp:Panel ID="Panel6" runat="server" ClientIDMode="Static" Width="300px">
            <%-- <div class="box">
                <h3>Chart</h3>
               
                <canvas id="myChart"></canvas>

            </div>--%>
        </asp:Panel>

        <div class="box">
            <asp:Label ID="lbExcel" runat="server" Text="Excel"></asp:Label>
            <!--Dropdown list for table-->
            <asp:Label ID="lbTable" runat="server" Text="Table : "></asp:Label>
            <asp:DropDownList ID="drpList1" runat="server" AutoPostBack="True" ClientIDMode="Static">
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
            
            <div class="popup" onclick="myFunction()">
                <p id="btnPopup" class="btn" style="background-color: whitesmoke;">Chart</p>
                <span class="popuptext" id="myPopup">

                    <h3>Chart</h3>

                    <canvas id="myChart" width="95%" ></canvas>


                </span>
            </div>
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



    </div>


    <script>
        // When the user clicks on div, open the popup
        function myFunction() {
            var popup = document.getElementById("myPopup");
            popup.classList.toggle("show");
        }
    </script>
    <!--Using Chart.js but don't know how to put our database...;-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
    <script>
        if (document.getElementById('btnPopup').click && document.getElementById('drpList1').value == '2') {

            var ctx = document.getElementById('myChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'bar',
            <%
        String nums = "", names = "";
        System.Data.DataTable dt = Comp213002SchedulerApplication.AppCode.controls.util.DBUtil.Select("SELECT count(1) 'CNT', a.username from userinfo a, task b where a.id = b.userinfo_id group by a.id, a.username order by a.username");
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            names += "'" + dr["USERNAME"] + "',";
            nums += dr["CNT"] + ",";
        }
        if (names.EndsWith(","))
        {
            names = names.Substring(0, names.Length - 1);
            nums = nums.Substring(0, nums.Length - 1);
        }
            %>
                // The data for our dataset
                data: {
                    labels: [<%=names%>],
                    datasets: [{
                        label: "Chart for Tasks",
                        backgroundColor: 'rgb(255, 99, 132)',
                        borderColor: 'rgb(255, 99, 132)',
                        data: [<%=nums%>],
                    }]
                },
                // Configuration options go here
                options: {}
            });
        } else {
            document.getElementById('Panel6').style.visibility = false;
        }
    </script>

</asp:Content>
