﻿using System.Collections.Generic;

using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
    public interface IOfficeWorkerService
    {
        EmployeeState IsFree(OfficeWorker officeWorker, Duration duration);
        EmployeeState IsFree(OfficeWorker officeWorker);
        IEnumerable<OfficeWorker> GetAllFreeOfficeWorker();
        IEnumerable<OfficeWorker> GetAllFreeOfficeWorker(Duration duration);
        List<OfficeWorker> GetMonthlyOfficeWorkers(List<Project> projects);
    }
}
