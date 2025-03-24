using CaseManagementApp.Models;

public interface ICaseNoteRepository
{
    Task<List<CaseNote>> GetByCaseIdAsync(int caseId);
    Task<CaseNote?> GetByIdAsync(int id);
    Task AddAsync(CaseNote note);
    Task UpdateAsync(CaseNote note);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id); 
}
