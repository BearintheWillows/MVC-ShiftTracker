namespace ShiftTracker.Helpers;

public static class LogResponseHelper
{
	public static String GetDBSuccess(Type T)
	{
		return $"Successfully retrieved {T.Name} from database.";
	}
	
	public static string CollectionCount(Type T, Object obj)
	{
		return $"{T.Name} collection count: {obj}";
	}

	
	public static String GetDBError(Type T)
	{
		return $"{T.Name} could not be found in database.";
	}
	
	

}