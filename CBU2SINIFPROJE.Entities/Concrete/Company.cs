﻿using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Company :EntityBase, ICompany
    {
        public string Name { get; set; }
        public Adress Adress { get; set; }
        public List<Project> Projects { get; set; }
    }
}
