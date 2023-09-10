using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonelService : IGenericService<Personel>
    {
        Personel GetPersonelWithKullaniciAdiPassword(string kullaniciAdi, string password);
        List<Personel> GetPersonelWithRoleName();
    }
}
