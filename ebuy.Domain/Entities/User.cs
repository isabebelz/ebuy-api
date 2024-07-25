namespace ebuy.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Name { get; private set; } 
        public string Email { get; private set; }
        public string Password { get; private set; } 
        public Guid? ResetPassword { get; private set; }
        public DateTime? DateResetPassword { get; private set; }
        public bool Active { get; private set; }

        public User(string name, string email, string password, bool active)
        {
            Name = name;
            Email = email;
            Password = password;
            Active = active;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void UpdateActive(bool active)
        {
            Active = active;
        }
    }
}
