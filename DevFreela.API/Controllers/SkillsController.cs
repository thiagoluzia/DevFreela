using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase 
    {
        private readonly ISkillService _skillsService;
        public SkillsController(ISkillService skillsService)
        {
            _skillsService = skillsService;
        }

        // api/skills
        [HttpGet]
        public IActionResult Get()
        {
            var skills = _skillsService.Get();

            return Ok(skills);
        }

        // api/skills/1
        [HttpGet("{id}")]
        public IActionResult GedById(int id)
        {
            var skill = _skillsService.GetById(id);

            if (skill is null)
            {
                return NotFound();
            } 

            return Ok(skill);
        }

    }
}
