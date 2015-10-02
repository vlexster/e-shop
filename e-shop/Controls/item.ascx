<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item.ascx.cs" Inherits="e_shop.item" %>
<div class="item" style="border:3px solid #808080; width: 200px; position: relative; margin:2px;">
    <div class="iImg">
        <asp:Image ID="iImg" runat="server" />
    </div>
    <div class="iHLink">
        <asp:HyperLink ID="iHLink" runat="server">HyperLink</asp:HyperLink>
    </div>
    <div class="iDescr">
        <asp:Label ID="iDescr" runat="server" Text="Label"></asp:Label>
    </div>
</div>