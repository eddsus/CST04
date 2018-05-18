using DataManager.DataBases;
using SharedDataTypes;
using System.Collections.Generic;
using System.Linq;


namespace DataManager
{
    public class DH_MainDb : DataHandler
    {
        MainChocolateCustomizerEntities mainDb = new MainChocolateCustomizerEntities();

        

        public List<Ingredient> QueryAllIngredients()
        {
            
            return mainDb.Ingredients.Select(i => new Ingredient()
            {
                IngredientId = i.ID_Ingredients,
                Description = i.Description,
                Name = i.Name,
                Price = i.Price,
                Type = i.Type,
                UnitType = i.UnitType,
                Available = i.Availability
            }).ToList();
        }

        public bool InsertIngredient(Ingredient newIngredient)
        {

            mainDb.Ingredients.Add(new Ingredients()
            {
                ID_Ingredients = newIngredient.IngredientId,
                Name = newIngredient.Name,
                Description = newIngredient.Description,
                Price = newIngredient.Price,
                Availability = newIngredient.Available,
                Type = newIngredient.Type,
                UnitType = newIngredient.UnitType
            });
            return mainDb.SaveChanges() > 0;
        }



    }
}
