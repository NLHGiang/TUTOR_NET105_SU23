using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.BUS.Services.Interfaces
{
    public interface IRoleServices
    {
        public Task<List<Role>> GetAll(int status);
        public Task<Role?> GetById(Guid id);
        public Task<bool> Create(Role Role);
        public Task<bool> Update(Role Role);
        public Task<bool> Delete(Guid id);
    }
}
