<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopDownloads.aspx.cs" Inherits="Deviant_Music.TopDownloads" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div>
         <h3>Top Downloads</h3>
            
            
            <hr />
           
          
                <asp:ListView ID="songList" runat="server" 
DataKeyNames="Id"
ItemType="Deviant_Music.Models.Song"   SelectMethod="GetSongs">
                
<LayoutTemplate>
            <div class="form-inline" ID="groupPlaceholderContainer"  runat="server"  >
                
                <div class="form-inline"  id="groupPlaceholder" runat="server"></div>
            </div>
        </LayoutTemplate>
   <GroupTemplate>
     
<div class="form-inline" id="itemPlaceholderContainer" runat="server">
<div class="form-inline"  id="itemPlaceholder" runat="server"></div>
</div>
</GroupTemplate> 
        <ItemTemplate >
 <div class="form-inline">         
<div class= "card" style="text-align:center; width:auto;height:auto">
                                  <a href="<%#: GetRouteUrl("SongByTitleRoute", new {songTitle = Item.SongUrl}) %>" target="_blank">
	<img class="picD" src="/Catalog/Song/<%#:Item.ImagePath%>"  style="text-align:center"/></a>
<div class="container-x" style="text-align: center">
<h5>
<b><%#:Item.ArtistName%> - <%#:Item.Title%></b></h5>
<p> 
<asp:Label runat="server" id="iprice" visible='<%#Eval("License").Equals("Paid")%>'>#<%#:Item.Price %></asp:Label>
  <asp:Label runat="server" id="ilicense" visible='<%#Eval("License").Equals("Free") %>'><%#:Item.License %></asp:Label>
<br /><span><%#:Item.DownloadCount %>-Downloads</span><br /></p></div></div>    </div>   </ItemTemplate>
       
        <EmptyDataTemplate>

        </EmptyDataTemplate>
</asp:ListView>
            
            <div class="container">
            <div class="datapager">
   
        <asp:DataPager ID="DataPager1" PageSize="6" PagedControlID="songList" runat="server">
           
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        </div>
    </div>    
      </div>
        </div>     
</asp:Content>
