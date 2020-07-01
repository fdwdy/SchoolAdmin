﻿using System;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface ISubjectService : ICommonService<Subject>, IDisposable
    {
        Task<bool> FindByName(string name);
    }
}
