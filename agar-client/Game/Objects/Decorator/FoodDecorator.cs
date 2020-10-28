// paveldi Food
using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    abstract class FoodDecorator : Food
    {
        protected Food decoratedFood;

        public FoodDecorator(Food decoratedFood) : base() {
            this.decoratedFood = decoratedFood;
        }
    }
}
