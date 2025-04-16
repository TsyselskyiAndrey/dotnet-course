using Application.Abstractions.Persistence;
using Core.Models.Common;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly string _filePath;
        private List<T> _entities;
        private readonly object _lockObj = new();

        public GenericRepository(string filePath)
        {
            _filePath = filePath;
            _entities = LoadFromFile();
        }

        private List<T> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }

        private async Task SaveToFileAsync()
        {
            var json = JsonSerializer.Serialize(_entities, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<T> CreateAsync(T entity)
        {
            lock (_lockObj)
            {
                entity.Id = _entities.Count + 1;
                _entities.Add(entity);
            }

            await SaveToFileAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            lock (_lockObj)
            {
                _entities.Remove(entity);
            }

            await SaveToFileAsync();
            return entity;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<T>>(_entities.ToList());
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return Task.FromResult(_entities.FirstOrDefault(e => e.Id == id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            lock (_lockObj)
            {
                var index = _entities.FindIndex(e => e.Id == entity.Id);
                if (index != -1)
                {
                    _entities[index] = entity;
                }
            }

            await SaveToFileAsync();
            return entity;
        }
    }
}
