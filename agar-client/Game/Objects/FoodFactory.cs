using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    class FoodFactory : AbstractFactory
    {
        public static FoodFactory Instance;
        public List<Food> food = new List<Food>();

        public FoodFactory()
        {
            if (Instance == null)
                Instance = this;
            else
                throw new Exception();
        }

        public override void createMapObjects()
        {
            for (int i = 0; i < 20; i++)
            {
                var newFood = new GreenFood();
                food.Add(newFood);
            }
        }
    }
}
