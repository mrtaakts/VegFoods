using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VegFoods.Api.DTO;
using VegFoods.Core.Models;
using VegFoods.Core.Services;

namespace VegFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _mapper = mapper;
            _recipeService = recipeService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var recipes = await _recipeService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<RecipeDTO>>(recipes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWithIngreById(int id)
        {
            
            var recipe = await _recipeService.GetWithIngreById(id);

            return Ok(_mapper.Map<RecipeWithIngredientsDTO>(recipe));


        }

        // [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetById(int id)
        {
            /*
            RecipeWithIngredientsDTO recipeWithIngredientsDTO;
            
            return Ok(_mapper.Map<RecipeWithIngredientsDTO>(recipe));
            */
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Save(RecipeDTO recipeDTO)
        {
            var newrecipe = await _recipeService.AddAsync(_mapper.Map<Recipe>(recipeDTO));

            return Created(string.Empty, _mapper.Map<RecipeDTO>(newrecipe));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var recipe = _recipeService.GetByIdAsync(id).Result;
            _recipeService.Remove(recipe);
            return Ok("Tarif Başarıyla Silindi");

        }

     
    }
}
