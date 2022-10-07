using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace MVCBasics.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser> // This is the class that manages the connection to the database
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Person> People => Set<Person>();

        public DbSet<City> Cities => Set<City>();

        public DbSet<Country> Countries => Set<Country>();

        public DbSet<Language> Languages => Set<Language>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Countries
            modelBuilder.Entity<Country>().HasData(new Country { ID = 1, Name = "Norway"});
            modelBuilder.Entity<Country>().HasData(new Country { ID = 2, Name = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 3, Name = "Sweden" });

            //Cities
            modelBuilder.Entity<City>().HasData(new { ID = 1, Name = "New Asgard", CountryID = 1});
            modelBuilder.Entity<City>().HasData(new { ID = 2, Name = "Jotunheim", CountryID = 1 });

            modelBuilder.Entity<City>().HasData(new { ID = 3, Name = "New York", CountryID = 2 });
            modelBuilder.Entity<City>().HasData(new { ID = 4, Name = "Westview", CountryID = 2 });

            modelBuilder.Entity<City>().HasData(new { ID = 5, Name = "Göteborg", CountryID = 3 });
            modelBuilder.Entity<City>().HasData(new { ID = 6, Name = "Alingsås", CountryID = 3 });

            //Languages
            modelBuilder.Entity<Language>().HasData(new Language { ID = 1, Name = "Norwegian" });
            modelBuilder.Entity<Language>().HasData(new Language { ID = 2, Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { ID = 3, Name = "Swedish" });

            //People
            modelBuilder.Entity<Person>().HasData(new { ID = 1, Name = "Thor Odinson", Phone = "0123 456789", CityID = 1 });
            modelBuilder.Entity<Person>().HasData(new { ID = 2, Name = "Valkyrie", Phone = "0123 456789", CityID = 1 });
            modelBuilder.Entity<Person>().HasData(new { ID = 3, Name = "Sif", Phone = "7777 777777", CityID = 1 });

            modelBuilder.Entity<Person>().HasData(new { ID = 4, Name = "Loki Odinson", Phone = "1234 567890", CityID = 2 });
            modelBuilder.Entity<Person>().HasData(new { ID = 5, Name = "Sylvie Laufeysdottir", Phone = "0000 000000", CityID = 2 });

            modelBuilder.Entity<Person>().HasData(new { ID = 6, Name = "Jane Foster", Phone = "2345 678901", CityID = 3 });
            modelBuilder.Entity<Person>().HasData(new { ID = 7, Name = "Tony Stark", Phone = "9999 999999", CityID = 3 });
            modelBuilder.Entity<Person>().HasData(new { ID = 8, Name = "Nick Fury", Phone = "8888 888888", CityID = 3 });
            modelBuilder.Entity<Person>().HasData(new { ID = 9, Name = "Natasha Romanoff", Phone = "8888 888888", CityID = 3 });

            modelBuilder.Entity<Person>().HasData(new { ID = 10, Name = "Darcy Lewis", Phone = "3456 789012", CityID = 4 });
            modelBuilder.Entity<Person>().HasData(new { ID = 11, Name = "Wanda Maximoff", Phone = "5555 555555", CityID = 4 });
            modelBuilder.Entity<Person>().HasData(new { ID = 12, Name = "Vision", Phone = "5555 555555", CityID = 4 });

            modelBuilder.Entity<Person>().HasData(new { ID = 13, Name = "Erik Selvig", Phone = "4567 890123", CityID = 5 });
            modelBuilder.Entity<Person>().HasData(new { ID = 14, Name = "Jenny Rigsjö", Phone = "0763 446373", CityID = 6 });

            //Norwegian
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData( new { LanguagesID = 1, PeopleID = 1}));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 2 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 3 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 4 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 5 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 6 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 9 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 1, PeopleID = 13 }));


            //English
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 1 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 2 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 3 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 6 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 7 }));


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 8 }));


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 9 }));


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 10 }));


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 11 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 12 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 13 }));


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 2, PeopleID = 14 }));


            //Swedish
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 3, PeopleID = 9 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 3, PeopleID = 13 }));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.People)
                .UsingEntity(j => j.HasData(new { LanguagesID = 3, PeopleID = 14 }));



            //Roles
            string adminRoleID = Guid.NewGuid().ToString();
            string userRoleID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = adminRoleID, Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = userRoleID, Name = "User", NormalizedName = "USER".ToUpper() });


            //Users
            ApplicationUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "jenny.rigsjo@live.com",
                NormalizedUserName = "jenny.rigsjo@live.com",
                FirstName = "Jenny",
                LastName = "Rigsjö",
                DateOfBirth = "19820320",
                Email = "jenny.rigsjo@live.com",
                NormalizedEmail = "jenny.rigsjo@live.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            modelBuilder.Entity<ApplicationUser>().HasData(user);


            //User-roles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleID,
                    UserId = user.Id,
                }
            );

        }
    }
}
