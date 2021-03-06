﻿using System;
using System.Collections.Generic;
using System.Linq;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IGenericRepository<Actor> genericRepository;
        private readonly IGenericRepository<Project> projectRepository;

        public ActorManager(IGenericRepository<Actor> genericRepository, IGenericRepository<Project> projectRepository)
        {
            this.genericRepository = genericRepository;
            this.projectRepository = projectRepository;
        }

        public void DeleteActor(Actor actor)
        {
            genericRepository.Delete(actor);
            //var projects = projectRepository.GetAll();
            //projects.ForEach(project =>
            //    project.Employees.RemoveAll(x => x is Actor && x.Id == actor.Id)
            //);
        }

        public IEnumerable<Actor> GetAllFreeActor()
        {
            List<Actor> all = genericRepository.GetAll();
            foreach (Actor item in all)
                if (IsFree(item) == EmployeeState.Bosta)
                    yield return item;
        }

        public IEnumerable<Actor> GetAllFreeActor(Duration duration)
        {
            List<Actor> all = genericRepository.GetAll();
            foreach (Actor item in all)
                if (IsFree(item, duration) == EmployeeState.Bosta)
                    yield return item;
        }

        public List<Actor> GetMonthlyActors(List<Project> projects)
        {
            List<Actor> result = new List<Actor>();
            List<Actor> actors = genericRepository.GetAll();
            foreach (Actor actor in actors)
                if (!actor.Projects.IsNull())
                    foreach (Project project in actor.Projects)
                        if (projects.Contains(project))
                        {
                            result.Add(actor);
                            break;
                        }

            return result.Distinct().ToList();
        }

        public EmployeeState IsFree(Actor actor, Duration duration)
        {
            if (!actor.Vacations.IsNull())
                foreach (Vacation item in actor.Vacations)
                    if (item.Duration.StartDate <= duration.StartDate && item.Duration.EndDate >= duration.EndDate)
                        return EmployeeState.Izinde;
            if (!actor.Projects.IsNull())
                foreach (Project item in actor.Projects)
                    if (item.Duration.StartDate <= duration.StartDate && item.Duration.EndDate >= duration.EndDate)
                        return EmployeeState.Calisiyor;
            return EmployeeState.Bosta;
        }
        public EmployeeState IsFree(Actor actor)
        {
            if (!actor.Vacations.IsNull())
                foreach (Vacation item in actor.Vacations)
                    if (item.Duration.StartDate <= DateTime.Now && item.Duration.EndDate >= DateTime.Now)
                        return EmployeeState.Izinde;
            if (!actor.Projects.IsNull())
                foreach (Project item in actor.Projects)
                    if (item.Duration.StartDate <= DateTime.Now && item.Duration.EndDate >= DateTime.Now)
                        return EmployeeState.Calisiyor;
            return EmployeeState.Bosta;
        }
    }
}
