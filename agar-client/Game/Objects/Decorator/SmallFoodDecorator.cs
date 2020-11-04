// paveldi Food
using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    class SmallFoodDecorator : FoodDecorator
    {
        public SmallFoodDecorator(Food decoratedFood) : base(decoratedFood)
        {
            this.setSize();
        }

        public void setSize()
        {
            decoratedFood.Shape.Width = 10;
            decoratedFood.Shape.Height = 10;
        }

        public Food getFood()
        {
            return decoratedFood;
        }
    }
}
