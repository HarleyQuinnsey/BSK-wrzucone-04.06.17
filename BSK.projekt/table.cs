using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK.projekt
{
    public class Table
    {
        public String name;
        public bool[] permissions = new bool[4];
        
        public Table(String name, bool insert, bool delete, bool update, bool show)
        {
            this.name = name;
            this.permissions[0] = insert;
            this.permissions[1] = delete;
            this.permissions[2] = update;
            this.permissions[3] = show;
        }
    }
}
