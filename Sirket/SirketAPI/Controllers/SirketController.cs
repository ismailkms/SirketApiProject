using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.SirketDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SirketAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SirketController : ControllerBase
    {
        private readonly ISirketService _sirketService;
        private readonly IMapper _mapper;

        public SirketController(ISirketService sirketService, IMapper mapper)
        {
            _sirketService = sirketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListSirket()
        {
            var values = _sirketService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSirket(SirketAddDTO sirketAddDTO)
        {
            Sirket sirket = _mapper.Map<Sirket>(sirketAddDTO);
            _sirketService.Add(sirket);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdSirket(int id)
        {
            var sirket = _sirketService.GetById(id);
            if (sirket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(sirket);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSirket(int id)
        {
            var sirket = _sirketService.GetById(id);
            if (sirket == null)
            {
                return NotFound();
            }
            else
            {
                _sirketService.Delete(sirket);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateSirket(SirketUpdateDTO sirketUpdateDTO)
        {
            Sirket sirket = _mapper.Map<Sirket>(sirketUpdateDTO);
            var sirketValue = _sirketService.GetById(sirket.Id);
            if (sirketValue == null)
            {
                return NotFound();
            }
            else
            {
                sirketValue.SirketAdi = sirket.SirketAdi;
                _sirketService.Update(sirketValue);
                return Ok();
            }
        }
    }
}
