using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullname, string email, DateTime birthDate)
        {
            Fullname = fullname;
            Email = email;
            BirthDate = birthDate;
            Active = true;

            Skills = new List<UserSkill>();
            OwnerdProjects = new List<Project>();
            FreelanceProjects = new List<Project>();

        }

        public string Fullname { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }

        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnerdProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }

       


    }
}