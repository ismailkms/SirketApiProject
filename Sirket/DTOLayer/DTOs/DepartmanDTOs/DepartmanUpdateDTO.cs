using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.DepartmanDTOs
{
    public class DepartmanUpdateDTO
    {
        public int Id { get; set; }
        public string DepartmanAdi { get; set; }
        public int SirketId { get; set; }
    }
}
