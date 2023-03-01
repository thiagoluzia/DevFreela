using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder
                .HasKey(x => x.Id);

            builder
                 .HasOne(x => x.Freelancer) //one project has one freelancer
                .WithMany(x => x.FreelanceProjects)//one freelance has many projects
                .HasForeignKey(x => x.IdFreelancer)//foreign key of freelancer the project
                .OnDelete(DeleteBehavior.Restrict); //not delete

            builder
                .HasOne(x => x.Client)
                .WithMany(x => x.OwnerdProjects)
                .HasForeignKey(x => x.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
