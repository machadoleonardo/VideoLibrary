using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VideoLibrary.Entities;

namespace VideoLibrary.Context
{
    public class VideoLibraryContext : DbContext
    {

        public VideoLibraryContext() : base("DefaultConnection")
        {
        }

        public static VideoLibraryContext Create()
        {
            return new VideoLibraryContext();
        }


        public DbSet<Movie> Movie { get; set; }

        public DbSet<Genre> Genre { get; set; }

    }
}