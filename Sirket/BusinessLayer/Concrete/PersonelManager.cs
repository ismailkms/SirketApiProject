using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;
        private readonly IUowDal _uowDal;

        public PersonelManager(IPersonelDal personelDal, IUowDal uowDal)
        {
            _personelDal = personelDal;
            _uowDal = uowDal;
        }

        public void Add(Personel t)
        {
            _personelDal.Create(t);
            _uowDal.Save();
        }

        public void Delete(Personel t)
        {
            _personelDal.Delete(t);
            _uowDal.Save();
        }

        public Personel GetById(int id)
        {
            return _personelDal.GetById(id);
        }

        public List<Personel> GetList()
        {
            return _personelDal.GetListAll();
        }

        public Personel GetPersonelWithKullaniciAdiPassword(string kullaniciAdi, string password)
        {
            return _personelDal.GetPersonelWithKullaniciAdiPassword(kullaniciAdi,password);
        }

        public List<Personel> GetPersonelWithRoleName()
        {
            return _personelDal.GetPersonelWithRoleName();
        }

        public void Update(Personel t)
        {
            _personelDal.Update(t);
            _uowDal.Save();
        }
    }
}
