namespace ShiftTracker.Helpers;

public static class LogResponseHelper
{
	public static String GetDBSuccess(Type T)
	{
		return $"Successfully retrieved {T.Name} from database.";
	}
	
	public static string CollectionCount(Type t, Object obj)
	{
		return $"{t.Name} collection count: {obj}";
	}

	
	public static String GetDBError(Type t)
	{
		return $"{t.Name} could not be found in database.";
	}


	public static string PostDBError(Type t)
	{
		return $"{t.Name} could not be posted to database.";
	}

	public static string PostDBSuccess(Type t)
	{
		return $"{t.Name} successfully posted to database.";
	}
}