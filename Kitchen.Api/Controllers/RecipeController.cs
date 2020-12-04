using Kitchen.Api.Services;
using Kitchen.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Kitchen.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService service;

        public RecipeController(IRecipeService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<ResponseModel<Kitchen.Model.Recipe>> GetRecipes()
        {
            var response = new ResponseModel<Kitchen.Model.Recipe>();

            try
            {
                response.Data = await service.GetRecipes();
                response.Status = 200;
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
