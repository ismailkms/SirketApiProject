using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfRoleRepository : GenericRepository<Role>, IRoleDal
    {
        public EfRoleRepository(Context context) : base(context)
        {
        }

        public Role GetByName(string roleAdi)
        {
            using (var c = new Context())
            {
                return c.Roles.FirstOrDefault(x => x.RoleAdi == roleAdi);
            }
        }
    }
}
