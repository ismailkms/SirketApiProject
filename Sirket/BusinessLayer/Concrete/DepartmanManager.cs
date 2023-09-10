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
    public class DepartmanManager : IDepartmanService
    {
        private readonly IDepartmanDal _departmanDal;
        private readonly IUowDal _uowDal;

        public DepartmanManager(IDepartmanDal departmanDal, IUowDal uowDal)
        {
            _departmanDal = departmanDal;
            _uowDal = uowDal;
        }

        public void Add(Departman t)
        {
            _departmanDal.Create(t);
            _uowDal.Save();
        }

        public void Delete(Departman t)
        {
            _departmanDal.Delete(t);
            _uowDal.Save();
        }

        public Departman GetById(int id)
        {
            return _departmanDal.GetById(id);
        }

        public List<Departman> GetList()
        {
            return _departmanDal.GetListAll();
        }

        public void Update(Departman t)
        {
            _departmanDal.Update(t);
            _uowDal.Save();
        }
    }
}
