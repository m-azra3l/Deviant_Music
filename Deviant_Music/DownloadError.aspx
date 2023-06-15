<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DownloadError.aspx.cs" Inherits="Deviant_Music.DownloadError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:Label runat="server" ForeColor="Red" Font-Size="Large" Font-Bold="true"> Error while downloading the file.</asp:Label>
    <br />
    <asp:Label runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large">The Url has Expired.</asp:Label>
</asp:Content>
