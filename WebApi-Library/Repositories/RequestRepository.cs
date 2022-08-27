using WebApi_Library.Data;
using WebApi_Library.Model.Entities;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private DataContext context;

        public RequestRepository(DataContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Request entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
