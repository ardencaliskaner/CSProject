using CSProject.Product.Data.ORM.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace CSProject.Product.Data.ORM.Context
{
    public class CSProjectProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var server = Configuration["DBServer"] ?? "localhost";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUser"] ?? "SA";
            //var password = Configuration["DBPassword"] ?? "Ardentest123";
            //var database = Configuration["Database"] ?? "Colours";

            //var server = "localhost";
            var server = "ms-sql-server";
            var port = "1433";
            var user = "SA";
            var password = "Ardentest123";
            var database = "ProductDB";

            optionsBuilder.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password};MultipleActiveResultSets=true");


            //optionsBuilder.UseSqlServer(@"Data Source=YOURLOCALDBNAME;Database=ArmutProjectDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }



        public DbSet<Model.Product> Product { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    ApplyGeneralConfigurations(modelBuilder.Model.GetEntityTypes());
        //    //ApplyCustomConfigurations(modelBuilder);

        //    modelBuilder.Entity<Block>()
        //            .HasOne(d => d.BlockerUser)
        //            .WithMany(p => p.BlockBlockerUser)
        //            .HasForeignKey(d => d.BlockerUserID)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Block_UserBlocker");


        //    modelBuilder.Entity<Block>()
        //            .HasOne(d => d.BlockedUser)
        //            .WithMany(p => p.BlockBlockedUser)
        //            .HasForeignKey(d => d.BlockedUserID)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Block_UserBlocken");


        //    modelBuilder.Entity<MessageRoom>()
        //        .HasOne(d => d.CreatorUser)
        //        .WithMany(p => p.MessageRoomCreatorUser)
        //        .HasForeignKey(d => d.CreatorUserID)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_MessageRoom_UserCreator");


        //    modelBuilder.Entity<MessageRoom>()
        //        .HasOne(d => d.ChatUser)
        //        .WithMany(p => p.MessageRoomChatUser)
        //        .HasForeignKey(d => d.ChatUserID)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_MessageRoom_UserChat");
        //}

        //private void ApplyGeneralConfigurations(IEnumerable<IMutableEntityType> entities)
        //{
        //    foreach (var entityType in entities)
        //    {
        //        entityType.GetForeignKeys()
        //            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
        //            .ToList()
        //            .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        //    }

        //}
        //public DbSet<User> User { get; set; }
        //public DbSet<Block> Block { get; set; }
        //public DbSet<MessageRoom> MessageRoom { get; set; }
        //public DbSet<MessageDetail> MessageDetail { get; set; }

    }
}
