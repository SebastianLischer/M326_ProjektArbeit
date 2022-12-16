using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_ProjektArbeit.Model
{
    public class UserModel
    {
        public int UserModelID { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public string Fachrichtung { get; set; }
    }
}