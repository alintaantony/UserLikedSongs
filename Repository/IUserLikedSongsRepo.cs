using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLikedSongs.Models;

namespace UserLikedSongs.Repository
{
    public interface IUserLikedSongsRepo
    {
        IEnumerable<LikedSongs> GetAllUserLikedSongs();
        LikedSongs GetUserLikedSongById(int id);
        Task<LikedSongs> PostLikedSong(LikedSongs item);
        Task<LikedSongs> DeleteLikedSong(int id);

    }
}
