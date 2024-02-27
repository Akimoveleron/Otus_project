using Domain.BaseEntites;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T, M> where T : class where M : BaseModel
    {
        Task<M> GetByIdAsync(int id);
        Task<List<M>> GetAllAsync();
        Task<M> AddAsync(M model);
        Task UpdateAsync(int id, M model);
        Task DeleteAsync(int id);
    }
}
