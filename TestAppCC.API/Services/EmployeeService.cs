using System;
using Refit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TestAppCC.API.Models;
using System.Collections.Generic;

namespace TestAppCC.API.Services
{
    public class EmployeeService
    {
        //private readonly HttpClient _httpClient;
        //private readonly IEmployeeService _employeeService;

        //public EmployeeService(Uri baseUrl, string token)
        //{
        //    _httpClient = new HttpClient(new HttpClientHandler()) { BaseAddress = baseUrl };
        //    //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    _employeeService = RestService.For<IEmployeeService>(_httpClient);
        //}

        //public async Task<List<Employee>> Employees()
        //{
        //    return await _employeeService.Employees().ConfigureAwait(false);
        //}
    }
}

