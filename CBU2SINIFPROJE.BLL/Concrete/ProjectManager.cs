﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IGenericRepository<Project> projectDal;

        public ProjectManager(IGenericRepository<Project> projectDal)
        {
            this.projectDal = projectDal;
        }
    
        public void AddProject(List<Actor> actors, List<OfficeWorker> officeWorkers, Company company, Project project)
        {
            projectDal.Add(project);
            officeWorkers.ToList().ForEach(item =>
            {
                item.Projects = new List<Project>
                {
                    project
                };
            });
            actors.ToList().ForEach(item =>
            {
                item.Projects = new List<Project>
                {
                    project
                };
            });
            project.Employees.AddRange(officeWorkers);
            project.Employees.AddRange(actors);

            company.Projects.Add(project);
        }
    }
}