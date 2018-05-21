using KalkulatorKalorii.Models.Database;
using KalkulatorKalorii.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Repositories
{
    public class MacronutrientRepository : IMacronutrientRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MacronutrientRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddMacronutrient(Macronutrient macronutrient)
        {
            if(macronutrient == null)
            {
                throw new Exception("Macronurient object cannot be null.");
            }

            _databaseContext.Macronutrients.Add(macronutrient);
            _databaseContext.SaveChanges();

            return macronutrient.MacronutrientId;
        }

        public List<Macronutrient> GetAll()
        {
            return _databaseContext.Macronutrients.ToList();
        }

        public Macronutrient GetMacronutrient(int macronutrientId)
        {
            if(macronutrientId <= 0)
            {
                throw new Exception("Id cannot be less than 0.");
            }

            return _databaseContext.Macronutrients.FirstOrDefault(macronutrient => macronutrient.MacronutrientId == macronutrientId);
        }

        public int UpdateMacronutrient(Macronutrient macronutrient)
        {
            if(macronutrient == null)
            {
                throw new Exception("Object cannot be null.");
            }

            _databaseContext.Macronutrients.Update(macronutrient);
            _databaseContext.SaveChanges();
            return macronutrient.MacronutrientId;
        }
    }
}
