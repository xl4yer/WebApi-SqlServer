using Microsoft.AspNetCore.Mvc;
using WebApi_SqlServer.Models;
using WebApi_SqlServer.Services;

namespace WebApi_SqlServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        CustomerServices xservices;

        public CustomerController(CustomerServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        public async Task<List<Customer>> GetCustomer()
        {
            var ret = await xservices.GetCustomer();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddCustomer([FromBody] Customer _customer)
        {
            var ret = await xservices.AddCustomer(_customer);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateCustomer([FromBody] Customer _customer)
        {
            var ret = await xservices.UpdateCustomer(_customer);
            return ret;
        }

        [HttpDelete]
        public async Task<int> DeleteCustomer([FromBody] Customer _customer)
        {
            var ret = await xservices.DeleteCustomer(_customer);
            return ret;
        }
    }
}
