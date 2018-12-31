using System;

namespace NetCore.Service
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string Address { get; set; }
    }
}
