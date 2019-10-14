using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRegister.Core.Domain
{
    public class Student : Entity
    {
        public Guid UserId { get; protected set; }
        public Guid GroupId { get; protected set; }
        public Group Group { get; protected set; }
        public string FirstName { get; protected set; }
        public string SureName { get; protected set; }

        public ISet<Subject> _Subjects = new HashSet<Subject>();
        public IEnumerable<Subject> Subjects
        
        {
            get { return _Subjects; }
            set { _Subjects = new HashSet<Subject>(value); }
        }

        protected Student()
        {
            
        }
         public Student(string firstName,string sureName)
        {
            FirstName = firstName;
            SureName = sureName;
        }       
        public Student(User user)
        {
            UserId = user.Id;
        }

        public void SetGroup(Group group)
        {
            Group = group;
        }
        public void AddSubjectsFromGroup()
        {
            if(Group!= null)
            {
                var subjects = Group.Subjects;
            }
            throw new DomainException(ErrorCodes.StudentWithoutGroup,$"Student with name: '{FirstName},{SureName}' doesn't belong to any group.");
        }       
        public void AddSubject(Subject subject)
        {
            var Subject = Subjects.SingleOrDefault(x => x.SubjectName == subject.SubjectName);
            if(Subject != null)
            {
                throw new DomainException(ErrorCodes.SubjectAlreadyAdded,$"Subject with name: '{subject.SubjectName}' already added for student: {this.FirstName}.");
            }
            _Subjects.Add(subject);

        }   
        public void DeleteSubject(Subject subject)
        {
            var Subject = Subjects.SingleOrDefault(x => x.SubjectName == subject.SubjectName);
            if(Subject == null)
            {
                throw new DomainException(ErrorCodes.SubjectNotFound,$"Subject named: '{subject.SubjectName}' for student: '{this.FirstName}' was not found.");
            }
            _Subjects.Remove(subject);

        }        

    }
}