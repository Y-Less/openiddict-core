using Blueshift.EntityFrameworkCore.MongoDB.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;

namespace Mvc.Server.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<string>, IdentityRole<string>, string>
    {
        private MongoClient client_ = null;

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "mongodb://localhost";
            //optionsBuilder.UseMongoDb(connectionString);
        
            var mongoUrl = new MongoUrl(connectionString);
            //optionsBuilder.UseMongoDb(mongoUrl);
        
            MongoClientSettings settings = MongoClientSettings.FromUrl(mongoUrl);
            //settings.SslSettings = new SslSettings
            //{
            //    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            //};
            //optionsBuilder.UseMongoDb(settings);

            client_ = new MongoClient(settings);
            optionsBuilder.UseMongoDb(client_, x =>
            {
                x.UseDatabase("userDb");
            });
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
