using System.Collections.Generic;

namespace SchoolRegister.Core.Domain
{
    public class School : Entity
    {
        public string SchoolName { get; protected set; }
        private ISet<Teacher> _teachers = new HashSet<Teacher>();
        private ISet<Subject> _subjects = new HashSet<Subject>();

        public IEnumerable<Teacher> Teachers => _teachers;
        public IEnumerable<Subject> Subjects => _subjects;
    }
}