<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarSYS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        table {
            width:400px;
            height:200px;
            margin:0 auto;
            margin-top:280px;
            border:1px solid black;
        }
        #login {
            background-color:none;
        }
    </style>
</head>
<body onkeydown="keyLogin()">
    <form id="form1" runat="server">
    <div id="login">
        <table>
            <tr>
                <td colspan="2" style="text-align:center;background-color:#ccc;font-size:18px;font-family:'微软雅黑'">登录</td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPwd"  Display="Dynamic" ></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align:center;">
                    <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click"   />
                    <asp:CheckBox ID="ckSave" runat="server" />是否保存登录信息
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label ID="lblInfo" runat="server" Text="" ></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <%--点击Enter键登录--%>
    <script type="text/javascript">

        function keyLogin() {

            if (event.keyCode==13) {
                var toClick = document.getElementById("btnLogin");
                toClick.click();
            }
        }

    </script>

</body>
</html>
