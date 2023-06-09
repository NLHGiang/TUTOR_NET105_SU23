using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.BUS.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<List<User>> GetAll(int status);
        public Task<User?> GetById(Guid id);
        public Task<bool> Create(User user);
        public Task<bool> Update(User user);
        public Task<bool> Delete(Guid id);
    }
}
