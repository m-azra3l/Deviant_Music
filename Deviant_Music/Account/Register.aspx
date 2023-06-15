<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Deviant_Music.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-default">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <hr />
    <div class="form-vertical" >
        <h4>Create a new account</h4>
        <hr />
     
         <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox style="text-align:center" runat="server" ID="Username" CssClass="form-control"  placeholder="Username" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                 CssClass="text-default" ErrorMessage="This field is required." />
            </div>
        </div>
       <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox style="text-align:center" runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                 CssClass="text-default" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group" >
            <div class="col-md-10">
                <asp:TextBox style="text-align:center" runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                     ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group" >
            
            <div class="col-md-10">
                <asp:TextBox style="text-align:center" runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control"  placeholder="Confirm Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="This field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                     Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
         <div class="form-group">
                        <div class="col-md-10" >
                            <div class="checkbox">
                                <asp:CheckBox  Checked="false" AutoPostBack="false" runat="server" ID="Termschk"/>
                                <asp:label runat="server" AsociatedControlID="Termschk">I have read and accepted the<br /><a href="#" runat="server">Terms of Use and Services</a><br /> I have read and acknowledged the<br /><a href="#" runat="server">Legal Disclaimer</a></asp:label>
                            </div>
                        </div>
                    </div>
         
        <div class="form-group">
            <div class="col-md-10">
                <asp:Button runat="server" ID="button1" Enabled="false" OnClick="CreateUser_Click" CausesValidation="true" Text="Register" CssClass="btn btn-default" />
                <asp:Label runat="server" AssociatedControlID="button1"> or <a href="~/Account/Login" runat="server">Sign In</a></asp:Label>
                

            </div>
        </div>
    </div>
    
    <script >
        $(function () {
            var $btn = $(":submit[id$=button1]");
            var $chk = $(":input:CheckBox[id$=Termschk]");
            checkChecked($chk);
            $chk.click(function()
            {
                checkChecked($chk);
            }
            );
            function checkChecked(chkBox) {
                if ($chk.is(':checked')) {
                    $btn.removeAttr('disabled');
                }
                else {
                    $btn.attr('disabled', 'disabled')
                }
            }
        });
    </script>
</asp:Content>
