namespace ShiftTracker.Helpers;

public static class LogResponseHelper
{
	public static string GetDBSuccess(Type T) => $"Successfully retrieved {T.Name} from database.";

	public static string CollectionCount(Type t, object obj) => $"{t.Name} collection count: {obj}";


	public static string GetDBError(Type t) => $"{t.Name} could not be found in database.";


	public static string PostDBError(Type t) => $"{t.Name} could not be posted to database.";

	public static string PostDBSuccess(Type t) => $"{t.Name} successfully posted to database.";
}