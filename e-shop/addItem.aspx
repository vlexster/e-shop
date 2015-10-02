<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="e_shop.addItem" %>

<%@ Register Src="~/Controls/item.ascx" TagPrefix="uc1" TagName="item" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 273px">
        <asp:Label ID="lblPreview" runat="server" Text="Preview"></asp:Label>
        <uc1:item runat="server" ID="itemPV" /><br /> <br />
        <asp:TextBox ID="imgSrc" runat="server" OnTextChanged="imgSrc_TextChanged" AutoPostBack="True" TextMode="Url">Image source</asp:TextBox>
        <asp:RequiredFieldValidator ID="imgSrcVal" runat="server" ControlToValidate="imgSrc" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Required field</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="HLTxt" runat="server" OnTextChanged="HLTxt_TextChanged" AutoPostBack="True">Hyperlink text</asp:TextBox>
        <asp:RequiredFieldValidator ID="hlTxtVal" runat="server" ControlToValidate="HLTxt" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Required field</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="HLsrc" runat="server" OnTextChanged="HLsrc_TextChanged" AutoPostBack="True" TextMode="Url">Hyperlink source</asp:TextBox>
        <asp:RequiredFieldValidator ID="hlSrcVal" runat="server" ControlToValidate="HLsrc" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Required field</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="Desctxt" runat="server" OnTextChanged="Desctxt_TextChanged" AutoPostBack="True" Height="57px" TextMode="MultiLine" Width="168px">Description</asp:TextBox>
        <asp:RequiredFieldValidator ID="descVal" runat="server" ControlToValidate="Desctxt" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Required field</asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" Width="126px" OnClick="Submit" />
            </div>
    </form>
</body>
</html>
