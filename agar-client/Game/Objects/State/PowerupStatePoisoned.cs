using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace agar_client.Game.Objects.State
{
	class PowerupStatePoisoned : IPowerupState
	{
		StatefulPowerupContext context;

		public PowerupStatePoisoned(StatefulPowerupContext context)
		{
			this.context = context;
			ModifyShape(context.Shape);

			var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
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
			var color = Color.FromRgb(255, 195, 195);
			int size = 25;
			s.Width = size;
			s.Height = size;
			s.Fill = new SolidColorBrush(color);

			context.text.Text = "P";
		}

		public void UseEffect()
		{
			LocalPlayer.Instance.changeStrategy(new PoisonedStrategy());
			LocalPlayer.Instance.Shape.Fill = new SolidColorBrush(Color.FromRgb(0, 100, 0));
		}

		public void SetNextState(StatefulPowerupContext context)
		{
			context.SetState(new PowerupStateSleep(context));
		}
	}
}
