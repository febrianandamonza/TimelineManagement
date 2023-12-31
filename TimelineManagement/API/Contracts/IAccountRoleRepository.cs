﻿using TimelineManagement.Models;

namespace TimelineManagement.Contracts;

public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
{
    IEnumerable<string> GetRoleNamesByAccountGuid(Guid guid);
}