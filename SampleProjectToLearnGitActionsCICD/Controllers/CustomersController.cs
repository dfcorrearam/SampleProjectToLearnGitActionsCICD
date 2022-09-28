using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProjectToLearnGitActionsCICD.Migrations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProjectToLearnGitActionsCICD.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext context;

        public CustomersController(CustomerContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll() => await context.Customers.ToArrayAsync();

        [HttpPost]
        public async Task<Customer> Add([FromBody] Customer c)
        {
            context.Customers.Add(c);
            await context.SaveChangesAsync();
            return c;
        }
    }
}
