using System;
using NuGet;
using cloudCommerce.Core.Logging;
using Log = cloudCommerce.Core.Logging;

namespace cloudCommerce.Core.Packaging
{
	internal class NugetLogger : NuGet.ILogger
	{
		private readonly Log.ILogger _logger;

		public NugetLogger(Log.ILogger logger)
		{
			_logger = logger;
		}

		public void Log(MessageLevel level, string message, params object[] args)
		{
			switch (level)
			{
				case MessageLevel.Debug:
					//_logger.Debug(String.Format(message, args));
					break;
				case MessageLevel.Error:
					_logger.Error(String.Format(message, args));
					break;
				case MessageLevel.Info:
					_logger.Information(String.Format(message, args));
					break;
				case MessageLevel.Warning:
					_logger.Warning(String.Format(message, args));
					break;
			}
		}

		public FileConflictResolution ResolveFileConflict(string message)
		{
			return FileConflictResolution.OverwriteAll;
		}
	}
}
