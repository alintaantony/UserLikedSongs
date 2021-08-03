using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLikedSongs.Models;
using UserLikedSongs.Repository;

namespace UserLikedSongs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLikedSongsController : ControllerBase
    {
        private readonly IUserLikedSongsRepo _userLikedSongsRepo;

        public UserLikedSongsController(IUserLikedSongsRepo userLikedSongsRepo)
        {
            _userLikedSongsRepo = userLikedSongsRepo;
        }

        [HttpGet]
        public IEnumerable<LikedSongs> GetAllLikedSongs()
        {
            return _userLikedSongsRepo.GetAllUserLikedSongs();
        }

        [HttpGet("{id}")]
        public IActionResult GetLikedSongById(int id)
        {
            try
            {
                var likedSong = _userLikedSongsRepo.GetUserLikedSongById(id);
                if(likedSong == null)
                {
                    return NotFound();
                }
                return Ok(likedSong);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikedSong(int id)
        {
            try
            {
                var deleteLikedSong = await _userLikedSongsRepo.DeleteLikedSong(id);
                return Ok(deleteLikedSong);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
