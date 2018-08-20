﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceJ.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime DtInclusao { get; set; }

        public DateTime? DtAlteracao { get; set; }
    }
}
