<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" AutoEventWireup="true" CodeBehind="CarDetailsView.aspx.cs" Inherits="CarSYS.Page.Car.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">

   <%-- <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>--%>

    <asp:DetailsView ID="dtCars" runat="server" Height="400px" Width="600px" AutoGenerateRows="False" OnItemInserting="dtCars_ItemInserting" OnItemUpdating="dtCars_ItemUpdating" OnModeChanging="dtCars_ModeChanging" DataKeyNames="CarId">
        <Fields>
            <asp:TemplateField HeaderText="编号">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarId" ReadOnly="true" runat="server" Text='<%# Bind("CarId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CarId") %>'></asp:Label>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CarId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="车辆名称">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarName" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                     <asp:TextBox ID="txtAddCarName" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>
                     <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="请输入车辆名称" Text="*" ControlToValidate="txtAddCarName" Display="Dynamic" ></asp:CompareValidator>--%>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入车辆名称" Text="*" ControlToValidate="txtAddCarName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CarName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="品牌">
                <EditItemTemplate>
                  <%--  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:TextBox>--%>

                    <asp:DropDownList ID="ddlBrand" AutoPostBack="false" runat="server" Width="200" SelectedValue='<%#Eval("CarBrand.BrandId") %>' DataSource='<%#bindBrands() %>' DataTextField="BrandName" DataValueField="BrandId"></asp:DropDownList>

                </EditItemTemplate>
                <InsertItemTemplate>
                    <%--<asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlAddBrand" AutoPostBack="false" runat="server" Width="200"  DataSource='<%#bindBrands() %>' DataTextField="BrandName" DataValueField="BrandId"></asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="实物图">
                <EditItemTemplate>

                    <asp:FileUpload ID="fuPic" runat="server" />
                    <asp:HiddenField ID="hfPic" runat="server" Value='<%#Eval("Picture") %>' />

                </EditItemTemplate>
                <InsertItemTemplate>
                   <%-- <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Picture") %>'></asp:TextBox>--%>
                      <asp:FileUpload ID="fuAddPic" runat="server" />
                      <asp:HiddenField ID="hfAddPic" runat="server" Value='<%#Eval("Picture") %>' />
                      <%--<asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="请选择实物图" Text="*" ControlToValidate="fuAddPic"></asp:CompareValidator>--%>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请选择实物图"  Text="*" ControlToValidate="fuAddPic"></asp:RequiredFieldValidator>--%>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "~/Images/Car/{0}") %>' Height="200" Width="400" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="官方价格">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("OffcialPrice") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAddPrice" runat="server" Text='<%# Bind("OffcialPrice", "{0:c}万") %>'></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入价格" Text="*" ControlToValidate="txtAddPrice"></asp:RequiredFieldValidator>--%>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("OffcialPrice", "{0:c}万") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="点击量">
                <EditItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Click") %>'></asp:Label>
                </EditItemTemplate>
                <InsertItemTemplate>
                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("Click") %>'></asp:Label>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Click") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" HeaderText="编辑" ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>

</asp:Content>
