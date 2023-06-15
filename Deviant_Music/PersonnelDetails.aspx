<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonnelDetails.aspx.cs" Inherits="Deviant_Music.PersonnelDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:FormView ID="personnelDetail" runat="server" 
ItemType="Deviant_Music.Models.Personnel" SelectMethod ="GetPersonnel" 
RenderOuterTable="false">
        
<ItemTemplate>



    <h3>Personnel Bio</h3>
    <hr />

      <!-- Default box -->
      <div class="contaner card-solid">
        <div class="card-body">
          <div class="row">
            <div class="col-12 col-sm-6">
              <h4 class="d-inline-block d-sm-none"><%#:Item.Name %></h4>
              <div class="col-12">
                <img src="/Catalog/Personnel/<%#:Item.ImagePath %>" style="height:50%;width:100%" alt="<%#:Item.Name %>"/>         
               
              </div>
              
            </div>
            <div class="col-12 col-sm-6" style="margin-top:30px">
              <h4 class="my-3">Bio:</h4>
                <span>Designation: <%#:Item.Designation %></span>
                <br />
                <span><p><%#:Item.Bio %></p></span>
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
