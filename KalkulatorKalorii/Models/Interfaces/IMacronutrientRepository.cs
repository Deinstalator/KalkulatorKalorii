using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Interfaces
{
    public interface IMacronutrientRepository
    {
        int AddMacronutrient(Macronutrient macronutrient);
        Macronutrient GetMacronutrient(int macronutrientId);
        int UpdateMacronutrient(Macronutrient macronutrient);
        List<Macronutrient> GetAll();
    }
}