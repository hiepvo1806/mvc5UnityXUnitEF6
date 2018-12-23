﻿using DataAccessLayer.Models;
using System.Data.Entity;

public class BookstoreContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public BookstoreContext() : base("name=BookstoreContext")
    {
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<BookShop> BookShops { get; set; }
}
