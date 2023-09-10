using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.PersonelDTOs
{
    public class PersonelAddDTO
    {
        public string PersonelAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Password { get; set; }
        public int DepartmanId { get; set; }
        public int RoleId { get; set; }
    }
}
