using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    class FoodFactory : AbstractFactory
    {
        public List<Food> food = new List<Food>();

        public FoodFactory()
        {
        }

        public override List<Food> createFoodObjects()
        {
            for (int i = 0; i < 20; i++)
            {
                var newFood = new GreenFood();
                food.Add(newFood);
            }

            return food;
        }
        
    }
}
