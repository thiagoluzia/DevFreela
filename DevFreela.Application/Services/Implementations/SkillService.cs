using System.Collections.Generic;
using System.Linq;
using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;

            _connectionString = configuration.GetConnectionString("DevFreellaCs");
        }

        public List<SkillViewModel> Get()
        {
            //Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList(); 
            }

            //var skills = _dbContext.Skills;

            //var skillViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id, s.Description))
            //    .ToList();

            //return skillViewModel;
        }

        public SkillViewModel GetById(int id)
        {
            var skill = _dbContext.Skills.FirstOrDefault(s => s.Id == id);

            if (skill is null) return null;

            var skillViewModel = new SkillViewModel(
                skill.Id,
                skill.Description
                );

            return skillViewModel;

        }
    }
}
