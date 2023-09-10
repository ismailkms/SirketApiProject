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
    public class EfPersonelRepository : GenericRepository<Personel>, IPersonelDal
    {
        public EfPersonelRepository(Context context) : base(context)
        {
        }

        public Personel GetPersonelWithKullaniciAdiPassword(string kullaniciAdi, string password)
        {
            using (var c = new Context())
            {
                return c.Personels.Include(y => y.Role).FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Password == password);
            }
        }

        public List<Personel> GetPersonelWithRoleName()
        {
            using (var c = new Context())
            {
                return c.Personels.Include(x => x.Role).ToList();
            }
        }
    }
}
