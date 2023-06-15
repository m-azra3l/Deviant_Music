<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DMPersonnel.aspx.cs" Inherits="Deviant_Music.DMPersonnel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <section>
        <div>
         <h3> Deviant Music Personnels</h3>
            <hr />
           

            <asp:ListView ID="personnelList" runat="server" 
DataKeyNames="Id" GroupItemCount="1"
ItemType="Deviant_Music.Models.Personnel" SelectMethod="GetPersonnels">
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
<a href="<%#: GetRouteUrl("PersonnelByNameRoute", new {personnelName = Item.PersonnelUrl}) %>" target="_blank">	<img class="picD" src="/Catalog/Personnel/<%#:Item.ImagePath%>"  /></a>
<div class="container-x" style="text-align: center">
<h5><b><%#:Item.Name%></b></h5>
    <p><span><%#:Item.Designation %></span></p>
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
    
        <asp:DataPager ID="DataPager1" PageSize="9" PagedControlID="personnelList" runat="server">
            <Fields>
               <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="numeric-button" CurrentPageLabelCssClass="current-page" NextPreviousButtonCssClass="next-button" /> <asp:NextPreviousPagerField NextPageText="Next" PreviousPageText="Prev" ButtonCssClass="prevnext" />  
            </Fields>
        </asp:DataPager>
        </div>
            </div>
            </div>
         </section>
</asp:Content>
