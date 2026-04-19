using ProjectHub.Core.Entities;

namespace ProjectHub.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetAllByProjectIdAsync(int projectId);
        Task<ProjectTask?> GetByIdAsync(int projectId, int taskId);
        Task<ProjectTask> CreateAsync(ProjectTask task);
        Task<ProjectTask?> UpdateAsync(int taskId, ProjectTask task);
        Task<bool> DeleteAsync(int taskId);
    }
}