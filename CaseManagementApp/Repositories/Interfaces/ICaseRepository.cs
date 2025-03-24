using CaseManagementApp.Models;

public interface ICaseRepository
{
    Task<List<BrownsteinCase>> GetAllAsync();
    Task<BrownsteinCase?> GetByIdAsync(int id);
    Task AddAsync(BrownsteinCase newCase);
    Task UpdateAsync(BrownsteinCase updatedCase);
    Task DeleteAsync(int id);
}
