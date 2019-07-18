<%@ Page Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" Title="DataList车辆集合车辆" AutoEventWireup="true" CodeBehind="CarDataList.aspx.cs" Inherits="CarSYS.Page.Car.DataListCar" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">

       table.tbCar {
            border:1px solid black;
            border-collapse:collapse;
            width:400px;
            height:132px;
            
        }
            table.tbCar td {
                border:1px solid black;
            }

    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">

    <div style="height:32px;line-height:32px;">
        排序：
        <asp:DropDownList ID="ddlSort" runat="server" Width="282" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="价格"></asp:ListItem>
            <asp:ListItem Value="1" Text="点击量"></asp:ListItem>
        </asp:DropDownList>
        筛选：
        <asp:DropDownList ID="ddlBrand" runat="server" Width="282" AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged"></asp:DropDownList>

    </div>

        <div>
            <asp:DataList ID="dlCars" runat="server" AutoPostBack="true" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>

                    <table class="tbCar">

                        <tr style="background-color:aliceblue;text-align:center;">
                            <td colspan="2">
                                <asp:Label ID="lblCarName" runat="server" Text='<%#Bind("CarName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="4">
                                <asp:Image ID="ImgCar" runat="server" ImageUrl='<%#Eval("Picture","~/Images/Car/{0}") %>' Width="120px" Height="100px" />
                            </td>
                            <td>
                                编号：<asp:Label ID="lblCarId" runat="server" Text='<%#Bind("CarId") %>'></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                品牌：<asp:Label ID="Label1" runat="server" Text='<%#Bind("CarBrand.BrandName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                官方价格：<asp:Label ID="lblPrice" runat="server" Text='<%#Bind("OffcialPrice","{0:c}万") %>'></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                点击量：<asp:Label ID="lblClick" runat="server" Text='<%#Bind("Click") %>'></asp:Label>
                            </td>
                        </tr>
              
                        </table>
                </ItemTemplate>

                <SelectedItemTemplate></SelectedItemTemplate>
            </asp:DataList>
        </div>
    <div style="height:32px;line-height:32px; text-align:center; ">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
    </div>

</asp:Content>

