using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipes();
    }
}
