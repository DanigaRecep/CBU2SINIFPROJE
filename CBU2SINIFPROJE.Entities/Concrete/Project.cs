﻿using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Interfaces;

namespace CBU2SINIFPROJE.Entities.Concrete
{
    public class Project :EntityBase, IProject
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public List<Employee> Employees { get; set; }
        public Company Company { get; set; }
        public Duration Duration { get; set; }
    }
}
