﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleAdi { get; set; }
        public virtual List<Personel> Personels { get; set; }
    }
}
