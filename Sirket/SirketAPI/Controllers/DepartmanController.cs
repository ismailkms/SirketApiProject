using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.DepartmanDTOs;
using DTOLayer.DTOs.SirketDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmanAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmanController : ControllerBase
    {   
        private readonly IDepartmanService _departmanService;
        private readonly IMapper _mapper;

        public DepartmanController(IDepartmanService departmanService, IMapper mapper)
        {
            _departmanService = departmanService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListDepartman()
        {
            var values = _departmanService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddDepartman(DepartmanAddDTO departmanAddDTO)
        {
            Departman departman = _mapper.Map<Departman>(departmanAddDTO);
            _departmanService.Add(departman);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdDepartman(int id)
        {
            var departman = _departmanService.GetById(id);
            if (departman == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(departman);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartman(int id)
        {
            var departman = _departmanService.GetById(id);
            if (departman == null)
            {
                return NotFound();
            }
            else
            {
                _departmanService.Delete(departman);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateDepartman(DepartmanUpdateDTO departmanUpdateDTO)
        {
            Departman departman = _mapper.Map<Departman>(departmanUpdateDTO);
            var departmanValue = _departmanService.GetById(departman.Id);
            if (departmanValue == null)
            {
                return NotFound();
            }
            else
            {
                departmanValue.DepartmanAdi = departman.DepartmanAdi;
                departmanValue.SirketId = departman.SirketId;
                _departmanService.Update(departmanValue);
                return Ok();
            }
        }
    }
}
