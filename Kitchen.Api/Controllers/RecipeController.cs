using Kitchen.Api.Services;
using Kitchen.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService service;

        public RecipeController(IRecipeService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<ResponseModel<IEnumerable<Kitchen.Model.Recipe>>> GetRecipes()
        {
            var response = new ResponseModel<IEnumerable<Kitchen.Model.Recipe>>();

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

        [HttpGet]
        public async Task<ResponseModel<RecipeDetail>> GetRecipeById(string id)
        {
            var response = new ResponseModel<RecipeDetail>();
            try
            {
                response.Data = await service.GetRecipeDetail(id);
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
