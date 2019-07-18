<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Car.ascx.cs" Inherits="CarSYS.UserControls.Car" %>
<style type="text/css">
    table.car {
        width:500px;
        border:1px solid black;
        border-collapse:collapse;
    }
    table.car td{
        border:1px solid black;
    }
</style>

<table class="car">
    <tr>
        <td>车型名称:</td>
        <td>
            <asp:Label ID="lblCarName" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>

     <tr>
        <td>品牌名称:</td>
        <td>
            <asp:Label ID="lblBrandName" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>

     <tr>
        <td>实物图:</td>
        <td>
            <asp:Image ID="imaCar" runat="server" Width="250" Height="160" />
        </td>
    </tr>

     <tr>
        <td>官方价格:</td>
        <td>
            <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>

    <tr>
        <td>点击量:</td>
        <td>
            <asp:Label ID="lblClick" runat="server" Text="Label"></asp:Label>
            <asp:HiddenField ID="HFId" runat="server" />
        </td>
    </tr>

</table>