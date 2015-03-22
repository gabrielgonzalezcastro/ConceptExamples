<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="EmployeeId"></asp:Label>
            <asp:TextBox ID="txtEmployeeId" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
            <asp:LinkButton ID="linkBtnGetEmployee" runat="server" OnClick="linkBtnGetEmployee_Click">Go</asp:LinkButton>
            <table class="auto-style1">
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>LastName</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Department</td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="linkBtnUpdateDeptName" runat="server" OnClick="linkBtnUpdateDeptName_Click">Update</asp:LinkButton>
                        &nbsp; &nbsp;<asp:LinkButton ID="linkBtnUpdateWithConcurrencyCheckWithWhere" runat="server" OnClick="linkBtnUpdateWithConcurrencyCheckWithWhere_Click">UpdateWithConcurrencyCheckWithWhere</asp:LinkButton>
                        <asp:HiddenField ID="hdfDepartmentName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDepartmentId" runat="server" Text="0"></asp:Label>
                        <br />
                       
                        <asp:Button ID="btnSqlException" runat="server" OnClick="btnSqlException_Click" Text="Throw Sql Exception" />
                        <br />
                    </td>

                </tr>
                <tr>
                    <td>
                        <br/>
                        <span style="text-decoration: underline;"> SQL Statistics:</span>
                       <br />
                        <asp:ListBox ID="ListBoxStats" runat="server" Height="208px" Width="156px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br/>
                        <span style="text-decoration: underline;">Application Log</span>
                        <br/>
                        <br/>
                         <asp:Button ID="btnDeleteLog" runat="server" OnClick="btnDeleteLog_Click" Text="Delete Log" />
                        &nbsp; &nbsp; 
                         <asp:Button ID="btnDeleteUsingSQLTransaction" runat="server" Text="Delete Log Using SQL Transaction" OnClick="btnDeleteUsingSQLTransaction_Click" />
                        &nbsp;&nbsp;
                         <asp:Button ID="btnDeleteUsingTransactionScope" runat="server" Text="Delete Log Using Transaction Scope" OnClick="btnDeleteUsingTransactionScope_Click" />
                         &nbsp;&nbsp;
                         <asp:Button ID="btnDeleteUsingDatabaseTransaction" runat="server" Text="Delete Log Using Database Transaction" OnClick="btnDeleteUsingDatabaseTransaction_Click" />
                         &nbsp;&nbsp;
                         <asp:Button ID="btnUpdateLog" runat="server" Text="Make Changes and Update Log in Batch" OnClick="btnUpdateLog_Click" />

                        <br />
                        <br/>
                        <asp:GridView ID="GridViewAppLog" runat="server"></asp:GridView>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
