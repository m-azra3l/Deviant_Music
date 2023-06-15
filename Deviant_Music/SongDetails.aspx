<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SongDetails.aspx.cs" Inherits="Deviant_Music.SongDetails" MasterPageFile="~/Site.Master"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="~/Template/dist/css/adminlte.css" rel="stylesheet" />
    <asp:FormView ID="songDetail" runat="server" 
ItemType="Deviant_Music.Models.Song" SelectMethod ="GetSong" 
RenderOuterTable="false">
        
<ItemTemplate>



    <h3>Song Details</h3>
    <hr />

      <!-- Default box -->
      <div class="container card-solid">
        <div class="card-body">
          <div class="row">
            <div class="col-12 col-sm-6">
              <h4 class="d-inline-block d-sm-none"><%#:Item.Title %></h4>
              <div class="col-12">
                <img src="/Catalog/Song/<%#:Item.ImagePath %>" style="height:50%;width:100%" alt="<%#:Item.Title %>"/>         

              </div>
              
            </div>
            <div class="col-12 col-sm-6" style="margin-top:30px">
              <h4 class="my-3">Decription:</h4>
                <span>Artiste: <%#:Item.ArtistName %></span> 
                <br />
                <span runat="server" id="albms" visible='<%#Eval("AlbumName").Equals("")?false:true %>'>Album: <%#:Item.AlbumName %> <br /></span> 
               
                <span>Genre: <%#:Item.GenreName %></span> 
                <br />
                <span>Producer(s): <%#:Item.Producer %></span>
                <br />
                <span>Writer(s): <%#:Item.Writter %></span>
                <br />
                <span>Release Date: <%#Eval("ReleaseDate") %></span> 
                <br />
                <span>Upload Date: <%#Eval("UploadDate") %></span>
                <br />
                <asp:Label runat="server" ID="feat" Visible='<%#Eval("Featuring").Equals("")? false:true %>'>Featuring: <%#:Item.Featuring %>  <br /></asp:Label>
                <span><%#:Item.DownloadCount %> Downloads</span>
                <br />
                <span><p><%#:Item.Description %></p></span>
                <br />
              
              <hr>
        
              <iframe src="<%#:Item.AudiomackUrl%>" style="width:100%;height:252px" runat="server" scrolling="no" frameborders="0" scrollbars="no"></iframe>
              
              <hr />

              <div class="mt-4">
                <p>
                    <asp:Label runat="server" Font-Bold="true" Font-Size="Medium" id="iprice" visible='<%#Eval("License").Equals("Sponsored")%>'><%#:Item.License %></asp:Label>
                    <asp:Label runat="server" Font-Bold="true" Font-Size="Medium" ID="Label1" Visible='<%#Eval("License").Equals("Paid")%>'>#<%#:Item.Price %></asp:Label>
                     <asp:Label runat="server" Font-Bold="true" Font-Size="Medium" ID="Label2" Visible='<%#Eval("License").Equals("Free") %>'><%#:Item.License %></asp:Label><br />
                    <asp:Label runat="server" ID="Label10" Visible='<%#Eval("License").Equals("Free") %>'>For promotional use only</asp:Label>
                </p>
              </div>
                <asp:LoginView ID="log1" runat="server">
                    <AnonymousTemplate>
                <div class="mt-4">
                    <p>
                     <asp:Label runat="server" ID="logreg">Please <a href="Account/Login.aspx" runat="server" target="_blank">Sign in</a> or <a href="Account/Register.aspx" runat="server" target="_blank">Register</a> to download/purchase song.</asp:Label>
                    </p>
                </div>
                        </AnonymousTemplate>
                    <LoggedInTemplate>
                <div class="mt-4" runat="server" id="licinfo">
                <p>
                     <asp:Label runat="server" ID="Label9" Visible='<%#Eval("License").Equals("Paid")%>'>Click on Buy to purchase for Android, Linux and WindowsPC</asp:Label>
                     <asp:Label runat="server" ID="Label10" Visible='<%#Eval("License").Equals("Free") %>'>Available for Android, Linux and WindowsPc</asp:Label><br />
                    <asp:Label runat="server" ID="Label11"  Visible='<%#Eval("Fanlink").Equals("")? false:true%>'>Click on Fanlink for information on other music stores</asp:Label>
                </p>
              </div>
              <div class="mt-4" runat="server" id="licinfo2">
                   <asp:Button class="btn btn-success btn-md btn-flat" runat="server" Text="Download" role="button" id="dload" Visible='<%#Eval("License").Equals("Free") %>' OnClick="dload_Click" CommandArgument='<%#Eval("Id") %>'/>
                <asp:LinkButton class="btn btn-primary btn-md btn-flat" runat="server" role="button" id="buy" href='<%#Eval("PurchaseURL") %>' Visible='<%#Eval("License").Equals("Paid") %>' target="_blank" Text="Buy Now"/>
                <asp:LinkButton class="btn btn-info btn-md btn-flat" runat="server" target="_blank" role="button" id="flink" Visible='<%#Eval("Fanlink").Equals("")? false:true %>' href='<%#Eval("Fanlink") %>' Text="Fanlink" />
              </div>
                        </LoggedInTemplate>
                    </asp:LoginView>
                <br />
                <div class="mt-4 product-share">
                    Share on your social media:
                    <br />
                    <a href="https://www.facebook.com/sharer/sharer.php?u=@Url.Encode(Request.Url.ToString())&t=@Url.Encode(PageTitle)" runat="server" title="Share" target="_blank"><img src="Content/Images/fb.PNG" runat="server" /></a>
                    <a href="https://twitter.com/intent/tweet?url=@Url.Encode(Request.Url.ToString())&text=@Url.Encode(PageTitle)" target="_blank" runat="server" title="Tweet"><img src="Content/Images/twit.PNG" runat="server" /></a>
                    <a href="whatsapp://send?url=@Url.Encode(Request.Url.ToString())&text=@Url.Encode(PageTitle)" data-action="share/whatsapp/share" runat="server" title="Share" target="_blank"><img src="Content/Images/wa.PNG" runat="server" /></a>
                </div>
            </div>
          </div>
        
        </div>
        <!-- /.card-body -->
      </div>
      <!-- /.card -->

    </ItemTemplate>
        </asp:FormView>
</asp:Content>
