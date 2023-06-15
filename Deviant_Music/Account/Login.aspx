<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Deviant_Music.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to sign in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <div class="col-md-10">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control"  placeholder="Username" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                CssClass="text-danger" ErrorMessage="This field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10">
              <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="This field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Sign In" CssClass="btn btn-default" />
                            &nbsp;&nbsp;
<asp:Button runat="server" ID="ResendConfirm" 
OnClick="SendEmailConfirmationToken" Text="Resend Confirmation" Visible="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                  
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>
