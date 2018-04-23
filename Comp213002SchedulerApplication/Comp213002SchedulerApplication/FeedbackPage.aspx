<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackPage.aspx.cs" Inherits="Comp213002SchedulerApplication.FeedbackPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border-style: groove; border-width: thick; font-size: large; font-weight: bold; color: #FFFFFF;  /*margin-right: auto; margin-left: auto; width:284px; padding-top: 20px;*/" >
    <table>

            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="black"></asp:Label>    
                </td>
                <td>
                    <asp:TextBox 
                        ID="txtName" 
                        Width="200px" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator1" 
                        runat="server"
                        ControlToValidate="txtName" 
                        ErrorMessage="Name is required" 
                        Text="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
                         
          <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="E-mail" ForeColor="black"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox 
                        ID="txtEmail" 
                        Width="200px" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator 
                        Display="Dynamic" 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator2"
                        runat="server" 
                        ControlToValidate="txtEmail" 
                        ErrorMessage="Email is required"
                        Text="*">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                        Display="Dynamic" 
                        ForeColor="Red" 
                        ID="RegularExpressionValidator1"
                        runat="server" 
                        ErrorMessage="Invalid Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail"
                        Text="*">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 24px">
                    <asp:Label ID="Label4" runat="server" Text="Subject" ForeColor="black"></asp:Label> 
                </td>
                <td style="height: 24px">
                    <asp:TextBox 
                        ID="txtSubject" 
                        Width="200px" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator3" 
                        runat="server"
                        ControlToValidate="txtSubject" 
                        ErrorMessage="Subject is required" 
                        Text="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Label ID="Label3" runat="server" Text="Message" ForeColor="black"></asp:Label> 
                </td>
                <td style="vertical-align: top">
                    <asp:TextBox 
                        ID="txtComments" 
                        Width="200px" 
                        TextMode="MultiLine" 
                        Rows="5" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td style="vertical-align: top" class="auto-style1">
                    <asp:RequiredFieldValidator 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator4" 
                        runat="server"
                        ControlToValidate="txtComments" 
                        ErrorMessage="Comments is required" 
                        Text="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left">
                    <asp:ValidationSummary 
                        HeaderText="Please fix the following errors" 
                        ForeColor="Red"
                        ID="ValidationSummary1" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; height: 24px;">
                    <asp:Label 
                        ID="lblMessage" 
                        runat="server" 
                        Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
        <tr>
                <td colspan="3" style="text-align: center">
                    <asp:Button 
                        ID="Button1" 
                        runat="server" 
                        Text="Submit" OnClick="Button1_Click" 
                         />
                    <asp:Button ID="btnList" runat="server" Text="List" OnClientClick="window.open('FeedbackList.aspx', 'newWindow', 'width=600,height=700');returnfalse;" OnClick="btnList_Click" />
                </td>
            </tr>
           
        </table>
    </div>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:esmsDbConnectionStr %>" SelectCommand="SELECT * FROM [dbo].[Feedback]"></asp:SqlDataSource>
    </form>
</body>
</html>
