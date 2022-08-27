namespace WebApi_Library.Repositories.Interfaces
{
    public interface IBaseRepository<Entity>
        where Entity : class
    {
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        void Save(Entity entity);
        void Update(Entity entity);
        void Delete(int id);
    }
}
