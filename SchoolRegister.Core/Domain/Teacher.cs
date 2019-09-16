using System;

namespace SchoolRegister.Core.Domain
{
    public class Teacher
    {
        public Guid UserId { get; protected set; }
        public string FirstName { get; protected set; }
        public string SureName { get; protected set; }
        
    }
}