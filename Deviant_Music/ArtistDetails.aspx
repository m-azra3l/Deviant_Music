<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="Deviant_Music.ArtistDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:FormView ID="artistDetail" runat="server" 
ItemType="Deviant_Music.Models.Artist" SelectMethod ="GetArtist" 
RenderOuterTable="false">
        
<ItemTemplate>



    <h3>Artiste Bio</h3>
    <hr />

      <!-- Default box -->
      <div class="container card-solid">
        <div class="card-body">
          <div class="row">
            <div class="col-12 col-sm-6">
              <h4 class="d-inline-block d-sm-none"><%#:Item.Name %></h4>
              <div class="col-12">
                <img src="/Catalog/Artist/<%#:Item.ImagePath %>" style="height:50%;width:100%" alt="<%#:Item.Name %>"/>         
               
              </div>
              
            </div>
            <div class="col-12 col-sm-6" style="margin-top:30px">
              <h4 class="my-3">Bio:</h4>
                
                <span><p><%#:Item.Bio %></p></span>
                <br />
                <span><a runat="server" href="~/Contact">Contact</a> us today for bookings and enquiries</span>
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
        <ItemTemplate >
            <div class="form-inline">
            <div class="card" style="text-align:center; width:auto;height:auto"><a href="<%#: GetRouteUrl("SongByTitleRoute", new {songTitle = Item.SongUrl}) %>" target="_blank"><img src="/Catalog/Song/<%#:Item.ImagePath%> " width="150" height="150"  /></a><br /><span><%#: Item.ArtistName %> - <%#:Item.Title%></span><br /><asp:Label runat="server" id="iprice" visible='<%#Eval("License").Equals("Paid")%>'>#<%#:Item.Price %></asp:Label>
  <asp:Label runat="server" id="ilicense" visible='<%#Eval("License").Equals("Free") %>'><%#:Item.License %></asp:Label>
<br /></div>
        </div>
                </ItemTemplate>
       
        <EmptyDataTemplate>
            <h4>No songs are available in this Genre. Want to be the first to place your song here? <a runat="server" href="~/Contact">Contact</a> us today.</h4>

        </EmptyDataTemplate>
</asp:ListView>
            <div class="datapager">
    
        <asp:DataPager ID="DataPager1" PageSize="3" PagedControlID="songList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        
    </div> 
    <hr />
    <h4>Albums</h4>
     <asp:ListView ID="albumList" runat="server" 
DataKeyNames="Id" GroupItemCount="1"
ItemType="Deviant_Music.Models.Album" SelectMethod="GetAlbums">
            
<LayoutTemplate>
            <ul class="productlist" ID="groupPlaceholderContainer"  runat="server">
                
                <div class="form-inline" id="groupPlaceholder" runat="server"></div>
            </ul>
        </LayoutTemplate>
   <GroupTemplate>
     
<ul id="itemPlaceholderContainer" runat="server">
<div class="form-inline" id="itemPlaceholder" runat="server"></div>
</ul>
</GroupTemplate> 
        <ItemTemplate >
            <div class="form-inline">
            <div class="card" style="text-align:center; width:auto;height:auto"><a href="<%#: GetRouteUrl("AlbumByTitleRoute", new {albumTitle = Item.AlbumUrl}) %>" target="_blank"><img  src="/Catalog/Album/<%#:Item.ImagePath%>"  width="150" height="150" /></a><br /><span><%#:Item.ArtistName %> - <%#:Item.Title%></span><br /><br /></div> 
        </div>
                </ItemTemplate>
       
        <EmptyDataTemplate>

        </EmptyDataTemplate>
</asp:ListView>
            <div class="datapager">
    
        <asp:DataPager ID="DataPager2" PageSize="3" PagedControlID="albumList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        
    </div>  

</asp:Content>
