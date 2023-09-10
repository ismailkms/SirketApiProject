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
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        private readonly IUowDal _uowDal;

        public RoleManager(IRoleDal roleDal, IUowDal uowDal)
        {
            _roleDal = roleDal;
            _uowDal = uowDal;
        }

        public void Add(Role t)
        {
            _roleDal.Create(t);
            _uowDal.Save();
        }

        public void Delete(Role t)
        {
            _roleDal.Delete(t);
            _uowDal.Save();
        }

        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }

        public Role GetByRoleName(string roleAdi)
        {
            return _roleDal.GetByName(roleAdi);
        }

        public List<Role> GetList()
        {
            return _roleDal.GetListAll();
        }

        public void Update(Role t)
        {
            _roleDal.Update(t);
            _uowDal.Save();
        }
    }
}
