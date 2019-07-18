<%@ Page MasterPageFile="~/CarSYSMaterPage.Master" Title="ddsa" Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="CarSYS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table.add {
            width:400px;
            border:1px solid black;
            border-collapse:collapse;
            height:200px;
        }
            table.add td {
                border:1px solid black;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="add">

            <tr>
                <td>车型名称：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>品牌：</td>
                <td>
                    <asp:DropDownList ID="ddlBrand" runat="server"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>实物图文件名：</td>
                <td>
                    <asp:TextBox ID="txtPicture" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>官方价：</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnAdd" runat="server" Text="增加" OnClick="btnAdd_Click" />。
                    <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>

        </table>
</asp:Content>


