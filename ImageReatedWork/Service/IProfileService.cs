using ImageReatedWork.Helper;
using ImageReatedWork.Models;
using ImageReatedWork.Repositories;

namespace ImageReatedWork.Service
{
    public interface IProfileService
    {
        public Task<bool> Add(Profile p);
        public Task<bool> Update(int id,Profile p);
    }

    public class ProfilService : IProfileService
    {
        private readonly IProfileRepo repo;

        public ProfilService(IProfileRepo repo)
        {
            this.repo = repo;
        }
        public async Task<bool> Add(Profile p)
        {
           return await  repo.AddProfileAsync(p);
        }

        public async Task<bool> Update(int id, Profile p)
        {
            Profile exist= await repo.GetProfileByIdAsync(id);
            if(exist==null)
                return false;
            ImageHelper.DeleteImage(exist.ImagePath);
            exist.Name = p.Name;
            exist.Bio=p.Bio;
            exist.ImagePath=p.ImagePath;
            return await repo.UpdateProfileAsync(exist);

        }
    }
}
