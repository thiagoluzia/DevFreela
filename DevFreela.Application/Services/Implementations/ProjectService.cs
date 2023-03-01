using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Core.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;

            _connectionString = configuration.GetConnectionString("DevFreellaCs");
        }
        public int Create(CreateProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects.Add(project);

            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComments(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                 .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                 .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(x=>x.Client)
                .Include(x=>x.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project is null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.Fullname,
                project.Freelancer.Fullname
                );
            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
          
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();

            //_dbContext.SaveChanges();


            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";

                sqlConnection.Execute(script, new { status = project.Status, startedat = project.StartedAt, id = project.Id });
            }
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

            _dbContext.SaveChanges();
        }
    }
}