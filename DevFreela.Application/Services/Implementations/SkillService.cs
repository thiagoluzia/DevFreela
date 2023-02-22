using System.Collections.Generic;
using System.Linq;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SkillViewModel> Get()
        {
            var skills = _dbContext.Skills;

            var skillViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skillViewModel;
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
