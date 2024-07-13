using DatingApp.DTO;
using DatingApp.Entities;

namespace DatingApp.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<MemberDTO>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<MemberDTO> GetUserByUsernameAsync(string username);

    }
}
