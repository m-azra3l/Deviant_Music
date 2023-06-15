<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnnouncementDetails.aspx.cs" Inherits="Deviant_Music.AnnouncementDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="announcementDetail" runat="server" 
ItemType="Deviant_Music.Models.Announcement" SelectMethod ="GetAnn" 
RenderOuterTable="false">
        
<ItemTemplate>



    <h3>Announcement Details</h3>
    <hr />

      <!-- Default box -->
      <div class="contaner card-solid">
        <div class="card-body">
          <div class="row">
            <div class="col-12 col-sm-6">
              <h4 class="d-inline-block d-sm-none"><%#:Item.Title %></h4>
              <div class="col-12">
                <img src="/Catalog/Announcement/<%#:Item.ImagePath %>" style="height:50%;width:100%" alt="<%#:Item.Title %>"/>         
               
              </div>
              
            </div>
            <div class="col-12 col-sm-6" style="margin-top:30px">
               
                <span><p><%#:Item.Description %></p></span>
                <br />
              

               
            </div>
                        
        
        </div>
        <!-- /.card-body -->
      </div>
    </div>
      <!-- /.card -->

    </ItemTemplate>
        </asp:FormView>
</asp:Content>
