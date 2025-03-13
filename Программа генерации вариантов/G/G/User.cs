using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    internal class User
    {
       public int id { get; set; }
        public string Login { get { return login; } set { login = value; } }
         public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
       public string login, pass;

        public User() { }

        public User (int id, string login, string pass)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
        }
    }
}
