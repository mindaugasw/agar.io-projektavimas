// paveldi Food
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace agar_client.Game.Objects
{
    class BigFoodDecorator : FoodDecorator
    {
        public BigFoodDecorator(Food decoratedFood) : base(decoratedFood)
        {
            this.setSize();
        }

        public void setSize()
        {
            decoratedFood.Shape.Width = 17;
            decoratedFood.Shape.Height = 17;
        }
    }
}
