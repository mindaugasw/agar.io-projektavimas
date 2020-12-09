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
			try
			{
				if(textBox != null)
                {
					textBox.AppendText($"\n{DateTime.Now.ToString("HH:mm:ss")}: {obj.ToString()}");
					Debug.WriteLine(obj);
					textBox.ScrollToEnd();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0} Exception caught.", ex);
			}
		}
		public static void Log()
		{
			textBox.AppendText("\n");
		}


	}
}
