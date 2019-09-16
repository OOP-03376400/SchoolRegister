using System;

namespace SchoolRegister.Core.Domain
{
    public class Student
    {
        public Guid UserId { get; protected set; }
        public string FirstName { get; protected set; }
        public string SureName { get; protected set; }

    }
}