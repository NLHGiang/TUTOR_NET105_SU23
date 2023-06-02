using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUTOR_NET105_SU23.B2.BUS.Services.Interfaces;
using TUTOR_NET105_SU23.B2.DAL.AppDbContext;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.BUS.Services.Implements
{
	public class UserServices : IUserServices
	{
		private readonly ApplicationDbContext _dbContext;

		public UserServices()
		{
			_dbContext = new ApplicationDbContext();
		}

		public async Task<List<User>> GetAll(int status)
		{
			return await _dbContext.Users.AsQueryable().Where(c=>c.Status == status).ToListAsync();
		}

		public async Task<User?> GetById(Guid id)
		{
			return await _dbContext.Users.AsQueryable().FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<bool> Create(User user)
		{
			try
			{
				await _dbContext.AddAsync(user);
				await _dbContext.SaveChangesAsync();

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<bool> Update(User user)
		{
			try
			{
				// Kiem tra user co ton tai trong DB khong?
				var listUser = await _dbContext.Users.ToListAsync();
				var userUpdate = listUser.FirstOrDefault(c => c.Id == user.Id);

				if (userUpdate != null)
				{
					// Update
					userUpdate.Email = user.Email;
					userUpdate.PhoneNumber = user.PhoneNumber;

					_dbContext.Update(userUpdate);
					await _dbContext.SaveChangesAsync();
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<bool> Delete(Guid id)
		{
			try
			{
				// Kiem tra user co ton tai trong DB khong?
				var listUser = await _dbContext.Users.ToListAsync();
				var userDelete = listUser.FirstOrDefault(c => c.Id == id);

				if (userDelete != null)
				{
					// Update
					userDelete.Status = 0;

					_dbContext.Update(userDelete);
					await _dbContext.SaveChangesAsync();

					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
