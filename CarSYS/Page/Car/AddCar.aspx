<%@ Page Language="C#" MasterPageFile="~/CarSYSMasterPage.Master" Title="增加车辆" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="CarSYS.Page.Car.AddCar" %>
<asp:Content ID="Content01" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">

        #addCar {
            margin-left:82px;
        }
        #addCar table {
            border:1px solid #000000;
            width:500px;
            padding:22px;
        }

            #addCar caption {
                border:1px solid #000000;
                border-bottom:0px;
                background-color:#ccc;
                padding:4px;
                height:32px;
                line-height:32px;
                font-size:18px;
                font-family:'微软雅黑';
                letter-spacing:8px;
            }

        #addCar table tr{
            height:40px;
        }
 

            #addCar table tr .txt {
                text-align:right;
            }
            #addCar table .inputTxt {
                width:258px;
                height:25px;
            }
        #addCar .center {
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
    
    <script type="text/javascript">
       function check() {
           //根据服务器端ID获取客户端ID
           var txtNameID = "<%=txtName.ClientID%>"
           var ddlBrandID = "<%=ddlBrand.ClientID%>";
           var fuPicID = "<%=fuPic.ClientID%>"
           var txtPriceID = "<%=txtPrice.ClientID%>";
 

           //根据ID，获取document节点  
           var txtName = document.getElementById(txtNameID).value;
           var ddlBrand = document.getElementById(ddlBrandID).value;
           var fuPic = document.getElementById(fuPicID).value;
           var txtPrice = document.getElementById(txtPriceID).value;
  

           if (ddlBrand != -1 && txtName != "" && fuPic != "" && txtPrice != "" ) {
               return true; 
           }
           else {
               var lblInfoID = "<%=lblInfo.ClientID%>";
               document.getElementById(lblInfoID).innerHTML = "<spand style='color:red;'>请输入完整信息<spand>";
               return false;
           }
         }
    </script>

    

</asp:Content>
<asp:Content ID="Content02" ContentPlaceHolderID="Contents" runat="server">

    <div id="addCar">

        <table>
            <caption>增加车辆</caption>
            <tr>
                <td class="txt">
                    <asp:Label ID="Label1" runat="server" Text="名称：" AssociatedControlID="txtName"  ></asp:Label>
                </td>
                <td>
                    <asp:TextBox  ID="txtName" class="inputTxt"  runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="txt">
                    <asp:Label  ID="Label2"  runat="server" Text="品牌：" AssociatedControlID="ddlBrand" ></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBrand" class="inputTxt"  runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="txt">
                    <asp:Label ID="Label3" runat="server" Text="实物图：" AssociatedControlID="fuPic" ></asp:Label>
                </td>
                <td>
                     <asp:FileUpload ID="fuPic" runat="server" />
                    <asp:HiddenField ID="hfPic" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="txt">
                    <asp:Label ID="Label4" runat="server" Text="官方价格：" AssociatedControlID="txtPrice" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" class="inputTxt"  runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2" class="center">
                    <asp:Button ID="btnSave" class="btn" runat="server" Text="增加" OnClick="btnSave_Click" />
                </td>
            </tr>
              <tr>
                <td colspan="2"  class="center">
                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>

    </div>

</asp:Content>