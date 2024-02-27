using Application.Interfaces;
using AutoMapper;
using Domain.BaseEntites;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T, M> : IGenericRepository<T, M> where T : class where M : BaseModel
    {
        private readonly GardenCalendaryContext _context;
        private readonly Mapper _mapper;
        private readonly IAutomapperConfig _config;

        public GenericRepository(GardenCalendaryContext context, IAutomapperConfig config)
        {
            _context = context;
            _config = config;
            _mapper = _config.InitializeAutomapper();
        }

        public async Task<M> AddAsync(M model)
        {
            T entity = _mapper.Map<T>(model);
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<M>(entity);
        }

        public async Task UpdateAsync(int id, M model)
        {
            T entity = _mapper.Map<T>(model);
            T exist = await _context.Set<T>().FindAsync(id);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<M>> GetAllAsync()
        {
            List<T> values = await _context
                .Set<T>()
                .ToListAsync();
            var models = new List<M>();
            foreach (var entity in values)
            {
                models.Add(_mapper.Map<M>(entity));
            }
            return models;
        }

        public async Task<M> GetByIdAsync(int id)
        {
            return _mapper.Map<M>(await _context.Set<T>().FindAsync(id));
        }
    }
}
