// paveldi Food
using System;
using System.Collections.Generic;
using System.Text;

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
            GraphicsDrawer.RemoveShape(this.Shape);
            this.size = 30;

            Shape = GraphicsDrawer.CreateNewEllipse(size, color, Position);
            Logger.Log(color);
        }
    }
}
