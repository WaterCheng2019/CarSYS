<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMaterPage.Master" AutoEventWireup="true" CodeBehind="RepeaterCar.aspx.cs" Inherits="CarSYS.RepeaterCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        div {
            width:750px;
            margin:0px auto;
        }
        h3 {
            text-align:center;
            line-height:30px;
        }
        table.cartab {
            border:1px solid black;
            border-collapse:collapse;
            margin:0px auto;
            width:100%;
        }
            table.cartab td ,table.cartab th{
                border:1px solid black;
                text-align:center;
                vertical-align:middle;
            }
        table.cartab tr.cartab {
            background-color:rebeccapurple;
        }
        a img {
            border:none;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div>
       <h3>车型列表</h3>

       <asp:Repeater ID="repeaterCar" runat="server" OnItemCommand="repeaterCar_ItemCommand">
           <HeaderTemplate>
               <table class="cartab">
                   <tr>
                       <th>车型名称</th>
                       <th>品牌</th>
                       <th>官方价格</th>
                       <th>点击量</th>
                       <th>实物图</th>
                       <th>操作</th>
                   </tr>
          
           </HeaderTemplate>

           <ItemTemplate>

               <tr>
                   <td><%# Eval("CarName") %></td>
                   <td><%# Eval("CarBrand.BrandName") %></td>
                   <td><%# Eval("OfficilPrice","{0:c}万") %></td>
                   <td><%# Eval("Click") %></td>

                   <td>
                       <a href="DetailCar.aspx?CarId=<%# Eval("CarId") %>"></a>
                       <img src='<%# Eval("Picture","Images/{0}") %>' width="100" height="80"/>
                   </td>

                   <td>
                       <asp:Button ID="btnDel" runat="server" Text="删除" CommandName="del" CommandArgument='<%# Eval("CarId") %>' />
                       <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandName="edit" CommandArgument='<%# Eval("CarId") %>' />
                   </td>

               </tr>

           </ItemTemplate>

           <AlternatingItemTemplate>

               <tr class="atrow">

                    <td><%# Eval("CarName") %></td>
                   <td><%# Eval("CarBrand.BrandName") %></td>
                   <td><%# Eval("OfficilPrice","{0:c}万") %></td>
                   <td><%# Eval("Click") %></td>

                   <td>
                       <a href="DetailCar.aspx?CarId=<%# Eval("CarId") %>"></a>
                       <img src='<%# Eval("Picture","Images/{0}") %>' width="100" height="80"/>
                   </td>

                   <td>
                     <%--  <asp:Button ID="btnDel" runat="server" Text="删除" />
                       <asp:Button ID="btnEdit" runat="server" Text="编辑" />--%>
                        <asp:Button ID="btnDel" runat="server" Text="删除" CommandName="del" CommandArgument='<%# Eval("CarId") %>' />
                       <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandName="edit" CommandArgument='<%# Eval("CarId") %>' />
                   </td>

               </tr>

           </AlternatingItemTemplate>

           <FooterTemplate>
               </table>
           </FooterTemplate>

       </asp:Repeater>

   </div>


</asp:Content>
