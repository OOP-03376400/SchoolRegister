using System.Collections.Generic;

namespace SchoolRegister.Core.Domain
{
    public class Group : Entity
    {
        private ISet<Student> _students = new HashSet<Student>();
        public char Sign { get; protected set; }
        public int Level { get; protected set; }
        public YearNumber YearNumber { get; protected set; }
        public IEnumerable<Student> Students => _students;
        public Teacher HeadTeacher { get; protected set; }
        public TimeTable TimeTable { get; set; }



    }
}