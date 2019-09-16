using System;
using System.Collections.Generic;

namespace SchoolRegister.Core.Domain
{
    public class Parents
    {
        public  ISet<Student> Children = new HashSet<Student>();
        public  ISet<Parent> Guardians = new HashSet<Parent>();
        
    }
}