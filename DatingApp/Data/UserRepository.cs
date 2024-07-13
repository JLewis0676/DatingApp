using DatingApp.DTO;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DatingApp.Data
{
    public class UserRepository : IUserRepository
    {
        public DataContext _context { get; }

        public UserRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<AppUser> GetUserByIdAsync(int id)
        {
             return await _context.Users.FindAsync(id) ;
        }

        public async Task<MemberDTO> GetUserByUsernameAsync(string username) { 
            //return await _context.Users
            //    .Include(p=>p.Photos)
            //    .SingleOrDefaultAsync(x=> x.UserName == username);

            //    return new { Results = await _context.Users
            //            .Select(x => new MemberDTO
            //            {
            //                UserName = x.UserName,
            //                Id = x.Id,
            //                age = x.GetAge(),
            //                KnowAs = x.KnowAs,
            //                Photos = x.Photos.Select(c => new PhotoDTO { Id = c.Id, Url = c.Url, IsMain = c.isMain }).ToList()
            //            }) ;
            //}

          return await (from x in _context.Users
                   where x.UserName == username
                   select new MemberDTO
                   {
                       UserName = x.UserName,
                       Id = x.Id,
                       age = x.GetAge(),
                       KnowAs = x.KnowAs,
                       Created = x.Created,
                       Introduction = x.Introduction,
                       LookingFor =  x.LookingFor,
                       Interests = x.Interests,
                       City = x.City,
                       Country = x.Country,
                       Gender = x.Gender,
                       Photos = (from c in x.Photos
                                            select new PhotoDTO
                                            {
                                                Id = c.Id,
                                                Url = c.Url,
                                                IsMain = c.isMain
                                            }
                                 ).ToList(),
                    PhotoUrl =  x.Photos.FirstOrDefault().Url

                       //x.Photos.Select(c => new PhotoDTO { Id = c.Id, Url = c.Url, IsMain = c.isMain })
                   }).SingleOrDefaultAsync();
            

        }

        public async Task<IEnumerable<MemberDTO>> GetUsersAsync()
        {
            //return await _context.Users
            //    .Include(p=>p.Photos)

            //    .ToListAsync();
            return await (from x in _context.Users
                                select new MemberDTO
                                {
                                    UserName = x.UserName,
                                    Id = x.Id,
                                    age = x.GetAge(),
                                    KnowAs = x.KnowAs,
                                    Created = x.Created,
                                    Introduction = x.Introduction,
                                    LookingFor = x.LookingFor,
                                    Interests = x.Interests,
                                    City = x.City,
                                    Country = x.Country,
                                    Photos = (from c in x.Photos
                                              select new PhotoDTO
                                              {
                                                  Id = c.Id,
                                                  Url = c.Url,
                                                  IsMain = c.isMain
                                              }
                                              ).ToList(),

                                PhotoUrl = x.Photos.FirstOrDefault().Url
                                    //x.Photos.Select(c => new PhotoDTO { Id = c.Id, Url = c.Url, IsMain = c.isMain })
                                }).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
