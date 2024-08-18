using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList();
            return Ok(stocks);
        }
        [HttpGet("{id}")] 
        public IActionResult GetById([FromRoute] int id){
            // if we just use id, the best option for method is "find" but also firstordefault could be using 
            var stock = _context.Stock.Find(id);

            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}