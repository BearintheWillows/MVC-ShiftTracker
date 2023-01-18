namespace ShiftTracker.Interfaces;

public interface IBaseCrudService<T> where T : class
{
	Task<T?>             GetAsync(int id);
	Task<IEnumerable<T>> GetAllAsync();
	Task<T>              AddAsync(T      entity);
	Task<T>              UpdateAsync(T   entity);
	Task                 DeleteAsync(int id);
}