using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRegister.Core.Domain
{
    public class Group : Entity
    {
        public char Sign { get; protected set; }
        public int Level { get; protected set; }
        //public YearNumber YearNumber { get; protected set; }
        private ISet<Student> _Students = new HashSet<Student>();
        public IEnumerable<Student> Students => _Students;
        public Teacher HeadTeacher { get; protected set; }
        public Guid HeadTeacherId { get; protected set; }
        public TimeTable TimeTable { get; set; }
        public ISet<Subject> _Subjects = new HashSet<Subject>();
        public IEnumerable<Subject> Subjects
        {
            get { return _Subjects; }
            set { _Subjects = new HashSet<Subject>(value); }
        }
        public Group()
        {
            
        }
        public Group(Teacher teacher)
        {
            HeadTeacherId = teacher.UserId;
            HeadTeacher = teacher;
        }

        public void AddStudent(Student student)
        {
            var Subject = Students.SingleOrDefault(x => x.Id == student.Id);
            if(Subject != null)
            {
                throw new DomainException(ErrorCodes.StudentAlreadyAdded,$"Student with Id: '{student.Id}' already added for Group: {this.Id}.");
            }
            _Students.Add(student);
        }   
        public void DeleteStudent(Student student)
        {
            var Subject = Students.SingleOrDefault(x => x.Id == student.Id);
            if(Subject != null)
            {
                throw new DomainException(ErrorCodes.StudentNotFound,$"Student with Id: '{student.Id}' for group: '{this.Id}' was not found.");
            }
            _Students.Remove(student);
        }     


        public void AddSubject(Subject subject)
        {
            var Subject = Subjects.SingleOrDefault(x => x.SubjectName == subject.SubjectName);
            if(Subject != null)
            {
                throw new DomainException(ErrorCodes.SubjectAlreadyAdded,$"Subject with name: '{subject.SubjectName}' already added for group: {this.Id}.");
            }
            _Subjects.Add(subject);

        }   
        public void DeleteSubject(Subject subject)
        {
            var Subject = Subjects.SingleOrDefault(x => x.SubjectName == subject.SubjectName);
            if(Subject == null)
            {
                throw new DomainException(ErrorCodes.SubjectNotFound,$"Subject named: '{subject.SubjectName}' for group: '{this.Id}' was not found.");
            }
            _Subjects.Remove(subject);

        }        

    }
}