<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMaterPage.Master" AutoEventWireup="true" CodeBehind="CarList.aspx.cs" Inherits="CarSYS.CarList" %>
<%@ Register Src="~/UserControls/Car.ascx" TagPrefix="ucl" TagName="Car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>车型列表</h2>

    <table>
        <tr>
            <td>
                 <ucl:Car runat="server" id="Car"></ucl:Car>
            </td>
            <td>

                <ucl:Car runat="server" id="Car1" CarId="2"></ucl:Car>
            </td>
        </tr>
    </table>
   

   
</asp:Content>
