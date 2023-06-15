using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using Deviant_Music.Models;
using Deviant_Music.Logic;

namespace Deviant_Music
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<DeviantContext>(null);

            // Create the administrator role and user.
            RoleAction roleAction = new RoleAction();
            roleAction.createAdmin();

            RegisterCustomRoutes(RouteTable.Routes);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "SongsByGenreRoute",
                "Genre/{Name}",
                "~/Default.aspx"
            );
            routes.MapPageRoute(
                "SongByTitleRoute",
                "Song/{songTitle}",
                "~/SongDetails.aspx"
            );
            routes.MapPageRoute(
               "PersonnelByNameRoute",
               "Personnel/{personnelName}",
               "~/PersonnelDetails.aspx"
           );
            routes.MapPageRoute(
               "AlbumByTitleRoute",
               "Album/{albumTitle}",
               "~/AlbumDetails.aspx"
           );
            routes.MapPageRoute(
               "ArtistByNameRoute",
               "Artist/{artistName}",
               "~/ArtistDetails.aspx"
           );
            routes.MapPageRoute(
              "AnnouncementByTitleRoute",
              "Announcement/{announcementTitle}",
              "~/AnnouncementDetails.aspx"
          );
            routes.MapPageRoute(
                "Downloads",
                "downloads/{downloadtoken}",
                "~/DownloadFile.aspx");
            routes.MapPageRoute(
               "TemporaryDownloads",
               "temporarydownloads/{downloadtoken}",
               "~/TemporaryDownloadFile.aspx");
        }
    }
}