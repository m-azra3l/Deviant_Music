<%@ Page Title="Search Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="Deviant_Music.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
    <h3>Search Result</h3>
    <hr />
   <div class="container">
       <div class="col-xs-12 col-md-6">
           <asp:Label runat="server" ID="searcherror" Visible="false" Font-Size="Medium" Text=""></asp:Label>
 <asp:ListView ID="searchList" runat="server" DataKeyNames="Id" ItemType="Deviant_Music.Models.Song" SelectMethod="GetSearch">                
<LayoutTemplate>
            <div class="row" ID="groupPlaceholderContainer"  runat="server" style="text-align:center" >                
                <div class="row" style="text-align:center" id="groupPlaceholder" runat="server"></div>
            </div>
        </LayoutTemplate>
   <GroupTemplate>     
<div class="row" style="text-align:center" id="itemPlaceholderContainer" runat="server">
<div class="row"  style="text-align:center" id="itemPlaceholder" runat="server"></div>
</div>
</GroupTemplate> 
          <ItemTemplate >
 <!-- First product box start here-->
                <div class="prod-info-main prod-wrap clearfix" style="width:auto">
                      <table>
                          <tr>
                           <td>
                            <div class="product-image">
                             <a href="<%#: GetRouteUrl("SongByTitleRoute", new {songTitle = Item.SongUrl}) %>" target="_blank"><img src="/Catalog/Song/<%#:Item.ImagePath%>" style="width:170px; height:170px" alt="<%#:Item.Title %>"></a>
                            </div>
                  </td>
                    <td>&nbsp;</td>  
                                                  <td>&nbsp;</td>  
    <td style="vertical-align: top; text-align:left;">
                  <div class="product-detail">
                               <h5 class="name"><b>
                                <%#:Item.ArtistName%> - <%#:Item.Title %>
                               </b><br /><br />
                                 <asp:Label runat="server" visible='<%#Eval("AlbumName").Equals("")?false:true %>'>Album: <%#:Item.AlbumName %><br /><br /></asp:Label>
                                <p><span>Genre: <%#:Item.GenreName %></span></p>
                        </h5>
                            <p class="price-container">
                             <asp:Label runat="server" id="Label1" visible='<%#Eval("License").Equals("Sponsored")%>'><%#:Item.License %></asp:Label>
<asp:Label runat="server" id="iprice" visible='<%#Eval("License").Equals("Paid")%>'>#<%#:Item.Price %></asp:Label>
  <asp:Label runat="server" id="ilicense" visible='<%#Eval("License").Equals("Free") %>'><%#:Item.License%></asp:Label>
                           </p>
   </div>
  <div class="description">
      <p><%#:Item.DownloadCount%>  Download(s)</p>
      <p>Click image to see more</p>
   </div>
  </td>
    </tr>
  </table>
</div>
<!-- end product --> </ItemTemplate>
        <EmptyDataTemplate>
        </EmptyDataTemplate>
</asp:ListView>
           <div class="datapager">
        <asp:DataPager ID="DataPager1" PageSize="10" PagedControlID="searchList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        </div>
</div>
   </div>
            </div>
       </div>
</asp:Content>
