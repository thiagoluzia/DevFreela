using System;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullname, string email)
        {
            Fullname = fullname;
            Email = email;
        }

        public string Fullname { get; private set; }
        public string Email { get; private set; }
    }
}
