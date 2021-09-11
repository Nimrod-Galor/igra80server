﻿using Igra80.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igra80.Data
{
    public interface IIgraRepo
    {
        bool SaveChanges();
        IEnumerable<Incidence> GetAllIncidences();
        Incidence GetIncidenceByCaId(int caid);
    }
}
