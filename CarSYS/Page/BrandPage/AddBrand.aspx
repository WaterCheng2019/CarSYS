<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="CarSYS.Page.BrandPage.AddBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        #AddBrand {
           
            margin-left:40px;
            /*background-color:#000000;*/
        }

        #AddBrand table{
            width:500px;
            height:300px;
            border:1px solid #ccc;
            padding:20px;
            border-collapse:collapse;
        }
            #AddBrand table caption{
                border:1px solid #ccc;
                border-bottom:0px;
                padding:10px;
                background-color:#ccc;
                font-size:18px;
                font-family:'微软雅黑';
                letter-spacing:14px;
            }
            #AddBrand table tr{
                height:38px;
            }
            #AddBrand table td {
                border:1px solid #ccc;
                text-align:center;
            }
            #AddBrand  table  .txt {
                margin-left:20px;
            }
            #AddBrand table .inputTxt {
                width:258px;
                height:25px;
            }
        .center {
            text-align:center;
        }
        .btn {
            height:32px;
            width:82px;
            background-color:#298cef;
            color:#fff;
            font-size:14px;
            line-height:30px;
            border:0px;
        }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">


    <div id="AddBrand">
        <table>
            <caption>增加品牌</caption>
            <tr>
                <td class="txt">品牌名称:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" class="inputTxt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="<spand style='color:red'>*<spand>" ErrorMessage="请输入品牌名称" ControlToValidate="txtName" Display="Static"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="增加" class="btn" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="center">
                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
