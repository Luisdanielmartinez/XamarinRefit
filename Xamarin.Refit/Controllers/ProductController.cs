
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xamarin.Refit.Models;
using Xamarin.Refit.Models.Context;

namespace Xamarin.Refit.Controllers
{
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GET()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{Id}", Name = "creado")]
        public ActionResult GetById(int Id)
        {
            var Product = _context.Products.FirstOrDefault(x => x.Id == Id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [HttpPost]
        public async Task <ActionResult> POST([FromBody] ImagenViewModel product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                var path = string.Empty;

                if (product.ImageFile != null && product.ImageFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Products", product.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Products/{product.ImageFile.FileName}";
                }


                return new CreatedAtRouteResult("creado", new { id = product.Id });
            }
            return BadRequest(ModelState);

        }

    }
}