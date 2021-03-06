﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        Task SetInitialData(UserDTO adminDto, List<string> roles);

        bool IsAuthenticated(UserDTO userDto);
    }
}
