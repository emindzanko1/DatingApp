﻿using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<UserLike> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserLike>()
           .HasKey(k => new { k.SourceUserId, k.TargetUserId});

        builder.Entity<UserLike>()
           .HasOne(u => u.SourceUser)
           .WithMany(l => l.LikedUsers)
           .HasForeignKey(u => u.SourceUserId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserLike>()
           .HasOne(u => u.TargetUser)
           .WithMany(l => l.LikedByUsers)
           .HasForeignKey(u => u.TargetUserId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
