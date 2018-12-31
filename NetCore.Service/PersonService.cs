using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Service
{
    public class PersonService : IPersonService
    {
        private List<Person> _people { get; set; }
        public List<Person> People { get { return this._people; } }
        public Tuple<List<Person>, bool> GetAll(Query q)
        {
            Tuple<List<Person>, bool> result = null;
            try
            {
                var ps = new List<Person>();
                switch (q.FieldName)
                {
                    case "FirstName":
                        ps = _people.Where(x => x.FirstName == q.Value).ToList();
                        break;
                    case "LastName":
                        ps = _people.Where(x => x.LastName == q.Value).ToList();
                        break;
                    case "Address":
                        ps = _people.Where(x => x.Address == q.Value).ToList();
                        break;
                }
                result = new Tuple<List<Person>, bool>(ps, true);
            }
            catch (Exception)
            {
                result = new Tuple<List<Person>, bool>(null, false);
            }
            return result;
        }
        public bool Post(Person p)
        {
            var result = true;
            try
            {
                _people.Add(p);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public bool Put(Person np, Person op)
        {
            var result = true;
            try
            {
                var ps = _people.FirstOrDefault(x => x.FirstName == op.FirstName && x.LastName == op.LastName && x.Address == op.Address);
                if (ps != null)
                {
                    ps.FirstName = np.FirstName;
                    ps.LastName = np.LastName;
                    ps.Address = np.Address;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public bool Delete(Person p)
        {
            var result = true;
            try
            {
                var ps = _people.FirstOrDefault(x => x.FirstName == p.FirstName && x.LastName == p.LastName && x.Address == p.Address);
                if (ps != null)
                {
                    _people.Remove(p);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
