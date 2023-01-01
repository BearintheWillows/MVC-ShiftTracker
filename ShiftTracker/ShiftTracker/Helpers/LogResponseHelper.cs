namespace ShiftTracker.Helpers;

public static class LogHelper
{
	public static String RetrieveSuccess(Type T)
	{
			return $"{T.Name} was successfully retrieved.";
	}
}