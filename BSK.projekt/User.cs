using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK.projekt
{
    public class User
    {
        public String name { get; }
        public List<Table> tables { get; }

        public User(int i)
        {
            tables = new List<Table>();
            this.name = "uzytkownik " + i;
        }

        public void addTable(string name, bool insert, bool delete, bool update, bool show)
        {
            tables.Add(new Table(name, insert, delete, update, show));
        }
    }
}
