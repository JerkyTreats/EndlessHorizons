using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine
{
	public enum GameAreas {
		Camera,
		Temporary,
		Mesh
	}

	public class Logger
	{
		public static int DEFAULT_LOG_LEVEL = 1;

		private static Logger m_instance;
		private static readonly object m_padlock = new object();

		public HashSet<GameAreas> LoggingEnabled { get; set; }
		public int LogLevel { get; set; }
		//public string LogSaveLocation { get; set; }

		Logger()
		{
			LoggingEnabled = new HashSet<GameAreas>();
			LogLevel = 1;
		}

		/// <summary>
		/// Get Logger singleton instance
		/// </summary>
		public static Logger Instance
		{
			get
			{
				lock (m_padlock)
				{
					if (m_instance == null)
						m_instance = new Logger();
					return m_instance;
				}
			}
		}
		
		public static void Log(GameAreas gameArea, string msg, int logLevel)
		{
			if (Instance.LoggingEnabled.Contains(gameArea) && logLevel <= Instance.LogLevel)
				WriteToLog(msg);
		}

		private static void WriteToLog(string msg)
		{
			Debug.Log(msg);
		}
	}
}
