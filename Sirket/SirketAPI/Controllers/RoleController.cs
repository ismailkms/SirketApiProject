using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListRole()
        {
            var values = _roleService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRole(RoleAddDTO roleAddDTO)
        {
            Role role = _mapper.Map<Role>(roleAddDTO);
            _roleService.Add(role);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdRole(int id)
        {
            var role = _roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(role);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                _roleService.Delete(role);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateRole(RoleUpdateDTO roleUpdateDTO)
        {
            Role role = _mapper.Map<Role>(roleUpdateDTO);
            var roleValue = _roleService.GetById(role.Id);
            if (roleValue == null)
            {
                return NotFound();
            }
            else
            {
                roleValue.RoleAdi = role.RoleAdi;
                _roleService.Update(roleValue);
                return Ok();
            }
        }

        [HttpGet("{roleAdi}")]
        public IActionResult GetByNameRole(string roleAdi)
        {
            var role = _roleService.GetByRoleName(roleAdi);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(role);
            }
        }
    }
}
