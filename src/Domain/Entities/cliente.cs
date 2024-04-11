﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace Domain.Entities
{
    [Table("cliente")]
    public class cliente
    {
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public bool estatus { get; set; }
    }
}
