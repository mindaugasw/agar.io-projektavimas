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

        private void setSize()
        {
            this.size = 5;
            GraphicsDrawer.MoveShape(this.Shape, this.Position);
        }
    }
}
