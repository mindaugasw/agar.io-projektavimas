﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace agar_client.Game
{
	public class ConfigManager
	{
		static Dictionary<string, string> configDict;
		static bool initialized = false;

		/// <summary>
		/// Get config value by key.
		/// </summary>
		public static T Get<T>(string key)
		{
			if (!initialized)
				Initialize();

			if (!configDict.ContainsKey(key))
				throw new Exception($"Key does not exist: {key}");

			return (T)Convert.ChangeType(configDict[key], typeof(T));
		}

		static void Initialize()
		{
			configDict = new Dictionary<string, string>();

			var dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
			var mainConfigFile = Path.Combine(dir, "config.xml");
			var localConfigFile = Path.Combine(dir, "config.local.xml");

			if (File.Exists(mainConfigFile))
				ReadConfigFile(mainConfigFile);

			if (File.Exists(localConfigFile))
				ReadConfigFile(localConfigFile);
			
			initialized = true;
		}

		static void ReadConfigFile(string path)
		{
			XDocument doc = XDocument.Load(path);

			foreach (var e in doc.Descendants("add"))
				configDict[e.Attribute("key").Value] = e.Attribute("value").Value;
		}
	}
}
