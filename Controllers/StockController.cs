using los_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace los_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly DataContext _context;

        public StockController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = from stock in _context.Stock
                        join product in _context.Product on stock.productId equals product.id
                        where product.id == id
                        select new {
                            id = product.id,
                            name = product.name,
                            imageUrl = product.imageUrl,
                            price = product.price,
                            amount = stock.amount
                        };
           
            return Ok(query);
        }
    }
}
