<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="e_shop._default" %>

<%@ Register src="Controls/item.ascx" tagname="item" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 163px;
        }
        #uid {
            width: 166px;
        }
        #pwd {
            width: 165px;
        }
        #Password1 {
            width: 166px;
        }
        #Button1 {
            width: 171px;
        }
        #login {
            width: 172px;
        }
    </style>
    <script type="text/javascript">
            function displCont() {
                document.getElementById('content').style.display = "block";
            }
    </script>
</head>
<body>

    <form id="form1" runat="server">
    <div>
            <asp:HyperLink ID="loginFrm" runat="server" NavigateUrl="~/Login.aspx" Target="_self">Sign in/ Sign up</asp:HyperLink>
            <asp:Button ID="logout" runat="server" OnClick="logout_Click" Text="Log Out" Visible="False" />
    </div>
    <div style="display:block;" id="content">
        <asp:PlaceHolder runat="server" ID="contPlcHldr" />
    </div>

    </form>
    </body>
</html>
