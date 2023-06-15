<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="Deviant_Music.AlbumDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="songDetail" runat="server" 
ItemType="Deviant_Music.Models.Album" SelectMethod ="GetAlbum" 
RenderOuterTable="false">
        
<ItemTemplate>



    <h3>Album Details</h3>
    <hr />
      <!-- Default box -->
      <div class="container card-solid">
        <div class="card-body">
          <div class="row">
            <div class="col-12 col-sm-6">
              <h4 class="d-inline-block d-sm-none"><%#:Item.Title %></h4>
              <div class="col-12">
                <img src="/Catalog/Album/<%#:Item.ImagePath %>" style="height:50%;width:100%" alt="<%#:Item.Title %>"/>         
               
              </div>
              
            </div>
            <div class="col-12 col-sm-6" style="margin-top:30px">
              <h4 class="my-3">Decription:</h4>
                <span>Artiste: <%#:Item.ArtistName %></span> 
                <br />
                <span>Genre: <%#:Item.GenreName %></span> 
                <br />
                <span>Release Date: <%#:Item.ReleaseDate %></span> 
                <br />
                <span>Upload Date: <%#:Item.UploadDate %></span>
                <br />
                <a href="<%#:Item.AudiomackUrl%>"><span><b>Preview on Audiomack</span></a>
                <br />
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
    <hr />
      
                                   <h4>Songs</h4>
            <asp:ListView ID="songList" runat="server" 
DataKeyNames="Id"
ItemType="Deviant_Music.Models.Song"   SelectMethod="GetSongs">
                
<LayoutTemplate>
            <ul class="productlist" ID="groupPlaceholderContainer"  runat="server" >
                
                <div class="form-inline" id="groupPlaceholder" runat="server"></div>
            </ul>
        </LayoutTemplate>
   <GroupTemplate>
     
<ul id="itemPlaceholderContainer" runat="server">
<div class="form-inline" id="itemPlaceholder" runat="server"></div>
</ul>
</GroupTemplate> 
        <ItemTemplate ><div class="form-inline">
            <div class="card" style="text-align:center; width:auto;height:auto"><a href="<%#: GetRouteUrl("SongByTitleRoute", new {songTitle = Item.SongUrl}) %>" target="_blank"><img src="/Catalog/Song/<%#:Item.ImagePath%> " width="150" height="150"  /></a><br /><span><%#: Item.ArtistName %> - <%#:Item.Title%></span><br /><asp:Label runat="server" id="iprice" visible='<%#Eval("License").Equals("Paid")%>'>#<%#:Item.Price %></asp:Label>
  <asp:Label runat="server" id="ilicense" visible='<%#Eval("License").Equals("Free") %>'><%#:Item.License %></asp:Label>
<br /></div>
        </div></ItemTemplate>
       
        <EmptyDataTemplate>

        </EmptyDataTemplate>
</asp:ListView>
            <div class="datapager">
    
        <asp:DataPager ID="DataPager1" PageSize="3" PagedControlID="songList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        
    </div> 

         
</asp:Content>
