<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMaterPage.Master" AutoEventWireup="true" CodeBehind="CarGirdView.aspx.cs" Inherits="CarSYS.CarGirdView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function checkAll(obj) {
            var checkboxs = document.getElementsByTagName("input");

            for (var i = 0; i < checkboxs.length; i++) {
                if (checkboxs[i].type=="checkbox") {
                    checkboxs[i].checked = obj.checked;
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>车型列表</h1>
    <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    <p><asp:Button ID="btnAll" runat="server" Text="删除多行" OnClick="btnAll_Click" /></p>
    <asp:GridView Width="98%" ID="gvCars" runat="server" AllowPaging="True" PageSize="5" HorizontalAlign="Center" AutoGenerateColumns="False" style="margin-left:3px" BackColor="White" BorderColor="#6666EF" OnPageIndexChanging="gvCars_PageIndexChanging" OnRowDataBound="gvCars_RowDataBound"  OnRowDeleting="gvCars_RowDeleting" DataKeyNames="CarId" OnRowEditing="gvCars_RowEditing" OnRowCancelingEdit="gvCars_RowCancelingEdit" OnRowUpdating="gvCars_RowUpdating">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="Checkbox1" type="checkbox" onchange="checkAll(this)" />
                    全选
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<input id="Checkbox2" type="checkbox" />--%>
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="车型名称">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CarName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="品牌名称">
                <EditItemTemplate>
                   <%-- <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:TextBox>--%>
                    <asp:DropDownList ID="ddrBrandName" DataSource='<%# bindBrands() %>' SelectedValue='<%#Bind("CarBrand.BrandId") %>'  DataValueField="BrandId" DataTextField="BrandName" runat="server"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="OfficilPrice" DataFormatString="{0:c}万" HeaderText="官方价格" />
            <asp:BoundField DataField="Click" HeaderText="点击量" ReadOnly="true" />
            <asp:TemplateField HeaderText="实物图">
                <EditItemTemplate>
                   <%-- <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Picture") %>'></asp:TextBox>--%>
                    <asp:FileUpload ID="fuPic" runat="server" Width="190"  />
                    <asp:HiddenField ID="hfPic" runat="server" Value='<%#Eval("Picture") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "~/Images/{0}") %>' Width="40" Height="50" />
                </ItemTemplate>
                <ControlStyle Height="40px" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="CarId" DataNavigateUrlFormatString="~/DetailCar.aspx?CarId={0}" HeaderText="详细" Text="详细" />
            
            <asp:CommandField ButtonType="Button" HeaderText="编辑" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
