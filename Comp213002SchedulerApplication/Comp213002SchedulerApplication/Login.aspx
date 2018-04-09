<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comp213002SchedulerApplication.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Dubai;
            margin-left: auto;
            width: 960px;
        }

        h3, h4 {
            font-family: Dubai;
        }

        #tbl1 {
            margin-right: auto;
            margin-left: auto;
            vertical-align: central;
        }

        #LogoName {
            background-color: white;
        }

        .auto-style1 {
            width: 300px;
            height: 263px;
        }

        .auto-style2 {
            width: 309px;
        }
    </style>
    <div style="box-shadow: 1px 0px 10px grey; width: 70%;">
        <div>
            <table id="tbl1" style="font-family: Consolas;">
                <tr>
                    <td colspan="2">
                        <%-- <h4 id="LogoName">ESMS</h4>--%>
                    </td>
                </tr>

                <tr>
                    <td rowspan="3">
                        <img src="img/MainLogo.jpg" /></td>
                    <td class="auto-style2">

                        <h4>Please Enter your detail to log in</h4>
                        <div class="col-md-6 divBody heightRegistration" id="loginDiv">
                            <div id="login" runat="server" visible="true">
                                <h2>Login</h2>
                                <table>
                                    <tr>
                                        <td>Username:</td>
                                        <td>
                                            <asp:TextBox Text="manager1" runat="server" ID="loginUsernameTB"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="loginUsernameTB" Display="Dynamic" ValidationGroup="login" ErrorMessage="Username is Required."></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Password:</td>
                                        <td>
                                            <asp:TextBox Text="manager1" runat="server" ID="loginPasswordTB"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="loginPasswordTB" Display="Dynamic" ValidationGroup="login" ErrorMessage="Password is Required."></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Button CssClass="btn btn-success" runat="server" Text="Login" ID="btnLogin" OnClick="Login_Click" />
                                <asp:Label runat="server" ID="WarningLblLogin" Visible="False" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script>
        var nav = document.getElementById('navigationBar');
        nav.style.visibility = 'hidden';
    </script>
</asp:Content>
