﻿using DataProvider.DatabaseContexts;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataProvider.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetEmployeeByIdAsync(long empId)
    {
        return await _context
            .Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmployeeID == empId);
    }

}