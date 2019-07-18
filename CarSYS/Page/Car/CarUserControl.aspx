<%@ Page MasterPageFile="~/CarSYSMasterPage.Master" Title="车辆信息展示" Language="C#" AutoEventWireup="true" CodeBehind="CarUserControl.aspx.cs" Inherits="CarSYS.Page.Car.CarInfoShow" %>
<%@ Register Src="~/UserControl/CarControl.ascx" TagName="Car" TagPrefix="url"  %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Contents" runat="server">

    <table>
        <tr>
            <td>
                <url:Car ID="Car1" runat="server"></url:Car>
            </td>
            <td> 
                <url:Car ID="Car2" runat="server" CarId="32"></url:Car>
            </td>
              <td> 
                <url:Car ID="Car3" runat="server" CarId="31"></url:Car>
            </td>
             <%--<td> 
                <url:Car ID="Car4" runat="server" CarId="34"></url:Car>
            </td>--%>
        </tr>
    </table>

</asp:Content>

