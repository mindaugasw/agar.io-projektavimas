using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace agar_client.Game.Objects
{
    public class FoodFactory : AbstractFactory
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

        public override void createMapObjects(Dictionary<string, int> objNames)
        {
            if (objNames == null) {
                var r = GameManager.Random;
                var gCount = r.Next(0, 21);
                var rCount = 20 - gCount;

                for (int i = 0; i <= gCount; i += 2)
                {
                    Food f = new BigFoodDecorator(new GreenFoodDecorator()).getFood();
                    food.Add(f);
                    Add(f);
                    f = new SmallFoodDecorator(new GreenFoodDecorator()).getFood();
                    food.Add(f);
                    Add(f);
                }
                for (int i = 0; i <= rCount; i += 2)
                {
                    Food f = new BigFoodDecorator(new RedFoodDecorator()).getFood();
                    food.Add(f);
                    Add(f);
                    f = new SmallFoodDecorator(new RedFoodDecorator()).getFood();
                    food.Add(f);
                    Add(f);
                }
            }
            else
            {
                if(objNames.ContainsKey("GreenFood"))
                    for (int i = 0; i < objNames["GreenFood"]; i += 2)
                    {
                        Food f = new BigFoodDecorator(new GreenFoodDecorator()).getFood();
                        food.Add(f);
                        Add(f);
                        f = new SmallFoodDecorator(new GreenFoodDecorator()).getFood();
                        food.Add(f);
                        Add(f);
                    }
                if (objNames.ContainsKey("RedFood"))
                    for (int i = 0; i < objNames["RedFood"]; i += 2)
                    {
                        Food f = new BigFoodDecorator(new RedFoodDecorator()).getFood();
                        food.Add(f);
                        Add(f);
                        f = new SmallFoodDecorator(new RedFoodDecorator()).getFood();
                        food.Add(f);
                        Add(f);
                    }
            }

        }
    }
}
