﻿using CompanyNameSpace.ProjectName.Application.Contracts;
using CompanyNameSpace.ProjectName.Domain.Common;
using CompanyNameSpace.ProjectName.Domain.Entities;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence;

public class ProjectNameDbContext : DbContext
{
    private readonly ILoggedInUserService? _loggedInUserService;

    /*
    public ProjectNameDbContext(DbContextOptions<ProjectNameDbContext> options)
       : base(options)
    {
    }
    */
    public ProjectNameDbContext(DbContextOptions<ProjectNameDbContext> options,
        ILoggedInUserService loggedInUserService)
        : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<EntityOne> EntityOnes { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectNameDbContext).Assembly);

        //seed data, added through migrations
        var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
        var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
        var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = concertGuid,
            Name = "Concerts"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = musicalGuid,
            Name = "Musicals"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = playGuid,
            Name = "Plays"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = conferenceGuid,
            Name = "Conferences"
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
            Name = "The Eras Tour",
            Price = 65,
            Artist = "Taylor Swift",
            Date = DateTime.Now.AddMonths(6),
            Description =
                "The Eras Tour is the ongoing sixth concert tour by the American singer-songwriter Taylor Swift. It commenced on March 17, 2023, in Glendale, Arizona, and is set to conclude on December 8, 2024, in Vancouver, consisting of 149 shows that span five continents.",
            ImageUrl = "https://somewhere.org/images/TaylorSwift.jpg",
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
            Name = "Chappell Roan Night",
            Price = 85,
            Artist = "Chappell Roan",
            Date = DateTime.Now.AddMonths(9),
            Description =
                "Kayleigh Rose Amstutz, known professionally as Chappell Roan, is an American singer and songwriter. Working with collaborator Dan Nigro, the majority of her music is inspired by 1980s synth-pop and early 2000s pop hits.",
            ImageUrl = "https://somewhere.org/images/chappellroan.jpg",
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
            Name = "Clash of the Punks",
            Price = 85,
            Artist = "Daft Punk",
            Date = DateTime.Now.AddMonths(4),
            Description =
                "Daft Punk were a French electronic music duo formed in 1993 in Paris by Thomas Bangalter and Guy-Manuel de Homem-Christo. ",
            ImageUrl = "https://somewhere.org/images/dj.jpg",
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
            Name = "The Beyonce Tour",
            Price = 25,
            Artist = "Beyonce",
            Date = DateTime.Now.AddMonths(4),
            Description =
                "Beyoncé Giselle Knowles-Carter is an American singer, songwriter, and businesswoman. Nicknamed 'Queen Bey', she is regarded as an influential cultural figure of the 21st century.",
            ImageUrl = "https://somewhere.org/images/Beyonce.jpg",
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
            Name = "The Dark Side of the Moon",
            Price = 400,
            Artist = "Pink Floyd",
            Date = DateTime.Now.AddMonths(10),
            Description =
                "Pink Floyd earliest shows were performed in 1965. They included Bob Klose as a member of the band, which at first played mainly RnB covers. Klose left the band after 1965.",
            ImageUrl = "https://somewhere.org/images/conf.jpg",
            CategoryId = conferenceGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
            Name = "Licks Tour",
            Price = 135,
            Artist = "The Rolling Stones",
            Date = DateTime.Now.AddMonths(8),
            Description =
                "Since forming in 1962, the English rock band the Rolling Stones have performed more than two thousand concerts around the world, becoming one of the world's most popular live music attractions in the process.",
            ImageUrl = "https://somewhere.org/images/RollingStones.jpg",
            CategoryId = musicalGuid
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
            OrderTotal = 400,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
            OrderTotal = 135,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
            OrderTotal = 85,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
            OrderTotal = 245,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
            OrderTotal = 142,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
            OrderTotal = 40,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
            OrderTotal = 116,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
        });

        modelBuilder.Entity<EntityOne>().HasData(new EntityOne
        {
            EntityOneId = 1,
            Name = "One",
            Price = 1.23M,
            Description = "First Item",
            TypeId = 1
        });


        modelBuilder.Entity<EntityOne>().HasData(new EntityOne
        {
            EntityOneId = 2,
            Name = "Two",
            Price = 1.24M,
            Description = "Second Item",
            TypeId = 2
        });

        modelBuilder.Entity<EntityOne>().HasData(new EntityOne
        {
            EntityOneId = 3,
            Name = "Three",
            Price = 1.25M,
            Description = "Third Item",
            TypeId = 2
        });

        modelBuilder.Entity<EntityOne>().HasData(new EntityOne
        {
            EntityOneId = 4,
            Name = "Four",
            Price = 1.26M,
            Description = "Fourth Item",
            TypeId = 4
        });

        modelBuilder.Entity<EntityOne>().HasData(new EntityOne
        {
            EntityOneId = 5,
            Name = "Five",
            Price = 1.27M,
            Description = "Fifth Item",
            TypeId = 4
        });

        modelBuilder.Entity<EntityOne>().HasData(new EntityOne
        {
            EntityOneId = 6,
            Name = "Six",
            Price = 1.28M,
            Description = "Sixth Item",
            TypeId = 4
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _loggedInUserService?.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = _loggedInUserService?.UserId;
                    break;
            }

        return base.SaveChangesAsync(cancellationToken);
    }
}

/*
Package Nuget Console
Select correct project in drop

Add-Migration Initial -Context ProjectNameDbContext
*/