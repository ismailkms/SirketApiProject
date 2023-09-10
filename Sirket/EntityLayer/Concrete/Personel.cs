using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }
        public string PersonelAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Password { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
