<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemoryCacheExample.aspx.cs" Inherits="WebAppExample.MemoryCacheExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label runat="server" Text="Users"></asp:Label>
        <asp:DropDownList ID="DropDownListUsers" runat="server">
        </asp:DropDownList>
        <asp:Button runat="server" ID="BtnLoadUsers" OnClick="BtnLoadUsers_Click" style="height: 26px" Text="Load Users"/>
      
    </div>
    </form>
</body>
</html>
