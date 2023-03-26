using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.API.Helpers;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/prodcategories")]
    public class ProdCategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdCategoryController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("combo/{prodcategoriesId:int}")]
        public async Task<ActionResult> GetCombo(int prodcategoriesId)
        {
            return Ok(await _context.Products
                .Where(x => x.ProdCategoryId == prodcategoriesId)
                .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.ProdCategories
                .Include(x => x.Products)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var prodcategory = await _context.ProdCategories
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (prodcategory == null)
            {
                return NotFound();
            }

            return Ok(prodcategory);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ProdCategory prodcategory)
        {
            try
            {
                _context.Add(prodcategory);
                await _context.SaveChangesAsync();
                return Ok(prodcategory);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un producto/categoria con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(ProdCategory prodcategory)
        {
            try
            {
                _context.Update(prodcategory);
                await _context.SaveChangesAsync();
                return Ok(prodcategory);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un producto/categoria con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var prodcategory = await _context.ProdCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (prodcategory == null)
            {
                return NotFound();

            }

            _context.Remove(prodcategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}