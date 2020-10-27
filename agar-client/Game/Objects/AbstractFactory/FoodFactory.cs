﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
            var r = GameManager.Random;
            var gCount = r.Next(0, 21);
            var rCount = 20 - gCount;

            for (int i = 0; i < gCount; i++)
            {
                food.Add(new GreenFood());
            }
            for (int i = 0; i < rCount; i++)
            {
                food.Add(new RedFood());
            }
        }
    }
}