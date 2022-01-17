using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Base;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiBaseController<ICustomerService, Customer, DtoCustomer>
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService service) : base(service)
        {
            this.customerService = service;
        }



        [HttpGet("FindWithStringId")]
        [AllowAnonymous]
        public IResponse<DtoCustomer> FindWithStringId(string id)
        {
            

            try
            {
                var entity = customerService.Find(id);
                return entity;
            }
            catch (Exception ex)
            {
                return new Response<DtoCustomer>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };

            }



        }



    }
}
