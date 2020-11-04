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

<<<<<<< HEAD
        public override void FoodLogMessage()
        {
            Logger.Log("Small Food Decorator");
=======
        public Food getFood()
        {
            return decoratedFood;
>>>>>>> bf45dea72a3f6d6bf62c4579d9f8061f6fcecc27
        }
    }
}
