using Application.Abstractions.Persistence;
using Core.Models.Common;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly string _filePath;
        private List<T> _entities;

        public GenericRepository(string filePath)
        {
            _filePath = filePath;
            _entities = LoadFromFile();
        }

        private List<T> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(_entities, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.Id = _entities.Count + 1;
            _entities.Add(entity);
            SaveToFile();
            return await Task.FromResult(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            SaveToFile();
            return await Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_entities);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(_entities.Find(e => e.Id == id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var index = _entities.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                _entities[index] = entity;
                SaveToFile();
            }
            return await Task.FromResult(entity);
        }
    }
}
