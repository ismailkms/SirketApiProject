using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace EntityLayer.Concrete
{
    public class Departman
    {
        [Key]
        public int Id { get; set; }
        public string DepartmanAdi { get; set; }
        public int SirketId { get; set; }
        public virtual Sirket Sirket { get; set; }
        public virtual List<Personel> Personels { get; set; }
    }
}
