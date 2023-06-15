<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagedArtists.aspx.cs" Inherits="Deviant_Music.ManagedArtists" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <section>
        <div>
         <h3> Managed Artistes</h3>
            <hr />
           

            <asp:ListView ID="artistList" runat="server" 
DataKeyNames="Id" GroupItemCount="1"
ItemType="Deviant_Music.Models.Artist" SelectMethod="GetArtists">
<EmptyDataTemplate>
</EmptyDataTemplate>
<EmptyItemTemplate>
<td/>
</EmptyItemTemplate>
<GroupTemplate>
        

<div class="form-inline" id="itemPlaceholderContainer" runat="server">
<div class="form-inline" id="itemPlaceholder" runat="server"></div>
</div>
</GroupTemplate>
<ItemTemplate>
    <div class="form-inline">
<div class="card" style="text-align:center; width:auto;height:auto">
<a href="<%#: GetRouteUrl("ArtistByNameRoute", new {artistName = Item.ArtistUrl}) %>" target="_blank">	<img class="picD" src="/Catalog/Artist/<%#:Item.ImagePath%>"  /></a>
<div class="container-x" style="text-align: center">
<h5>
<b><span><%#:Item.Name%></span></b></h5>
    </div>
        </div>
    </div>
</ItemTemplate>

<LayoutTemplate>
<div class="form-inline" ID="groupPlaceholderContainer"  runat="server" >
                
                <div class="form-inline"  id="groupPlaceholder" runat="server"></div>
            </div>
</LayoutTemplate>
</asp:ListView>
            <div class="container">
            <div class="datapager">
    
        <asp:DataPager ID="DataPager1" PageSize="9" PagedControlID="artistList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        </div>
    </div>    
             <h4>Do you want to be represented by Deviant Music to move your career up? <a runat="server" href="~/Contact">Contact</a> us today.</h4>

            </div>
         </section>
</asp:Content>
