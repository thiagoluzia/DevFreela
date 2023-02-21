using System;

namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public string Fullname { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

    }
}
