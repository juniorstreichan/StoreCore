using System;
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
        public ActionResult<IEnumerable<Product>> GetAll(){
            return Ok(service.GetAll());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id){
            return Ok(service.GetById(id));
        }
        
        [HttpGet("q")]
        public ActionResult<Product> GetByDescription([FromQuery] string description){
            return Ok(service.GetProdctsByDescription(description));
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product){
            var newProduct = service.Add(product);
            return Created("/"+newProduct.Id.ToString(),newProduct);
        }

        [HttpPut]
        public ActionResult<Product> Pup([FromBody] Product product){
            var newProduct = service.Change(product);
            return Ok(newProduct);
        }


        [HttpDelete("{id}")]
        public ActionResult<object> Delete(int id){
            service.Remove(id);
            return Ok();
        }


    }
}