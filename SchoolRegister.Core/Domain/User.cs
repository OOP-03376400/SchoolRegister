using System;
using System.Text.RegularExpressions;

namespace SchoolRegister.Core.Domain
{
    public class User : Entity
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected User()
        {
        }

        public User(Guid userId, string email, string username, string role, 
            string password, string salt)
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            SetRole(role);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }


        public void SetUsername(string username) 
        {
            //TODO validation
            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email) 
        {
            //TODO validation
            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            //TODO validation
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            //TODO validation
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}