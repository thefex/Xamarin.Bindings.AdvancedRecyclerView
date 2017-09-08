using System;
namespace XamarinMvvmCross_MeetupSample.Core
{

	class SampleBasedExceptionGuard : IExceptionHandler
	{
		public bool HandleException(Exception e)
		{
			return false;
		}
	}
}
