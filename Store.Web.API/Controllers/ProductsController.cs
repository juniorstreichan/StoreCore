using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interfaces.Services;
using Store.Domain.Models;

namespace Store.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController:Controller
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>>GetAll(){
            return new ObjectResult(service.GetAll());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Product>GetById(int id){
            return new ObjectResult(service.GetById(id));
        }
    }
}