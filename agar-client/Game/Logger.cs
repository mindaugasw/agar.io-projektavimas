using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;

namespace agar_client.Game
{
	class Logger
	{
		static TextBox textBox;

		public Logger(TextBox logTextbox)
		{
			textBox = logTextbox;
		}

		public static void Log(object obj)
		{
			textBox.AppendText($"\n{DateTime.Now.ToString("HH:mm:ss")}: {obj.ToString()}");
			Debug.WriteLine(obj);
			textBox.ScrollToEnd();
		}
		public static void Log()
		{
			textBox.AppendText("\n");
		}


	}
}
