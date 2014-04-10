using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeySeeMonkeyDo
{
    public class User
    {
        public string Id { get; set; }

        public User(string name)
        {
            this.Id = name;
        }
    }
}
