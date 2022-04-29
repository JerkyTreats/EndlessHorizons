
namespace Engine
{
	public class Log
	{
		GameAreas GameArea;

		public Log(GameAreas gameArea)
		{
			GameArea = gameArea;
		}

		/// <summary>
		/// Write message to log at default Log Level
		/// </summary>
		/// <param name="msg"></param>
		public void Write(string msg)
		{
			Logger.Log(GameArea, msg, Logger.DEFAULT_LOG_LEVEL);
		}

		/// <summary>
		/// Write message to log at specific Log Level
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="logLevel"></param>
		public void Write(string msg, int logLevel)
		{
			Logger.Log(GameArea, msg, logLevel);
		}

		/// <summary>
		/// Write an easy to see '***** HEADER *****' to log for easier log parsing
		/// </summary>
		/// <param name="msg"></param>
		public void Header(string msg)
		{
			string header = " **************** ";
			Write(header + msg.ToUpper() + header);
		}

		/// <summary>
		/// Write empty string to Log for Log parsing management
		/// </summary>
		public void LineBreak()
		{
			Write("");
		}
	}
}
