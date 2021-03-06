﻿using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface ITeacherDbService : ICommonManyToManyEditService<SubjectTeachersDb, string, string[]>
    {
    }
}
