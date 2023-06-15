<%@ Page Title="Terms of Use and Services" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Terms.aspx.cs" Inherits="Deviant_Music.Terms" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div><h5>Please make use of the <a href="HelpFAQ.aspx" runat="server">Help and FAQ</a> page for any questions or complaints</></h5></div>
    <hr />
   
    <div class="panel-group" id="accordion" style="padding-bottom:15px">
     <section class="panel panel-default" runat="server" id="TandC">
         <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#termC">
        Terms of Use and Services</a>
      </h4>
    </div>
    <div id="termC" class="panel-collapse collapse in">
      <div class="panel-body">Lorem ipsum dolor sit amet, consectetur adipisicing elit,
      sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
      minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
      commodo consequat.
        </div>
    </div>
       </section>
    <section class="panel panel-default" runat="server" id="legalD">
         <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#legalc">
        Legal Disclaimer Dmca digital millennium copyright act</a>
      </h4>
    </div>
    <div id="legalc" class="panel-collapse collapse">
      <div class="panel-body">Lorem ipsum dolor sit amet, consectetur adipisicing elit,
      sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
      minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
      commodo consequat.</div>
    </div>
    </section>
    </div>
        
</asp:Content>
    