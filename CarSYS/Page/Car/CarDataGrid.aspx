<%@ Page Title="" Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" AutoEventWireup="true" CodeBehind="CarDataGrid.aspx.cs" Inherits="CarSYS.Page.Car.CarList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function CheckAll(obj)
        {
            var checkboxs = document.getElementsByTagName("input");
            for (var i = 0; i < checkboxs.length; i++) {
                if (checkboxs[i].type == "checkbox") {
                    checkboxs[i].checked = obj.checked;
                }
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <h3 style="text-align:center">车辆列表</h3>
    <p>
          <asp:Button ID="btnDelects" runat="server" Text="删除多行" OnClick="btnDelects_Click" /> 
    </p>
     <div>
        <asp:gridview ID="dgCars" runat="server" AllowPaging="True" AutoGenerateColumns="False" Height="200px" OnPageIndexChanging="dgCars_PageIndexChanging" PageIndex="1" PageSize="5" Width="98%" BackColor="White" BorderColor="#6666FF" BorderWidth="2px" Style="margin-left:10px; margin-top: 0px;" OnRowDataBound="dgCars_RowDataBound" DataKeyNames="CarId" OnRowDeleting="dgCars_RowDeleting"  OnRowCancelingEdit="dgCars_RowCancelingEdit" OnRowUpdating="dgCars_RowUpdating" OnRowEditing="dgCars_RowEditing">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                       <%-- <asp:CheckBox ID="CheckBox1" runat="server" onclick="CheckAll(this)" />--%>
                        <input id="Checkbox1" type="checkbox" onclick="CheckAll(this)" />
                        全选
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="车型名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCarName" runat="server" Text='<%# Bind("CarName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CarName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="品牌名称">
                    <EditItemTemplate>
                       <%-- <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlBrand" runat="server" Width="200" SelectedValue='<%# Eval("CarBrand.BrandId") %>' DataSource='<%#bindBrands() %>' DataValueField="BrandId"  DataTextField="BrandName"   ></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CarBrand.BrandName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="官方价格">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("OffcialPrice") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("OffcialPrice", "{0:C}万") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="实物图">
                    <EditItemTemplate>
                        <%--<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Picture") %>'></asp:TextBox>--%>

                        <asp:FileUpload  ID="fuPic" runat="server" Width="190" />
                        <asp:HiddenField ID="hfPic" runat="server" Value='<%#Eval("Picture") %>' />

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "~/Images/Car/{0}") %>' Height="100px" Width="180px" />
                    </ItemTemplate>
                  <%--  <ControlStyle Height="100px" Width="180px" />--%>
                </asp:TemplateField>
                <asp:BoundField DataField="Click" HeaderText="点击量" ReadOnly="true" />

                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:HyperLinkField DataNavigateUrlFields="CarId" DataNavigateUrlFormatString="~/Page/Car/Details.aspx?CarId={0}" HeaderText="详情" Text="详情" />
                <asp:CommandField ButtonType="Button" HeaderText="编辑" ShowEditButton="True" />
            </Columns>
            <PagerStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle"  BackColor="#CCFF33" />
        </asp:gridview>
    </div>


</asp:Content>
