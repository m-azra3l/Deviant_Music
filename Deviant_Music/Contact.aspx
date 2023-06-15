<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Deviant_Music.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %>.</h3>
    <h4>Your contact page.</h4>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
     <!-- Main content -->
    <section class="form" name="helpform" runat="server">
        <div class="form-inline">
        
            <h4 class="d-inline-block d-sm-none">Contact Form</h4>
                     <p >
                   Please make your request clear and well detailed.<br>
                </p>
      </div><!-- /.container-fluid -->
      <!-- Default box -->
      <div class="form">
              <div class="form-group">
                  <asp:Label runat="server">Name/Username:</asp:Label>
                  <asp:RequiredFieldValidator runat="server" ID="inputName1" ErrorMessage="*Required" ControlToValidate="inputName" />
              <asp:Textbox id="inputName" runat="server" class="form-control" placeholder="Full Name/username"></asp:Textbox>
           </div>
          <div class="form-group">
               <asp:Label runat="server">Email:</asp:Label>
                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="*Required" ControlToValidate="inputEmail" />
              <asp:Textbox runat="server" TextMode="email" id="inputEmail" class="form-control" placeholder="Email"></asp:Textbox>
        </div>
          <div class="form-group">
               <asp:Label runat="server">Subject:</asp:Label>
                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ErrorMessage="*Required" ControlToValidate="inputSubject" />
              <asp:Textbox id="inputSubject" runat="server" class="form-control" placeholder="Subject"></asp:Textbox>
         </div>
            <div class="form-group">
                 <asp:Label runat="server">Message:</asp:Label>
                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ErrorMessage="*Required" ControlToValidate="inputMessage" />
              <asp:Textbox id="inputMessage" runat="server" class="form-control" TextMode="MultiLine" style="height:200px" placeholder="Message"></asp:Textbox>
         </div>
          <div class="form-group">
              <asp:FileUpload ID="upload1" CssClass="form-control" AllowMultiple="true" runat="server" />
          </div>
                   <asp:Button ID="request" runat="server" Visible="true" class="btn btn-primary" Text="Send Request" OnClick="request_Click" CausesValidation="false"/>
          <asp:Label ID="respsuccess" runat="server" Text="" ForeColor="Green" />
      </div>
    </section>
    <!-- /.content -->
</asp:Content>
