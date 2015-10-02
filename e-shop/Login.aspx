<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="e_shop.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="width: 50%">
            Sign in <br />
            <asp:TextBox ID="uname" runat="server"></asp:TextBox> <br />
            <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox> <br />
            <asp:Label ID="loginStatus" runat="server" Text=""></asp:Label> <br />
            <asp:Button ID="log_in" runat="server" Text="Sign In" OnClick="log_in_Click" />
        </div>
        <div style="width: 50%">
            Register <br />     
            <asp:TextBox ID="regUname" runat="server"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="regUname" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="regPass" runat="server" TextMode="Password"></asp:TextBox> <br />
            <asp:TextBox ID="regPAssConf" runat="server" TextMode="Password"></asp:TextBox>  
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="regPass" ControlToValidate="regPAssConf" ErrorMessage="CompareValidator" ForeColor="Red"> Passwords don&#39;t match!</asp:CompareValidator>
            <br />
            <asp:TextBox ID="regMail" runat="server" TextMode="Email"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="regMail" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="unameTaken" runat="server" ForeColor="Red" Text="Username is already taken. Please try with another one!" Visible="False"></asp:Label><br />
            <asp:Button ID="reg" runat="server" Text="Sign Up" OnClick="reg_Click" />

        </div>
    
    </div>
    </form>
</body>
</html>
