using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegFoods.Api.DTO;
using VegFoods.Core.Models;
using VegFoods.Core.Services;

namespace VegFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // DTO MAPPER OKANA SOR
            var categories = await _categoryService.GetAllAsync();
           
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // DTO MAPPER OKANA SOR
            CategoryDTO categoryDTO;
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDTO)
        {
            var newcategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));
            return Ok("Kategori Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return NoContent();

        }

        public async Task<IActionResult> GetAllWithRecipesAsync(int id)
        {
            var category = await _categoryService.GetAllWithRecipesAsync(id);
            return Ok(_mapper.Map<CategoryWithRecipesDTO>(category));
        }
    }
}
