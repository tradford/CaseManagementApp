using CaseManagementApp.Models;

public interface IAttorneyRepository
{
    Task<List<Attorney>> GetAllAsync();
    Task<Attorney?> GetByIdAsync(int id);
    Task AddAsync(Attorney attorney);
    Task UpdateAsync(Attorney attorney);
    Task DeleteAsync(int id);
}

