<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" AutoEventWireup="true" CodeBehind="BrandDataGrid.aspx.cs" Inherits="CarSYS.Page.BrandPage.BrandDataGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .btnDelRows {
            height: 28px;
            width:82px;
            line-height:26px;
            
            background-color:#298cef;
            color:#fff;
            font-size:14px;
            text-align:center;
            border:0px;
            margin-left:20px;
            padding:5px;

        }
        #main01 {
            margin-top:10px;
        }

    </style>

    <script type="text/javascript">

        function checkAll(obj) {
            var allcheckbox = document.getElementsByTagName("input");
            for (var i = 0; i < allcheckbox.length; i++) {
                if (allcheckbox[i].type == "checkbox") {
                    allcheckbox[i].checked = obj.checked;
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header01" style="height: 32px; line-height: 42px; background-color:#FFFFFF;">
        <div id="tools">
            <asp:Button ID="btnDelRows" runat="server" Text="删除多行" class="btnDelRows" OnClick="btnDelRows_Click" /> 
        </div>
        
    </div>
    <div id="main01">
        <asp:GridView ID="gvBrand" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="BrandId" PageSize="8" HorizontalAlign="Center" Width="100%" OnPageIndexChanging="gvBrand_PageIndexChanging" OnRowDataBound="gvBrand_RowDataBound" OnRowDeleting="gvBrand_RowDeleting" OnRowCancelingEdit="gvBrand_RowCancelingEdit" OnRowEditing="gvBrand_RowEditing" OnRowUpdating="gvBrand_RowUpdating">
            <Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <input id="ckAll" type="checkbox" onclick="checkAll(this)" />
                        全选<br />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%--<input id="Itemck" type="checkbox" runat="server" />--%>
                        <asp:CheckBox ID="Itemck" runat="server" />
                        <br />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="编号">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBrandId" runat="server" Text='<%# Bind("BrandId") %>' ReadOnly="true"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("BrandId") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="品牌名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBrandName" Display="Static"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" HeaderText="编辑" ShowEditButton="True"></asp:CommandField>
                <asp:HyperLinkField DataNavigateUrlFields="BrandId" HeaderText="详细" Text="详细" DataNavigateUrlFormatString="BrandDetailsView.aspx?BrandId={0}"></asp:HyperLinkField>
            </Columns>
            <RowStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle" Height="36" />
        </asp:GridView>
    </div>

    <div id="footer01" style="height: 42px; line-height: 42px; background-color: aqua;">
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
