using DTO.Entities.Base;
using DTO.Utils;

namespace DTO
{
    public class User : BaseEntity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public User() { }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User(string password)
        {
            Password = password;
        }

        public async void HashPassword()
        {
            Password = await new HashUtils().HashString(Password);
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void MakeAdmin()
        {
            if (!IsAdmin)
            {
                IsAdmin = true;
            }
        }
    }
}