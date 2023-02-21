using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Api .Net Core for game", "API for management games",1,1,10000),
                new Project("Api .Net Core for school", "API for management school",1,1,20000),
                new Project("Api .Net Core for finance", "API for management finance",1,1,30000)
            };

            Users = new List<User>
            {
                new User("Thiago Moura","thiago@gmail.com", new DateTime(1989,08,23)),
                new User("Tarcyla Moura","tarcyla@gmail.com", new DateTime(2008,06,08))
            };

            Skills = new List<Skill>
            {
                new Skill("Asp .Net"),
                new Skill("C#"),
                new Skill("SQL")
            };

            
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}