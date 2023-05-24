using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAWGestiune
{
    // partea de logIn - dar nu stiu daca trb neaparat
    internal class LoginManager
    {
        private string username;
        private string parola;

        public string Username { get => username; set => username = value; }
        public string Parola { get => parola; set => parola = value; }

        public LoginManager()
        {
            username = null;
            parola = null;
        }
        public LoginManager(string username,string parola)
        {
            this.username = username;
            this.parola = parola;
        }

    }
}
