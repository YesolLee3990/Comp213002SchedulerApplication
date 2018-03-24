<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comp213002SchedulerApplication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <div>
                  <table id="tbl1">       
                         <tr><td colspan="2">
                             <h4 id="LogoName">ESMS</h4></td></tr> 

                         <tr><td rowspan="3">
                             <img src="img/MainLogo.jpg" /></td><td class="auto-style2"> 
        
                                 <h4>Please Enter your detail to log in</h4>
                                 <div class="col-md-6 divBody heightRegistration" id="loginDiv">

                <div id="nologin" runat="server" visible="false">
                    <h1>Welcome</h1>
                    <p>User : <asp:Label ID="Username" runat="server" Text="Label" BackColor="Red"></asp:Label></p>
                   </div>
        <div id="login" runat="server" visible="true">

                     
        <h2>Login</h2>
        <table>
        <tr><td>Username:</td><td> <asp:TextBox runat="server" ID="loginUsernameTB"></asp:TextBox>
                              </td></tr>

        <tr><td>Password:</td><td> <asp:TextBox runat="server" ID="loginPasswordTB" TextMode="Password"></asp:TextBox>
                              </td></tr>
            </table>
        <br />
        <asp:Button CssClass="btn" runat="server" Text="Login" ID="btnLogin" OnClick="Login_Click"/>
        <asp:Label runat="server" ID="WarningLblLogin"></asp:Label>
            

  
                            </div>
                        </div>
                                           
                         </td></tr> 
                         
        
                         </table>
        
         
                </div>
        </div>
</asp:Content>
