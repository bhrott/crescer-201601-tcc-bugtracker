﻿using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using BugTracker.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Service
{
    public class ApplicationService : IApplicationService
    {
        IApplicationRepository applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public ICollection<Application> FindByIDUser(int id)
        {
            return applicationRepository.FindByIDUser(id);
        }

        public Application FindByUrl(string url)
        {
            return applicationRepository.FindByUrl(url);
        }

        public void Add(Application application)
        {
            applicationRepository.Add(application);
        }

        public Application FindById(int id)
        {
            return applicationRepository.FindById(id);
        }

        public void Edit(Application application)
        {
            applicationRepository.Edit(application);
        }
    }
}
