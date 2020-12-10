using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace agar_client.Game.Objects.State
{
	class PowerupStateA : IPowerupState
	{
		StatefulPowerupContext context;

		public PowerupStateA(StatefulPowerupContext context)
		{
			this.context = context;
			ModifyShape(context.Shape);

			var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
			timer.Tick += (sender, args) =>
			{
				timer.Stop();
				SetNextState(context);
			};
			timer.Start();
		}


		public void ModifyShape(Shape shape)
		{
			var s = context.Shape;
			var color = Color.FromRgb(195, 255, 195);
			int size = 30;
			s.Width = size;
			s.Height = size;
			s.Fill = new SolidColorBrush(color);

			context.text.Text = "A";
		}

		public void UseEffect()
		{
			LocalPlayer.Instance.changeStrategy(new PoisonedStrategy());
		}

		public void SetNextState(StatefulPowerupContext context)
		{
			context.SetState(new PowerupStateB(context));
		}
	}
}
