﻿using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.Entities.Interfaces
{
    public interface IActor
    {
        Field Field { get; set; }
        List<Project> Projects { get; set; }
    }
}