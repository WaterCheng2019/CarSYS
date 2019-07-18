<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMaterPage.Master" AutoEventWireup="true" CodeBehind="DetailCar.aspx.cs" Inherits="CarSYS.DetailCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--一次仅显示数据源的单条记录，支持增删改，用于显示详情信息--%>
    <asp:DetailsView ID="dvCars" runat="server" Height="80px" Width="400px" AutoGenerateRows="False" DataKeyNames="CarId" OnItemInserting="dvCars_ItemInserting" OnItemUpdating="dvCars_ItemUpdating" OnModeChanging="dvCars_ModeChanging">
        <Fields>
            <asp:TemplateField HeaderText="车辆编号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CarId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CarId") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CarId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="车型名称">
                <EditItemTemplate>
                   <%-- <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>--%>
                    <asp:TextBox ID="txtCarName" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                   <%-- <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>--%>
                    <asp:TextBox ID="txtAddCarName" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>
                 <%--   <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="车型名称必填" Text="*" ControlToValidate="txtAddCarName"></asp:RangeValidator>--%>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CarName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="品牌名称">
                <EditItemTemplate>
                    <%--<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlEditBrand" runat="server" SelectedValue='<%#Bind("CarBrand.BrandId") %>' DataSource='<%#bindBrands() %>' DataValueField="BrandId" DataTextField="BrandName" ></asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                   <%-- <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlInsertBrand" runat="server" DataSource='<%#bindBrands() %>' DataValueField="BrandId" DataTextField="BrandName" ></asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="实物图">
                <EditItemTemplate>
                    <%--<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Picture") %>'></asp:TextBox>--%>
                     <asp:FileUpload ID="fulPic" runat="server" Width="190" Height="30" />
                     <asp:HiddenField ID="hflPic" runat="server" Value='<%#Eval("Picture") %>' />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <%--<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Picture") %>'></asp:TextBox>--%>
                     <asp:FileUpload ID="fulAddPic" runat="server" Width="190" Height="30" />
                     <asp:HiddenField ID="hflAddPic" runat="server" Value='<%#Eval("Picture") %>' />
                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="实物图必选" Text="*" ControlToValidate="fulAddPic"></asp:CompareValidator>--%>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "~/Images/{0}") %>' Height="100" Width="120" />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="官方价格">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("OfficilPrice") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAddPrice" runat="server" Text='<%# Bind("OfficilPrice", "{0:c}万") %>'></asp:TextBox>
                   <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="官方价格必填" Text="*" ControlToValidate="txtAddPrice"></asp:CompareValidator>--%>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("OfficilPrice", "{0:c}万") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="点击量">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Click") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Click") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Click") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowInsertButton="True" CancelText="取消" EditText="编辑" UpdateText="更新" InsertText="增加" NewText="添加" />
        </Fields>
    </asp:DetailsView>

</asp:Content>
