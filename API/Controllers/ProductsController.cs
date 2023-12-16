using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var productsList = await _context.Products.ToListAsync();
            return productsList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductById(int id){
            return await _context.Products.FindAsync(id);
        }

    }
}