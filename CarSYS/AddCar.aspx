<%@ Page MasterPageFile="~/CarSYSMaterPage.Master" Title="增加车辆" Language="C#" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="CarSYS.AddCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table.add {
            width:450px;
            height:300px;
            border:1px solid black;
            border-collapse:collapse;
        }
        .add td {
            border:1px solid black;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div>
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
                    <asp:DropDownList ID="ddlBrand" runat="server" Width="180"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>实物图文件名：</td>
                <td>
                   <%-- <asp:TextBox ID="txtPicture" runat="server"></asp:TextBox>--%>

                    <asp:FileUpload ID="fuPic" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuPic" ErrorMessage="文件名必填" Text="*" Display="Dynamic"></asp:RequiredFieldValidator>

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
    </div>

</asp:Content>

