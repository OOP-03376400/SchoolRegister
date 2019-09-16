using System;
using System.Collections.Generic;

namespace SchoolRegister.Core.Domain
{
    public class TimeTable
    {
        public Guid GroupId { get; protected set; }
        public IDictionary <string, IDictionary<int,Subject> > Plan;
    }
}