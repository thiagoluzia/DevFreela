using System;

namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            CreatedeAt = DateTime.Now;
        }

        public string Description { get; private set; }
        public DateTime CreatedeAt { get; private set; }
    }
}