using System;
namespace XamarinMvvmCross_MeetupSample.Core
{
	public class ExceptionGuardService
	{
		readonly IExceptionHandler _exceptionHandler;

		public ExceptionGuardService(IExceptionHandler exceptionHandler)
		{
			_exceptionHandler = exceptionHandler;
		}

		public void OnException(Exception e)
		{
			if (!_exceptionHandler.HandleException(e))
				LogException(e);
		}

		private void LogException(Exception e)
		{
			System.Diagnostics.Debug.WriteLine($"Message {e.Message}, {Environment.NewLine}StackTrace: {e.StackTrace}");
		}
	}
}
