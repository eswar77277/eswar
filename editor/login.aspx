<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Bulk Email System</title>
    <link href="css/login-styles.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
</head>

<body>

    <div class="container">
        
        <div id="login-row" class="row justify-content-center align-items-center">
            <div class="col-md-12" style="margin-top:40px; margin-left: 625px;">
                <img src="http://103.73.221.75:81/images/logopty.png" title="" />
            </div>

            <div id="login-column" class="col-md-6" style="margin-top:-135px;">
                
                <div class="box">
                    
                    <div class="shape1"></div>
                    <div class="shape2"></div>
                    <div class="shape3"></div>
                    <div class="shape4"></div>
                    <div class="shape5"></div>
                    <div class="shape6"></div>
                    <div class="shape7">

                    </div>
                    <div class="float">
                        
                        <form class="form" runat="server">
                            <div class="form-group">
                                <label for="username" class="text-white"><i class="fa fa-user"></i> Username:</label><br>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-white"><i class="fa fa-lock"></i> Password:</label><br>
                                <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <input type="submit" id="btnsubmit" runat="server" onserverclick="btnLogin_Click" name="submit" class="btn btn-info btn-md" value="submit" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>