using ImageReatedWork.Data;
using ImageReatedWork.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageReatedWork.Repositories
{
    public interface IProfileRepo
    {
        Task<bool> AddProfileAsync(Profile p);
        Task DeleteProfileAsync(Profile p);
        Task<bool> UpdateProfileAsync(Profile p);
        Task<IList<Profile>> GetProfilesAsync();
        Task<Profile> GetProfileByIdAsync(int id);
    }

    public class ProfileRepo : IProfileRepo
    {
        private readonly AppDbContext db;

        public ProfileRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddProfileAsync(Profile p)
        {
          await db.TblProfile.AddAsync(p);
            return await SaveAndChange();
        }

        public Task DeleteProfileAsync(Profile p)
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> GetProfileByIdAsync(int id)
        => await db.TblProfile.FirstOrDefaultAsync(ob=> ob.Id == id);

        public Task<IList<Profile>> GetProfilesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProfileAsync(Profile p)
        {
            db.TblProfile.Update(p);
            return await SaveAndChange();
        }

        private async Task<bool> SaveAndChange()
        {
            return await db.SaveChangesAsync() > 0;
        }
    }
}
