<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumList.aspx.cs" Inherits="Deviant_Music.AlbumList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
        <div>
         <h3>Albums</h3>
            
            
            <hr />
        <asp:ListView ID="albumList" runat="server" 
DataKeyNames="Id" GroupItemCount="1"
ItemType="Deviant_Music.Models.Album" SelectMethod="GetAlbums">
            
<LayoutTemplate>
            <div class="form-inline" ID="groupPlaceholderContainer"  runat="server">
                
                <div class="row" id="groupPlaceholder" runat="server"></div>
            </div>
        </LayoutTemplate>
   <GroupTemplate>
     
<div class="form-inline" id="itemPlaceholderContainer" runat="server">
<div class="form-inline" id="itemPlaceholder" runat="server"></div>
</div>
</GroupTemplate> 
        <ItemTemplate >
            <div class="form-inline">
           <div class= "card" style="text-align:center; width:auto;height:auto"><a href="<%#: GetRouteUrl("AlbumByTitleRoute", new {albumTitle = Eval("AlbumUrl")}) %>"><img class="picD" src="/Catalog/Album/<%#Item.ImagePath%>" /></a><br /><h5><b><%#:Item.ArtistName %> - <%#:Item.Title%></b></h5><br /><br /></div> 
        </div>
                </ItemTemplate>
       
        <EmptyDataTemplate>

        </EmptyDataTemplate>
</asp:ListView>
            <div class="datapager">
    
        <asp:DataPager ID="DataPager2" PageSize="9" PagedControlID="albumList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        
    </div>  
        </div>
    </div>
</asp:Content>
