<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarControl.ascx.cs" Inherits="CarSYS.UserControl.CarControl" %>

<style type="text/css">
    table#CarShow {
            width:400px;
            height:300px;
            border:1px solid black;
            border-collapse:collapse;
            margin-left:10px;
         }
    table#CarShow td{
        border:1px solid black;
        text-align:center;
    }


</style>


<table Id="CarShow">
    <tr>
        <td>车辆名称：</td>
        <td>
            <asp:Label ID="lblCarName" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>

     <tr>
        <td>品牌：</td>
        <td>
            <asp:Label ID="lblBrandName" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>


     <tr>
        <td>实物图：</td>
        <td>
            <asp:Image ID="imgCar" runat="server" Width="180" Height="100" />
        </td>
    </tr>

     <tr>
        <td>官方价格：</td>
        <td>
            <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>

     <tr>
        <td>点击量：</td>
        <td>
            <asp:Label ID="lblClick" runat="server" Text="Label"></asp:Label>


            <asp:HiddenField ID="HFId" runat="server"></asp:HiddenField>
        </td>
         
    </tr>

</table>

