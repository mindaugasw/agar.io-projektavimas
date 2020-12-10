using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace agar_client.Game
{
	class Logger
	{
		static TextBox textBox;

		static Dictionary<string, StreamWriter> fileStreams;

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
					textBox.AppendText(LogFormat(obj));
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

		public static void LogToFile(string file, object obj)
		{
			if (fileStreams == null)
				fileStreams = new Dictionary<string, StreamWriter>();

			if (!fileStreams.ContainsKey(file))
				fileStreams.Add(file, new StreamWriter(file, true));

			fileStreams[file].WriteLine(LogFormat(obj, false));
			fileStreams[file].Flush();
		}

		static string LogFormat(object obj, bool appendNewLine = true)
		{
			return $"{(appendNewLine ? "\n" : "")}{DateTime.Now.ToString("HH:mm:ss")}: {obj.ToString()}";
		}

	}
}
