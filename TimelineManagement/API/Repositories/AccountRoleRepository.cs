﻿using Microsoft.EntityFrameworkCore;
using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Models;

namespace TimelineManagement.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(TimelineManagementDbContext context) : base(context) { }
    public IEnumerable<string> GetRoleNamesByAccountGuid(Guid guid)
    {
        var result = _context.Set<AccountRole>()
            .Where(ar => ar.AccountGuid == guid)
            .Include(ar => ar.Role)
            .Select(ar => ar.Role!.Name);
        return result;
    }
}