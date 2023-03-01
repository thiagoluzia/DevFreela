using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<UserSkill> UserSkills { get; private set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region PROJECT
            /*
            modelBuilder.Entity<Project>()
                .HasKey(x => x.Id);


            modelBuilder.Entity<Project>()
                .HasOne(x => x.Freelancer) //one project has one freelancer
                .WithMany(x => x.FreelanceProjects)//one freelance has many projects
                .HasForeignKey(x => x.IdFreelancer)//foreign key of freelancer the project
                .OnDelete(DeleteBehavior.Restrict); //not delete

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Client)
                .WithMany(x => x.OwnerdProjects)
                .HasForeignKey(x => x.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
            */
            #endregion

            #region PROJECT COMMENT
            /*
            modelBuilder.Entity<ProjectComment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.IdProject);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.IdUser);
            */
            #endregion

            #region SKILL
            /*
            modelBuilder.Entity<Skill>()
                .HasKey(x => x.Id);
            */
            #endregion

            #region USER
            /*
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Skills)
                .WithOne()
                .HasForeignKey(x => x.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
            */
            #endregion

            #region USER SKILL
            /*
            modelBuilder.Entity<UserSkill>()
             .HasKey(x => x.Id);
            */
            #endregion

        }
    }
}