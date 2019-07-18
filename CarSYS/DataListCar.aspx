<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMaterPage.Master" AutoEventWireup="true" CodeBehind="DataListCar.aspx.cs" Inherits="CarSYS.DataListCar" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %><%--注册分页控件--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">

        table.tbCar {
            border:1px solid black;
            border-collapse:collapse;
            width:300px;
            height:132px;
        }
            table.tbCar td {
                border:1px solid black;
            }
       

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<p>
    请选择排序方式：
        <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
            <asp:ListItem Value="0">官方价格</asp:ListItem>
            <asp:ListItem Value="1">点击量</asp:ListItem>
        </asp:DropDownList>
    请选择怕品牌：
        <asp:DropDownList ID="ddlBrand" runat="server" Width="250" AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged"></asp:DropDownList>
</p>
<asp:DataList ID="dtCars" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"> 
    <ItemTemplate>
       <table class="tbCar">
           <tr style="background-color:aliceblue;text-align:center;">
               <td colspan="2">
                   <asp:Label ID="lblCarName" runat="server" Text='<%#Bind("CarName") %>'></asp:Label>
               </td>
           </tr>

           <tr>
               <td rowspan="4">
                   <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Picture","~/Images/{0}") %>' Width="120px" Height="100px" />
               </td>
               <td>
                   编号：<%--<asp:Label ID="lblCarId " runat="server"  Text='<%#Eval("CarId") %>'></asp:Label>--%><asp:Label ID="Label2" runat="server" Text='<%# Eval("CarId") %>'></asp:Label></td>
               </td>
           </tr>

           <tr>
               <td>品牌：<asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:Label></td>
           </tr>

           <tr>
               <td>
                   官方价格：<asp:Label ID="Label1" runat="server" Text='<%# Bind("OfficilPrice","{0:c}万") %>'></asp:Label></td>
               </td>
           </tr>

           <tr>
               <td>
                   <asp:Label ID="lblClick" runat="server" Text='<%#Bind("Click") %>'></asp:Label>
               </td>
           </tr>
       </table>
    </ItemTemplate>

        <SelectedItemTemplate></SelectedItemTemplate>

    </asp:DataList>
      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager> <%--分页控件--%>
</asp:Content>
