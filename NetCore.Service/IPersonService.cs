using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Service
{
    public interface IPersonService
    {
        List<Person> People { get; }
        Tuple<List<Person>, bool> GetAll(Query q);
        bool Post(Person p);
        bool Put(Person np, Person op);
        bool Delete(Person p);
    }
}
