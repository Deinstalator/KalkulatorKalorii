using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalkulatorKalorii.Models;
using KalkulatorKalorii.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalkulatorKalorii.Controllers
{
    [Produces("application/json")]
    [Route("api/Macronutrients")]
    public class MacronutrientsController : Controller
    {
        private readonly IMacronutrientRepository _macronutrientRepository;

        public MacronutrientsController(IMacronutrientRepository macronutrientRepository)
        {
            _macronutrientRepository = macronutrientRepository;
        }

        [HttpPost("[action]")]
        public IActionResult AddMacronutrient([FromBody] Macronutrient macronutrient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _macronutrientRepository.AddMacronutrient(macronutrient);

            return new JsonResult(macronutrient.MacronutrientId);
        }
    }
}