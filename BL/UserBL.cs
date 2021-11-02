using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IBL
    {
        private IRepo _repo;

        public UserBL(IRepo repo)
        {
            _repo = repo;
        }
    }
}