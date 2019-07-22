<%@ Page Language="C#" Title="品牌详情信息展示" MasterPageFile="~/CarSYSMasterPage.Master" AutoEventWireup="true" CodeBehind="BrandDetailsView.aspx.cs" Inherits="CarSYS.Page.BrandPage.DetailsView" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="Contents" runat="server">

    <div style="height: 32px;"></div>

    <div style="margin:5px;">
        <asp:DetailsView ID="dvBrand" runat="server" Height="70px" Width="400px" AutoGenerateRows="False" DataKeyNames="BrandId" OnModeChanging="dvBrand_ModeChanging" OnItemInserting="dvBrand_ItemInserting" OnItemUpdating="dvBrand_ItemUpdating">
            <Fields>
                <asp:TemplateField HeaderText="编号">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBrandId" ReadOnly="true" runat="server" Text='<%# Bind("BrandId") %>'></asp:TextBox>

                    </EditItemTemplate>
                    <InsertItemTemplate>
                       <%-- <asp:TextBox ID="txtAddBrandId" runat="server" Text='<%# Bind("BrandId") %>'></asp:TextBox>--%>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("BrandId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="品牌名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txtAddBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtAddBrandName"></asp:RequiredFieldValidator>--%>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowInsertButton="True"  />
            </Fields>
            <RowStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle"  />
        </asp:DetailsView>
    </div>


    <div style="height: 32px;">
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

