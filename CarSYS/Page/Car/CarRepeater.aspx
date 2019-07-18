<%@ Page Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" Title="车辆列表Repeater" AutoEventWireup="true" CodeBehind="CarRepeater.aspx.cs" Inherits="CarSYS.Page.Car.CarRepeater" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ContentPlaceHolderID="head" ID="Content01" runat="server">

    <style type="text/css">
        #tbList {
            width: 750px;
            margin: 0 auto;
        }

            #tbList table {
                border: 1px solid #ccc;
                border-collapse: collapse;
                width: 100%;
                margin: 0 auto;
            }

                #tbList table td,#tbList table th {
                    border:1px solid #ccc;
                    text-align:center;
                    vertical-align:middle;
                }

                #tbList table tb {
                }
        a img {
            border:none;
        }
    </style>

</asp:Content>

<asp:Content ContentPlaceHolderID="Contents" ID="Content02" runat="server">

    <div style="height: 32px">
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
    </div>

    <div id="tbList">
        <asp:Repeater ID="carRepeater" runat="server">
            <HeaderTemplate>
                <table>
                    <th>编号</th>
                    <th>名称</th>
                    <th>品牌</th>
                    <th>官方价</th>
                    <th>点击量</th>
                    <th>实物图</th>
                    <th>操作</th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("CarId") %></td>
                    <td><%#Eval("CarName") %></td>
                    <td><%#Eval("CarBrand.BrandName") %></td>
                    <td><%#Eval("OffcialPrice","{0:c}万") %></td>
                    <td><%#Eval("Click") %></td>
                    <td>
                        <a href="Details.aspx?CarId=<%#Eval("CarId")%>">
                              <img src="<%#Eval("Picture","../../Images/Car/{0}") %>" width="120" height="80" />
                        </a>

                    </td>

                    <td>
                        <asp:Button ID="btnDel" runat="server" Text="删除" />
                        <asp:Button ID="btnEdit" runat="server" Text="编辑" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td><%#Eval("CarId") %></td>
                    <td><%#Eval("CarName") %></td>
                    <td><%#Eval("CarBrand.BrandName") %></td>
                    <td><%#Eval("OffcialPrice","{0:c}万") %></td>
                    <td><%#Eval("Click") %></td>
                    <td>
                        <a href="Details.aspx?CarId=<%#Eval("CarId")%>">
                           <img src="<%#Eval("Picture","../../Images/Car/{0}") %>" width="120" height="80" />
                        </a>
                    </td>

                    <td>
                        <asp:Button ID="btnDel" runat="server" Text="删除" />
                        <asp:Button ID="btnEdit" runat="server" Text="编辑" />
                    </td>

                </tr>

            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            <SeparatorTemplate></SeparatorTemplate>
        </asp:Repeater>

        
    </div>
     <div style="height:32px;text-align:center">
        <webdiyer:AspNetPager ID="aspPage" runat="server" OnPageChanging="aspPage_PageChanging"></webdiyer:AspNetPager>
    </div>
</asp:Content>


