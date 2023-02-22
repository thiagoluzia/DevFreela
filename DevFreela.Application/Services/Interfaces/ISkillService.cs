using System.Collections.Generic;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> Get();
        SkillViewModel GetById(int id);
        
    }
}
