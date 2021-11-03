using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DBRepo : IRepo
    {
        private UserDB _context;

        public DBRepo(UserDB context)
        {
            _context = context;
        }
    }
}