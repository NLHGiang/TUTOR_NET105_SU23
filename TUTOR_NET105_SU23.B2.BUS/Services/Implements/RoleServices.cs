using Microsoft.EntityFrameworkCore;
using System.Data;
using TUTOR_NET105_SU23.B2.BUS.Services.Interfaces;
using TUTOR_NET105_SU23.B2.DAL.AppDbContext;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.BUS.Services.Implements
{
    public class RoleServices : IRoleServices
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleServices()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task<List<Role>> GetAll(int status)
        {
            return await _dbContext.Roles.AsQueryable().Where(c => c.Status == status).ToListAsync();
        }

        public async Task<Role?> GetById(Guid id)
        {
            return await _dbContext.Roles.AsQueryable().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Create(Role role)
        {
            try
            {
                await _dbContext.AddAsync(role);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> Update(Role role)
        {
            try
            {
                // Kiem tra role ton tai ?
                var existedRole = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == role.Id);

                if (existedRole != null)
                {
                    // Gan gia tri
                    existedRole.RoleName = role.RoleName;

                    // update
                    _dbContext.Update(existedRole);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                // Kiem tra role ton tai ?
                var existedRole = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == id);

                if (existedRole != null)
                {
                    // Gan gia tri
                    existedRole.Status = 0;

                    // update
                    _dbContext.Update(existedRole);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return false;
            }
        }
    }
}
