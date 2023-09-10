using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace EntityLayer.Concrete
{
    public class Sirket
    {
        [Key]
        public int Id { get; set; }
        public string SirketAdi { get; set; }
        public virtual List<Departman> Departmans { get; set; }
    }
}
