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
    public class SirketManager : ISirketService
    {
        private readonly ISirketDal _sirketDal;
        private readonly IUowDal _uowDal;

        public SirketManager(ISirketDal sirketDal, IUowDal uowDal)
        {
            _sirketDal = sirketDal;
            _uowDal = uowDal;
        }

        public void Add(Sirket t)
        {
            _sirketDal.Create(t);
            _uowDal.Save();
        }

        public void Delete(Sirket t)
        {
            _sirketDal.Delete(t);
            _uowDal.Save();
        }

        public Sirket GetById(int id)
        {
            return _sirketDal.GetById(id);
        }

        public List<Sirket> GetList()
        {
            return _sirketDal.GetListAll();
        }

        public void Update(Sirket t)
        {
            _sirketDal.Update(t);
            _uowDal.Save();
        }
    }
}
