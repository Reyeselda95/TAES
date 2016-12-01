
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using RetappGenNHibernate.EN.Retapp;
using RetappGenNHibernate.CEN.Retapp;
using RetappGenNHibernate.CAD.Retapp;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                /*List<RetappGenNHibernate.EN.Mediaplayer.MusicTrackEN> musicTracks = new List<RetappGenNHibernate.EN.Mediaplayer.MusicTrackEN>();
                 * RetappGenNHibernate.EN.Mediaplayer.UserEN userEN = new RetappGenNHibernate.EN.Mediaplayer.UserEN();
                 * RetappGenNHibernate.EN.Mediaplayer.ArtistEN artistEN = new RetappGenNHibernate.EN.Mediaplayer.ArtistEN();
                 * RetappGenNHibernate.EN.Mediaplayer.MusicTrackEN musicTrackEN = new RetappGenNHibernate.EN.Mediaplayer.MusicTrackEN();
                 * RetappGenNHibernate.CEN.Mediaplayer.ArtistCEN artistCEN = new RetappGenNHibernate.CEN.Mediaplayer.ArtistCEN();
                 * RetappGenNHibernate.CEN.Mediaplayer.UserCEN userCEN = new RetappGenNHibernate.CEN.Mediaplayer.UserCEN();
                 * RetappGenNHibernate.CEN.Mediaplayer.MusicTrackCEN musicTrackCEN = new RetappGenNHibernate.CEN.Mediaplayer.MusicTrackCEN();
                 * RetappGenNHibernate.CEN.Mediaplayer.PlayListCEN playListCEN = new RetappGenNHibernate.CEN.Mediaplayer.PlayListCEN();
                 *
                 *              //Add Users
                 * userEN.Email = "user@user.com";
                 * userEN.Name = "user";
                 * userEN.Surname = "userSurname";
                 * userEN.Password = "user";
                 * userCEN.New_(userEN.Name, userEN.Surname, userEN.Email, userEN.Password);
                 *
                 * //Add Music Track1
                 * musicTrackEN.Id = "http://www2.b3ta.com/mp3/Beer Beer Beer (YOB mix).mp3";
                 * musicTrackEN.Format = "mp3";
                 * musicTrackEN.Lyrics = "Beer Beer Beer Beer Beer Beer ..";
                 * musicTrackEN.Name = "Beer Beer Beer";
                 * musicTrackEN.Company = "Company";
                 * musicTrackEN.Cover = "http://www.tomasabraham.com.ar/cajadig/2007/images/nro18-2/beer1.jpg";
                 * musicTrackEN.Price = 20;
                 * musicTrackEN.Rating = 5;
                 * musicTrackEN.CommunityRating = 5;
                 * musicTrackEN.Duration = 200;
                 * musicTrackCEN.New_(musicTrackEN.Id, musicTrackEN.Format, musicTrackEN.Lyrics, musicTrackEN.Name,
                 *  musicTrackEN.Company, musicTrackEN.Cover, musicTrackEN.CommunityRating, musicTrackEN.Rating,
                 *  musicTrackEN.Price, musicTrackEN.Duration);
                 * musicTracks.Add(musicTrackEN);
                 * musicTrackCEN.AsignUser(musicTrackEN.Id,userEN.Email);
                 *
                 * //Define Album
                 * //RetappGenNHibernate.CEN.Mediaplayer.AlbumCEN albumCEN = new RetappGenNHibernate.CEN.Mediaplayer.AlbumCEN();
                 * //albumCEN.New_("Album 1", "This is a Album 1", artists, musicTracks);*/

                AdminCEN acen = new AdminCEN();
                ConcursoCEN concen = new ConcursoCEN();
                RetoCEN retocen = new RetoCEN();
                acen.New_("ara65", "ara1995");
                concen.New_(new DateTime(2016, 3, 13), true, false, "CampañaA", "Descripción 1", "premio1", 0, new DateTime(2016, 3, 13), "http://www.huevosguillen.com/wp-content/uploads/2014/07/huevo-tradicional.jpg", "Compañia 1");
                concen.New_(new DateTime(2016, 3, 13), false, false, "CampañaB", "Descripción 2", "premio2", 0, new DateTime(2016, 3, 13), "http://4.bp.blogspot.com/_BGB6bJqOS60/TCKqPi71VcI/AAAAAAAAACQ/PGaT4Q44YqM/s320/Yoshi+Egg+icon.png", "Compañia 2");
                retocen.New_(1, "Reto1A", "DescA", new DateTime(2016, 4, 20), true);
                retocen.New_(1, "Reto2A", "DescA", new DateTime(2016, 4, 20), false);
                retocen.New_(2, "Reto1B", "DescB", new DateTime(2016, 4, 20), false);
                retocen.New_(2, "Reto2B", "DescB", new DateTime(2016, 4, 20), true);
                retocen.New_(2, "Reto3B", "DescB", new DateTime(2016, 4, 20), true);
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
