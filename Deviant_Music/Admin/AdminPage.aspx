<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Deviant_Music.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="container">
        
    <h4 runat="server" id="iadmin1" visible="false" style="text-align:center"><b>Administrator: Level1</b></h4>
         <h4 runat="server" id="iadmin2" visible="false" style="text-align:center"><b>Administrator: Level2</b></h4>
    <h4 runat="server" id="superADMIN" visible="false" style="text-align:center"><b>SuperAdministrator</b></h4>
          <div class="alert-dismissable alert-success" style="text-align:center" runat="server" id="alertsuccess">

         </div>
         <div class="alert-dismissable alert-danger" style="text-align:center" runat="server" id="alertfail">

         </div>
        <hr />
    <div class="panel-group" id="accordion">
  <div class="panel panel-default" id="ADBs" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iADsBs">
        ADsBs</a>
      </h4>
    </div>
    <div id="iADsBs" class="panel-collapse collapse">
      <div class="panel-body">
          <div class="container" style="margin-top:15px">
              <div class="form-group">
                                    <asp:Label ID="Label1" runat="server">AdsBs Databinder:</asp:Label>
                                    <asp:DropDownList ID="ABdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.AdsB" SelectMethod="GetAdsBs" CssClass="form-control" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
                                    </div>
              <div class="form-group">
                                              <asp:TextBox ID="adBsearch" runat="server" class="form-control" placeholder="Search By Title"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="adBsearch1" OnClick="adBsearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="ID:"></asp:Label>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Required" ControlToValidate="adBId" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                             <asp:TextBox ID="adBId" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                <div class="form-group">
                                     <asp:Label runat="server" Text="Title:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="ABtitle1" runat="server" Text="* Required" ControlToValidate="ABtitle" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="ABtitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                            

                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="NavigateURL:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="ABurl1" runat="server" Text="* Required" ControlToValidate="ABurl" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="ABurl" runat="server" class="form-control" placeholder="NavigateURL"></asp:TextBox>
                                 </div>
                                
                                <div class="form-group">
                                     <asp:Label runat="server" Text="AlternateText:"></asp:Label>
                            <asp:RequiredFieldValidator ID="ABdesc1" runat="server" Text="* Required" ControlToValidate="ABalte" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <asp:Textbox ID="ABalte" runat="server" class="form-control" placeholder="AlternatText"></asp:Textbox>
                                 </div>
                                 <div class="form-group">
                                     <asp:Label ID="ABImage2" runat="server">Image File:</asp:Label>
                                <asp:RequiredFieldValidator ID="ABImage1" runat="server" Text="* Required" ControlToValidate="ABImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                   <asp:FileUpload ID="ABImage" runat="server" class="form-control" placeholder="ImageUrl"></asp:FileUpload>
                                 </div>
    <asp:Button ID="ABcreate" class="btn btn-primary" OnClick="ABcreate_Click" runat="server" Text="Create"  CausesValidation="false"/>
    <asp:Button ID="ABupdate" class="btn btn-success" OnClick="ABupdate_Click" runat="server" Text="Update"  CausesValidation="false"/>
             <asp:Button ID="ABdelete" runat="server" OnClick="ABdelete_Click" Visible="false" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                <asp:Button ID="ABclear" runat="server" OnClick="ABclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                               
                            </div>
                         </div>
                       </div>
      
    </div>

        <div class="panel panel-default" id="ADPBs" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iADsPB">
        ADsPBs</a>
      </h4>
    </div>
    <div id="iADsPB" class="panel-collapse collapse">
      <div class="panel-body">
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                    <asp:Label ID="Label2" runat="server">AdsPBs Databinder:</asp:Label>
                                    <asp:DropDownList ID="APBdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.AdsPB" SelectMethod="GetAdsPBs" CssClass="form-control" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
                                    </div>
              <div class="form-group">
                                              <asp:TextBox ID="adPBsearch" runat="server" class="form-control" placeholder="Search By Title"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="adPBsearch1" OnClick="adPBsearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                              <asp:Label runat="server" Text="ID:"></asp:Label>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Required" ControlToValidate="adPBId" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                              <asp:TextBox ID="adPBId" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                 <div class="form-group">
                                <asp:Label runat="server" Text="Title:"></asp:Label>
                                <asp:RequiredFieldValidator ID="APBtitle1" runat="server" Text="* Required" ControlToValidate="APBtitle" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="APBtitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                            

                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="NavigateURL:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="APBurl1" runat="server" Text="* Required" ControlToValidate="APBurl" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="APBurl" runat="server" class="form-control" placeholder="NavigateURL"></asp:TextBox>
                                 </div>
                               
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="AlternateText:"></asp:Label>
                            <asp:RequiredFieldValidator ID="APBdesc1" runat="server" Text="* Required" ControlToValidate="APBalte" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <asp:Textbox ID="APBalte" runat="server" class="form-control" placeholder="AlternateText" ></asp:Textbox>
                                 </div>
                                 <div class="form-group">
                                    <asp:Label ID="APBImage2" runat="server">Image File:</asp:Label>
                            <asp:RequiredFieldValidator ID="APBImage1" runat="server" Text="* Required" ControlToValidate="APBImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:FileUpload ID="APBImage" runat="server" class="form-control" placeholder="ImageUrl"></asp:FileUpload>
                                 </div>
    <asp:Button ID="APBcreate" class="btn btn-primary" runat="server" OnClick="APBcreate_Click" Text="Create"  CausesValidation="false"/>
        <asp:Button ID="APBupdate" class="btn btn-success" OnClick="APBupdate_Click" runat="server" Text="Update"  CausesValidation="false"/>
                                                                <asp:Button ID="APBdelete" runat="server" OnClick="APBdelete_Click" Visible="false" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                                            <asp:Button ID="APBclear" runat="server" OnClick="APBclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                               
                            </div>
                         </div>
                       </div>
     
    </div>

         <div class="panel panel-default" id="ALBs" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iAlbum">
        Albums</a>
      </h4>
    </div>
    <div id="iAlbum" class="panel-collapse collapse">
      <div class="panel-body">
                            <div class="container" style="margin-top:15px">

                                <div class="form-group">
                                    <asp:Label runat="server" Text="Title:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="AlBtitle1" runat="server" Text="* Required" ControlToValidate="AlBtitle" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="AlBtitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="RouteUrl:"></asp:Label><br />
                                <asp:Label ID="Label10" runat="server">Input Title But Use Underscore(_) Instead Of Space Where Needed:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Required" ControlToValidate="albroute" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="albroute" runat="server" class="form-control" placeholder="AlbumRouteUrl"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="igenre2" runat="server">Genre Databinder:</asp:Label>
                                    <asp:RequiredFieldValidator ID="iAgenre1" runat="server" Text="* Required" ControlToValidate="iAgenre" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="iAgenre" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Genre" SelectMethod="GetAlbumGenre" class="form-control" placeholder="Select Genre"  DataTextField="Name" DataValueField="Id" >
                                    </asp:DropDownList>
                                </div>
                                 <div class="form-group">
                                     <asp:Label ID="iAartist1" runat="server">Artist Databinder:</asp:Label>
                                    <asp:DropDownList ID="iAartist" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Artist" SelectMethod="GetAlbumArtist" class="form-control" placeholder="Select Artist"  DataTextField="Name" DataValueField="Id" >
                                    </asp:DropDownList>
                                </div>
                            <div class="form-group">
                                <asp:Label runat="server" Text="Genre Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="iAGname1" runat="server" Text="* Required" ControlToValidate="iAGname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="iAGname" runat="server" class="form-control" placeholder="Genre Name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Artist Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="iAAname1" runat="server" Text="* Required" ControlToValidate="iAAname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="iAAname" runat="server" class="form-control" placeholder="Artist Name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Release Date:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="iARdate1" runat="server" Text="* Required. Format dd-mmm-yy" ControlToValidate="iARdate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    
                            <asp:TextBox ID="iARdate" runat="server" class="form-control" TextMode="Date" placeholder="Release Date. Format 01-Jan-21"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Upload Date:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="iAUdate1" runat="server" Text="* Required. Format dd-mmm-yy" ControlToValidate="iAUdate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="iAUdate" runat="server" class="form-control" TextMode="Date" placeholder="Upload Date. Format 01-Jan-21"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Stream Url:"></asp:Label>
                            <asp:TextBox ID="iAAmack" runat="server" class="form-control" placeholder="Stream URL"></asp:TextBox>
                                 </div>
                                
                                 <div class="form-group">
                                     <asp:Label ID="iAimage2" runat="server">Image File:</asp:Label>
                            <asp:RequiredFieldValidator ID="iAimage1" runat="server" Text="* Required" ControlToValidate="iAimage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:FileUpload ID="iAimage" runat="server" class="form-control" placeholder="Image Path"></asp:FileUpload>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Description:"></asp:Label>
                            <asp:RequiredFieldValidator ID="iAdesc1" runat="server" Text="* Required" ControlToValidate="iAdesc" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <textarea ID="iAdesc" runat="server" class="form-control" placeholder="Description" style="height:200px"></textarea>
                                 </div>
                                
    <asp:Button ID="iAcreate" class="btn btn-primary" runat="server" Text="Create" OnClick="iAcreate_Click"  CausesValidation="false"/>
                                   <asp:Button ID="iAclear" runat="server" OnClick="iAclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>

                                    <div class="container" style="margin-top:15px" id="iAdeletes" visible="false" runat="server">
                                    <div class="form-group">
                                    <asp:Label ID="Label8" runat="server">Databinder:</asp:Label>
                                    <asp:DropDownList ID="iAdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Album" SelectMethod="GetAlbum" CssClass="form-control" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="iAdelete" runat="server" OnClick="iAdelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
    

    </div>

        <div class="panel panel-default" id="ANNs" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iAnns">
        Announcements</a>
      </h4>
    </div>
    <div id="iAnns" class="panel-collapse collapse">
      <div class="panel-body">
                            <div class="container" style="margin-top:15px">
              <div class="form-group">
                                              <asp:TextBox ID="Ansearch" runat="server" class="form-control" placeholder="Search By Title"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="Ansearch1" OnClick="Ansearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="ID:"></asp:Label>
                                              <asp:TextBox Enabled="false" ID="AnID" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Title:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Antitle1" runat="server" Text="* Required" ControlToValidate="Antitle" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Antitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                                 </div>
       <div class="form-group">
           <asp:Label runat="server" Text="RouteUrl:"></asp:Label><br />
                                <asp:Label ID="Label11" runat="server">Input Title But Use Underscore(_) Instead Of Space Where Needed:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Required" ControlToValidate="Anroute" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Anroute" runat="server" class="form-control" placeholder="AnnoucementRouteUrl"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                     <asp:Label ID="AnImage2" runat="server">Image File:</asp:Label>
                                <asp:RequiredFieldValidator ID="AnImage1" runat="server" Text="* Required" ControlToValidate="AnImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                   <asp:FileUpload ID="AnImage" runat="server" class="form-control" placeholder="Image Path"></asp:FileUpload>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Description:"></asp:Label>
                            <asp:RequiredFieldValidator ID="Andesc1" runat="server" Text="* Required" ControlToValidate="Andesc" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <textarea ID="Andesc" runat="server" class="form-control" placeholder="Description" style="height:200px"></textarea>
                                 </div>
                                
    <asp:Button ID="Ancreate" class="btn btn-primary" runat="server" OnClick="Ancreate_Click" Text="Create"  CausesValidation="false"/>
                                 <asp:Button ID="Anupdate" class="btn btn-success" OnClick="Anupdate_Click" runat="server" Text="Update"  CausesValidation="false"/>

                                   <asp:Button ID="Anclear" runat="server" OnClick="Anclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                                <div class="container" style="margin-top:15px" runat="server" id="Antodelete" visible="true">
                                    <div class="form-group">
                                    <asp:Label ID="Label3" runat="server">Announcements Databinder:</asp:Label>
                                    <asp:DropDownList ID="Androp" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Announcement" SelectMethod="GetAnns" CssClass="form-control" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="Andelete" runat="server" OnClick="Andelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
      
    </div>
         
        <div class="panel panel-default" id="arts" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iArtists">
        Artists</a>
      </h4>
    </div>
    <div id="iArtists" class="panel-collapse collapse">
      <div class="panel-body">
                            <div class="container" style="margin-top:15px">
              <div class="form-group">
                                              <asp:TextBox ID="Artsearch" runat="server" class="form-control" placeholder="Search By Title"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="Artsearch1" OnClick="Artsearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="ID:"></asp:Label>
                                              <asp:TextBox Enabled="false" ID="ArtId" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Artname1" runat="server" Text="* Required" ControlToValidate="Artname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Artname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                                           </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="RouteUrl:"></asp:Label><br />
                                <asp:Label ID="Label12" runat="server">Input Name But Use Underscore(_) Instead Of Space Where Needed:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="* Required" ControlToValidate="Artroute" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Artroute" runat="server" class="form-control" placeholder="ArtistRouteUrl"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                     <asp:Label ID="ArtImage2" runat="server">Image File:</asp:Label>
                                <asp:RequiredFieldValidator ID="ArtImage1" runat="server" Text="* Required" ControlToValidate="ArtImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                   <asp:FileUpload ID="ArtImage" runat="server" class="form-control" placeholder="Image Path"></asp:FileUpload>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Bio:"></asp:Label>
                            <asp:RequiredFieldValidator ID="Artbio1" runat="server" Text="* Required" ControlToValidate="Artbio" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <textarea ID="Artbio" runat="server" class="form-control" placeholder="Bio" style="height:200px"></textarea>
                                 </div>
                                
    <asp:Button ID="Artcreate" class="btn btn-primary" runat="server" OnClick="Artcreate_Click" Text="Create"  CausesValidation="false"/>
                                    <asp:Button ID="Artupdate" class="btn btn-success" OnClick="Artupdate_Click" runat="server" Text="Update"  CausesValidation="false"/>
                                <asp:Button ID="Artclear" runat="server" Visible="true" OnClick="Artclear_Click" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                                <div class="container" style="margin-top:15px" runat="server">
                                    <div class="form-group">
                                    <asp:Label ID="Label6" runat="server">Databinder:</asp:Label>
                                    <asp:DropDownList ID="Artdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Artist" SelectMethod="GetArtist" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="Artdelete" runat="server" OnClick="Artdelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
      
    </div>

        <div class="panel panel-default" id="dms" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iDMS">
        Deviant Music Social Media </a>
      </h4>
    </div>
    <div id="iDMS" class="panel-collapse collapse">
      <div class="panel-body">
                           <div class="container" style="margin-top:15px">
              <div class="form-group">
                                              <asp:TextBox ID="DMSsearch" runat="server" class="form-control" placeholder="Search By ID"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="DMSsearch1" OnClick="DMSsearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="ID:"></asp:Label>
                                              <asp:TextBox Enabled="false" ID="DMSId" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="DMSAM1" runat="server" Text="* Required" ControlToValidate="DMSAM" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="DMSAM" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="URL:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="DMSFB1" runat="server" Text="* Required" ControlToValidate="DMSFB" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="DMSFB" runat="server" class="form-control" placeholder="URL"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Image:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="DMSTT1" runat="server" Text="* Required" ControlToValidate="DMUP" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:FileUpload ID="DMUP" runat="server" CssClass="form-control" />
                                                                 </div>
    <asp:Button ID="DMScreate" class="btn btn-primary" runat="server" OnClick="DMScreate_Click" Text="Create"  CausesValidation="false"/>
                     <asp:Button ID="DMSupdate" class="btn btn-success" OnClick="DMSupdate_Click" runat="server" Text="Update"  CausesValidation="false"/> 
                                 <asp:Button ID="DMSclear" runat="server" OnClick="DMSclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                                 <div class="container" style="margin-top:15px" runat="server">
                                    <div class="form-group">
                                    <asp:Label ID="Label4" runat="server">Databinder:</asp:Label>
                                    <asp:DropDownList ID="DMSdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.DeviantSocial" SelectMethod="GetDMS" CssClass="form-control" DataTextField="Url" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="DMSdelete" runat="server" OnClick="DMSdelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
     
    </div>

         <div class="panel panel-default" id="GENs" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iGenres">
        Genres</a>
      </h4>
    </div>
    <div id="iGenres" class="panel-collapse collapse">
      <div class="panel-body">
                             <div class="container" style="margin-top:15px">
              <div class="form-group">
                                              <asp:TextBox ID="Gsearch" runat="server" class="form-control" placeholder="Search By Name"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="Gsearch1" OnClick="Gsearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="ID:"></asp:Label>
                                              <asp:TextBox Enabled="false" ID="GId" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Gname1" runat="server" Text="* Required" ControlToValidate="Gname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Gname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                             </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="RouteUrl:"></asp:Label><br />
                                <asp:Label ID="Label13" runat="server">Input Name But Use Underscore(_) Instead Of Space If Needed:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="* Required" ControlToValidate="Groute" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Groute" runat="server" class="form-control" placeholder="GenreRouteUrl"></asp:TextBox>
                                </div>
    <asp:Button ID="Gcreate" class="btn btn-primary" runat="server" OnClick="Gcreate_Click" Text="Create"  CausesValidation="false"/>
                                                                  <asp:Button ID="Gupdate" class="btn btn-success" OnClick="Gupdate_Click" runat="server" Text="Update"  CausesValidation="false"/> 
                                  <asp:Button ID="Gclear" runat="server" OnClick="Gclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                                <div class="container" style="margin-top:15px" runat="server">
                                    <div class="form-group">
                                    <asp:Label ID="Label5" runat="server">Databinder:</asp:Label>
                                    <asp:DropDownList ID="Gdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Genre" SelectMethod="GetGenre" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="Gdelete" runat="server" OnClick="Gdelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
    
    </div>

          <div class="panel panel-default" id="pers" runat="server" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iPers">
        Personnels</a>
      </h4>
    </div>
    <div id="iPers" class="panel-collapse collapse">
      <div class="panel-body">
                            <div class="container" style="margin-top:15px">
              <div class="form-group">
                                              <asp:TextBox ID="Pesearch" runat="server" class="form-control" placeholder="Search By Title"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="Pesearch1" OnClick="Pesearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />

          </div>
                            <div class="container" style="margin-top:15px">
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="ID:"></asp:Label>
                                              <asp:TextBox Enabled="false" ID="PeID" runat="server" class="form-control" placeholder="ID"></asp:TextBox>
              </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Pename1" runat="server" Text="* Required" ControlToValidate="Pename" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Pename" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                                   </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="RouteUrl:"></asp:Label><br />
                                <asp:Label ID="Label14" runat="server">Input Name But Use Underscore(_) Instead Of Space Where Needed:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Text="* Required" ControlToValidate="Peroute" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Peroute" runat="server" class="form-control" placeholder="PersonnelRouteUrl"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="Designation:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Pedes1" runat="server" Text="* Required" ControlToValidate="Pedes" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Pedes" runat="server" class="form-control" placeholder="Designation"></asp:TextBox>
                                                   </div>
                                 <div class="form-group">
                            <asp:Label runat="server" Text="Social Media Url:"></asp:Label>
                            <asp:TextBox ID="Peurl" runat="server" class="form-control" placeholder="SM URL"></asp:TextBox>
                                                   </div>
                                 <div class="form-group">
                                                                 <asp:Label ID="PeImage2" runat="server">Image File:</asp:Label>
                                <asp:RequiredFieldValidator ID="PeImage1" runat="server" Text="* Required" ControlToValidate="PeImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                   <asp:FileUpload ID="PeImage" runat="server" class="form-control" placeholder="Image Path"></asp:FileUpload>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Bio:"></asp:Label>
                            <asp:RequiredFieldValidator ID="Pebio1" runat="server" Text="* Required" ControlToValidate="Pebio" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <textarea ID="Pebio" runat="server" class="form-control" placeholder="Bio" style="height:200px"></textarea>
                                 </div>
                                
    <asp:Button ID="Pecreate" class="btn btn-primary" runat="server" Text="Create" OnClick="Pecreate_Click"  CausesValidation="false"/>
                                    <asp:Button ID="Peupdate" class="btn btn-success" OnClick="Peupdate_Click" runat="server" Text="Update"  CausesValidation="false"/> 
                                <asp:Button ID="Peclear" runat="server" OnClick="Peclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>
                                 <div class="container" style="margin-top:15px" runat="server">
                                    <div class="form-group">
                                    <asp:Label ID="Label7" runat="server">Databinder:</asp:Label>
                                    <asp:DropDownList ID="Pedrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Personnel" SelectMethod="GetPers" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="Pedelete" runat="server" OnClick="Pedelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
      
    </div>

        <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#iSong">
        Songs/Beats</a>
      </h4>
    </div>
    <div id="iSong" class="panel-collapse collapse">
      <div class="panel-body">
                            <div class="container" style="margin-top:15px">

                                <div class="form-group">
                                    <asp:Label runat="server" Text="Title:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Sgtitle1" runat="server" Text="* Required" ControlToValidate="Stitle" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Stitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="RouteUrl:"></asp:Label>
                                <asp:Label ID="Label15" runat="server">Input Title But Use Underscore(_) Instead Of Space Where Needed:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Text="* Required" ControlToValidate="AlBtitle" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Sroute" runat="server" class="form-control" placeholder="SongRouteUrl"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Sgenre2" runat="server">Genre Databinder:</asp:Label>
                                    <asp:RequiredFieldValidator ID="Sgenre1" runat="server" Text="* Required" ControlToValidate="Sgenre" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="Sgenre" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Genre" SelectMethod="GetSongGenre" class="form-control" placeholder="Select Genre"  DataTextField="Name" DataValueField="Id" >
                                    </asp:DropDownList>
                                </div>
                                 <div class="form-group">
                                    <asp:Label ID="Sartist1" runat="server">Artist Databinder(Not Required for non-managed Artist):</asp:Label>
                                    <asp:DropDownList ID="Sartist" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Artist" SelectMethod="GetSongArtist" class="form-control" placeholder="Select Artist"  DataTextField="Name" DataValueField="Id" >
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Salb1" runat="server">Album Databinder(Not required for Single):</asp:Label>
                                    <asp:DropDownList ID="Salb" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Album" SelectMethod="GetSongAlbum" class="form-control" placeholder="Select Album"  DataTextField="Title" DataValueField="Id" >
                                    </asp:DropDownList>
                                </div>
                            <div class="form-group">
                                <asp:Label runat="server" Text="Genre Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SGname1" runat="server" Text="* Required" ControlToValidate="SGname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="SGname" runat="server" class="form-control" placeholder="Genre Name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Artist Name:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SArtname1" runat="server" Text="* Required" ControlToValidate="SArtname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="SArtname" runat="server" class="form-control" placeholder="Artist Name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Album Title:"></asp:Label>
                            <asp:TextBox ID="SAlbname" runat="server" class="form-control" placeholder="Album Title(Not required for single)"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Producer(s):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SProd1" runat="server" Text="* Required" ControlToValidate="SProd" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="SProd" runat="server" class="form-control" placeholder="Producer(s)"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Featuring:"></asp:Label>
                            <asp:TextBox ID="Sfeat" runat="server" class="form-control" placeholder="Featuring(Leave empty if none)"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                     <asp:Label runat="server" Text="Writer(s):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Swriter1" runat="server" Text="* Required" ControlToValidate="Swriter" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="Swriter" runat="server" class="form-control" placeholder="Writer(s)"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Release Date:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SRdate1" runat="server" Text="* Required. Format dd-mmm-yy" ControlToValidate="SRdate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    
                            <asp:TextBox ID="SRdate" runat="server" class="form-control" TextMode="Date" placeholder="Release Date. Format 01-Jan-21"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Upload Date:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SUdate1" runat="server" Text="* Required. Format dd-mmm-yy" ControlToValidate="SUdate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="SUdate" runat="server" class="form-control" TextMode="Date" placeholder="Upload Date. Format 01-Jan-21"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="License:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SLi1" runat="server" Text="* Required. Format(Sponsored,Free or Paid)" ControlToValidate="SLi" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="SLi" runat="server" class="form-control" placeholder="License(Input Sponsored, Free or Paid)"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Price:"></asp:Label>
                                     <asp:RequiredFieldValidator ID="SPri1" runat="server" Text="* Required. If lincense is Free input 0.00" ControlToValidate="SPri" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="SPri2" runat="server" Text="* Must be a valid price without currency symbol. Format 0.00" ControlToValidate="SPri" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="SPri" runat="server" class="form-control" placeholder="Price(Format 0.00. If lincense is Free/Sponsored input 0.00)"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Stream Url:"></asp:Label>
                            <asp:TextBox ID="SAmack" runat="server" class="form-control" placeholder="Stream URL"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Fanlink Url:"></asp:Label>
                            <asp:TextBox ID="SFlink" runat="server" class="form-control" placeholder="Fanlink URL(Leave empty if there is no link)"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Purchase Url:"></asp:Label>
                            <asp:TextBox ID="SPurc" runat="server" class="form-control" placeholder="Purchase URL"></asp:TextBox>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Download Count:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="SDcount1" runat="server" Text="* Required" ControlToValidate="SDcount" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="SDcount2" runat="server" Text="* Input 0" ControlToValidate="SDcount" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="SDcount" runat="server" class="form-control" placeholder="Download Count. Input 0"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                     <asp:Label ID="SImage2" runat="server">Image File:</asp:Label>
                            <asp:RequiredFieldValidator ID="SImage1" runat="server" Text="* Required" ControlToValidate="SImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:FileUpload ID="SImage" runat="server" class="form-control" placeholder="Image Path"></asp:FileUpload>
                                 </div>
                                <div class="form-group">
                            <asp:Label ID="SAudio2" runat="server">Audio File:</asp:Label>
                            <asp:RequiredFieldValidator ID="SAudio1" runat="server" Text="* Required" ControlToValidate="SAudio" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:FileUpload ID="SAudio" runat="server" class="form-control" placeholder="Audio Path"></asp:FileUpload>
                                 </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Description:"></asp:Label>
                            <asp:RequiredFieldValidator ID="Sdesc1" runat="server" Text="* Required" ControlToValidate="Sdesc" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                            <textarea ID="Sdesc" runat="server" class="form-control" placeholder="Description" style="height:200px"></textarea>
                                 </div>
                                
    <asp:Button ID="Screate" class="btn btn-primary" runat="server" OnClick="Screate_Click" Text="Create"  CausesValidation="false"/>
                                  <asp:Button ID="Sclear" runat="server" OnClick="Sclear_Click" Visible="true" class="btn btn-default" Text="Clear"  CausesValidation="false"/>

                                <div class="container" style="margin-top:15px" id="Sdeletes" visible="false" runat="server">
                                    <div class="form-group">
                                    <asp:Label ID="Label9" runat="server">Databinder:</asp:Label>
                                    <asp:DropDownList ID="Sdrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Song" SelectMethod="GetSong" CssClass="form-control" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
                                    </div>
                                <asp:Button ID="Sdelete" runat="server" OnClick="Sdelete_Click" class="btn btn-danger" Text="Delete"  CausesValidation="false"/>
                                </div>
                            </div>
                         </div>
                       </div>
      

 </div>
      
            <div class="panel panel-default" runat="server" id="role1" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#role">
        Roles</a>
      </h4>
    </div>
    <div id="role" class="panel-collapse collapse">
      <div class="panel-body">
        
               <div class="container" style="margin-top:15px">
                                <div class="form-group">
                                    <asp:Label ID="users1" runat="server">Username Databinder:</asp:Label>
                                    <asp:RequiredFieldValidator ID="users2" runat="server" Text="* Required" ControlToValidate="users" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="users" AppendDataBoundItems="true" runat="server" class="form-control" DataTextField="UserName" DataValueField="Id" SelectMethod="GetUsers" placeholder="Select Username">
                                    </asp:DropDownList>
                                </div>
                                 <div class="form-group">
                                    <asp:Label ID="roles1" runat="server">Role Databinder:</asp:Label>
                                    <asp:RequiredFieldValidator ID="roles2" runat="server" Text="* Required" ControlToValidate="roles" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="roles" runat="server" AppendDataBoundItems="true"  class="form-control" DataTextField="Name" DataValueField="Id" SelectMethod="GetRoles" placeholder="Select Role"  >
                                    </asp:DropDownList>
                                </div>
                   <asp:Button ID="rcreate" class="btn btn-primary" runat="server" Text="Create" OnClick="rcreate_Click" CausesValidation="false"/>
                                 <asp:Button ID="rupdate" runat="server" class="btn btn-success" OnClick="rupdate_Click" Text="Update" CausesValidation="false"/> 
                                <asp:Button ID="rdelete" runat="server" Visible="true" class="btn btn-danger" OnClick="rdelete_Click" Text="Delete"  CausesValidation="false"/>

        </div>
        </div>
        </div> 

             </div>

         <div class="panel panel-default" runat="server" id="user1" visible="false">
    <div class="panel-heading">
      <h4 class="panel-title" style="text-align:center">
        <a data-toggle="collapse" data-parent="#accordion" href="#user">
        Users</a>
      </h4>
    </div>
    <div id="user" class="panel-collapse collapse">
      <div class="panel-body">
        
               <div class="container" style="margin-top:15px">
                   <div class="form-group">
                       Number of Users:<asp:Label runat="server" ID="usercount" Text="" ForeColor="Green"></asp:Label>
                   </div>
                      <%--<div class="form-group">
                        <asp:Label runat="server">User Emails:</asp:Label>
                           <asp:TextBox ID="emailist1" runat="server" class="form-control" Text="" TextMode="MultiLine" style="height:200px"></asp:TextBox>
                       </div>--%>
                   <asp:Label runat="server">User Emails:</asp:Label>         
                   <div class="textarea" style="height:200px">
                       <asp:ListView ID="emailList" DataTextField="Email" DataValueField="Id" runat="server" SelectMethod="GetEmails" >
                <ItemTemplate>
                    <%#Eval("Email") %>
                        
                </ItemTemplate>
                <ItemSeparatorTemplate>,</ItemSeparatorTemplate>           

            </asp:ListView>
                   </div>
                   <div class="form-group">
                                    <asp:Label ID="Label16" runat="server">Username Databinder:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Text="* Required" ControlToValidate="users" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DropDownList1" AppendDataBoundItems="true" runat="server" class="form-control" DataTextField="Email" DataValueField="Id" SelectMethod="GetUserss" placeholder="Select Username">
                                    </asp:DropDownList>
                                </div>
                   <asp:Button ID="userdelete" runat="server" Visible="true" class="btn btn-danger" OnClick="userdelete_Click" Text="Delete"  CausesValidation="false"/>
        </div>
        </div>
        </div> 

             </div>

        <div class="panel panel-default" runat="server" id="mailing1" visible="false">
            <div class="panel-heading"><h4 class="panel-title" style="text-align:center">
                <a data-toggle="collapse" data-parent="#accordion" href="#mailing">Mailing</a>
                                       </h4></div>
            <div id="mailing" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="container" style="margin-top:15px">

          <div class="form-group">
    <asp:Label ID="Label17" runat="server">To:</asp:Label>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ErrorMessage="*Required" ControlToValidate="inputEmail" />
              <asp:Textbox runat="server" TextMode="email" id="inputEmail" class="form-control" placeholder="Email"></asp:Textbox>
        </div>
          <div class="form-group">
               <asp:Label runat="server">Subject:</asp:Label>
                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ErrorMessage="*Required" ControlToValidate="inputSubject" />
              <asp:Textbox id="inputSubject" runat="server" class="form-control" placeholder="Subject"></asp:Textbox>
         </div>
            <div class="form-group">
                 <asp:Label runat="server">Message:</asp:Label>
                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ErrorMessage="*Required" ControlToValidate="inputMessage" />
              <asp:Textbox id="inputMessage" runat="server" class="form-control" TextMode="MultiLine" style="height:200px" placeholder="Message"></asp:Textbox>
         </div>
          <div class="form-group">
              <asp:FileUpload ID="upload1" AllowMultiple="true" CssClass="form-control" runat="server" />
          </div>
                   <asp:Button ID="request" runat="server" Visible="true" class="btn btn-primary" Text="Send" OnClick="request_Click" CausesValidation="false"/>
          <asp:Label ID="respsuccess" runat="server" Text="" ForeColor="Green" />
                    </div>
                </div>
            </div>
        </div>

          <div class="panel panel-default" runat="server" id="downloadurlgen1" visible="false">
            <div class="panel-heading"><h4 class="panel-title" style="text-align:center">
                <a data-toggle="collapse" data-parent="#accordion" href="#downloadurlgen">Download Url Generator</a>
                                       </h4></div>
            <div id="downloadurlgen" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="container" style="margin-top:15px">
                         <div class="form-group">
                                    <asp:Label ID="Label18" runat="server">Song Databinder:</asp:Label>
                                    <asp:DropDownList ID="SongDrop" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.song" SelectMethod="GetSongsss" CssClass="form-control" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
                                    </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Title:"></asp:Label>
                            <asp:TextBox runat="server" ID="DownTT" CssClass="form-control" placeholder="Download TItle"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <asp:Label runat="server" Text="Url:"></asp:Label>
                            <asp:TextBox runat="server" ID="DownUrl" CssClass="form-control" placeholder="Download Url"></asp:TextBox>
                        </div>
                        <div class="form-group">
                        <asp:CheckBox runat="server" ID="TempoDown" />
                                <asp:Label runat="server" AssociatedControlID="TempoDown">Temporary Download</asp:Label>
                            </div>
                   <asp:Button ID="GenerateButton" runat="server" Visible="true" OnClick="Generate_Click" class="btn btn-success" Text="Generate" CausesValidation="false"/>
                    </div>
                </div>
            </div>
        </div>
         <div class="panel panel-default" runat="server" id="tempdownloadgen1" visible="false">
            <div class="panel-heading"><h4 class="panel-title" style="text-align:center">
                <a data-toggle="collapse" data-parent="#accordion" href="#tempdownloadurlgen">Download Urls</a>
                                       </h4></div>
            <div id="tempdownloadurlgen" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="container" style="margin-top:15px">
                         <div class="form-group">
                                              <asp:TextBox ID="urlsearch" runat="server" class="form-control" placeholder="Search By Title"></asp:TextBox>
              </div>
                                <asp:Button runat="server" ID="urlsearch1" OnClick="urlsearch1_Click" CausesValidation="false" CssClass="btn btn-info" Text="Search" />
                         <div class="form-group">
                            <asp:Label runat="server" Text="Url:"></asp:Label>
                            <asp:TextBox runat="server" ID="TempDownUrl" CssClass="form-control" placeholder="Download Url"></asp:TextBox>
                        </div>
                         <div class="form-group">
                                    <asp:Label ID="Label20" runat="server">Download Databinder:</asp:Label>
                                    <asp:DropDownList ID="SongDrop1" runat="server" AppendDataBoundItems="true" ItemType="Deviant_Music.Models.Download" SelectMethod="GetDownloads" CssClass="form-control" DataTextField="DownloadTitle" DataValueField="Id"></asp:DropDownList>
                                    </div>
                   <asp:Button ID="Downdelete" runat="server" Visible="true" class="btn btn-danger" Text="Delete" OnClick="Downdelete_Click" CausesValidation="false"/>
                    </div>
                    </div>
                </div>
            </div>
        </div>
       </section>
</asp:Content>
