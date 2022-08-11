using System;
using Refit;
using System.Threading.Tasks;
using TestAppCC.API.Models;
using System.Collections.Generic;

namespace TestAppCC.API.Services
{
    public interface IEmployeeService
    {
        [Get("/employees")]
        Task<List<Employee>> Employees();
    }
}

