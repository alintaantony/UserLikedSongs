using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLikedSongs.Models;

namespace UserLikedSongs.Repository
{
    public class UserLikedSongsRepo : IUserLikedSongsRepo
    {
        private readonly SpotifyDemoDbContext _context;

        public UserLikedSongsRepo(SpotifyDemoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LikedSongs> GetAllUserLikedSongs()
        {
            return _context.LikedSongs.ToList();
        }

        public LikedSongs GetUserLikedSongById(int id)
        {
            LikedSongs likedSong = _context.LikedSongs.Find(id);
            return likedSong;
        }

        public async Task<LikedSongs> PostLikedSong(LikedSongs item)
        {
            LikedSongs likedSong = null;
            if(item == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                likedSong = new LikedSongs() { Userid = item.Userid, Songid = item.Songid, Addeddate = item.Addeddate, Userlikedsongplaycounter = 0 };
                await _context.LikedSongs.AddAsync(likedSong);
                await _context.SaveChangesAsync();
            }
            return likedSong;
        }

       public async Task<LikedSongs> DeleteLikedSong(int id)
        {
            LikedSongs likedSong = await _context.LikedSongs.FindAsync(id);
            if(likedSong == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.LikedSongs.Remove(likedSong);
                await _context.SaveChangesAsync();
            }
            return likedSong;
        }
    }
}
