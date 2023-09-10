using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.PersonelDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;
        private readonly IMapper _mapper;

        public PersonelController(IPersonelService personelService, IMapper mapper)
        {
            _personelService = personelService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListPersonel()
        {
            var values = _personelService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddPersonel(PersonelAddDTO personelAddDTO)
        {
            Personel personel = _mapper.Map<Personel>(personelAddDTO);
            _personelService.Add(personel);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdPersonel(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(personel);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePersonel(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }
            else
            {
                _personelService.Delete(personel);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdatePersonel(PersonelUpdateDTO personelUpdateDTO)
        {
            Personel personel = _mapper.Map<Personel>(personelUpdateDTO);
            var personelValue = _personelService.GetById(personel.Id);
            if (personelValue == null)
            {
                return NotFound();
            }
            else
            {
                personelValue.PersonelAdi = personel.PersonelAdi;
                personelValue.KullaniciAdi = personel.KullaniciAdi;
                personelValue.Password = personel.Password;
                personelValue.DepartmanId = personel.DepartmanId;
                personelValue.RoleId = personel.RoleId;
                _personelService.Update(personelValue);
                return Ok();
            }
        }

        [HttpGet("{kullaniciAdi}/{password}")]
        public IActionResult GetPersonelWithPassword(string kullaniciAdi, string password)
        {
            var personel = _personelService.GetPersonelWithKullaniciAdiPassword(kullaniciAdi, password);
            if (personel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(personel);
            }
        }

        [HttpGet]
        public IActionResult GetPersonelWithRole()
        {
            var personel = _personelService.GetPersonelWithRoleName();
            if (personel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(personel);
            }
        }
    }
}
