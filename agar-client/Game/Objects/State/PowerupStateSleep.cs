using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace agar_client.Game.Objects.State
{
	class PowerupStateSleep : IPowerupState
	{
		StatefulPowerupContext context;

		public PowerupStateSleep(StatefulPowerupContext context)
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
			var color = Color.FromRgb(169, 202, 255);
			int size = 20;
			s.Width = size;
			s.Height = size;
			s.Fill = new SolidColorBrush(color);

			context.text.Text = "S";
		}

		public void UseEffect()
		{
			LocalPlayer.Instance.changeStrategy(new SleepStrategy());
		}

		public void SetNextState(StatefulPowerupContext context)
		{
			var x = GameManager.Random.NextDouble();
			if (x < 0.5)
				context.SetState(new PowerupStateNormal(context));
			else
				context.SetState(new PowerupStateBoost(context));
		}
	}
}
