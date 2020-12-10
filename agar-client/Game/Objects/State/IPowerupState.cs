using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace agar_client.Game.Objects.State
{
	interface IPowerupState
	{
		void ModifyShape(Shape shape);

		public void UseEffect();

		public void SetNextState(StatefulPowerupContext context);
	}
}
