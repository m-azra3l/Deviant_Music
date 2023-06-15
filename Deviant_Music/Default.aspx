<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Deviant_Music._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container">
        <div>
         <h3>Fresh Off The Grill</h3>
            
            
            <hr />
           
          <div class="container">
                <asp:ListView ID="songList" runat="server" 
DataKeyNames="Id"
ItemType="Deviant_Music.Models.Song"   SelectMethod="GetSongs">
                
<LayoutTemplate>
            <div class="form-inline" ID="groupPlaceholderContainer"  runat="server" style="text-align:center" >
                
                <div class="form-inline" style="text-align:center" id="groupPlaceholder" runat="server"></div>
            </div>
        </LayoutTemplate>
   <GroupTemplate>
     
<div class="form-inline" style="text-align:center" id="itemPlaceholderContainer" runat="server">
<div class="form-inline"  style="text-align:center" id="itemPlaceholder" runat="server"></div>
</div>
</GroupTemplate> 
        <ItemTemplate >
 <div class="form-inline" style="text-align:center">        
<div class= "card" style="text-align:center; width:auto;height:auto">
                                  <a href="<%#: GetRouteUrl("SongByTitleRoute", new {songTitle = Item.SongUrl}) %>" target="_blank">
	<img class="picD" src="/Catalog/Song/<%#:Item.ImagePath%>"  /></a>
<div class="container-x" style="text-align: center">
<h5>
<b><span><%#:Item.ArtistName%> - <%#:Item.Title%></span></b></h5>
<p> 
    <asp:Label runat="server" id="Label1" visible='<%#Eval("License").Equals("Sponsored")%>'><%#:Item.License %></asp:Label>
<asp:Label runat="server" id="iprice" visible='<%#Eval("License").Equals("Paid")%>'>#<%#:Item.Price %></asp:Label>
  <asp:Label runat="server" id="ilicense" visible='<%#Eval("License").Equals("Free") %>'><%#:Item.License %></asp:Label>
</p></div></div> </div>   </ItemTemplate>
       
        <EmptyDataTemplate>
            <h4>No songs are available in this Genre. Want to be the first to place your song here? <a runat="server" href="~/Contact">Contact</a> us today.</h4>

        </EmptyDataTemplate>
</asp:ListView>
       </div>      
            <div class="container">
            <div class="datapager">
    
        <asp:DataPager ID="DataPager1" PageSize="9" PagedControlID="songList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
 
            </Fields>
        </asp:DataPager>
        </div>
    </div>    
      </div>
            
       </div>               
</asp:Content>
