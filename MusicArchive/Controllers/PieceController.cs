using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using MusicArchive.Models;
using MusicArchive.Entities;

namespace MusicArchive.Controllers
{
    [ApiController]
    [Route("piece")]
    public class PieceController : BaseController
    {
        [HttpGet]
        [Route("GetComposer")]
        public async Task<Composer> GetComposer()
        {
            string[] composers = new string[] { "Vivaldi", "Mozart", "Brahms" };
            Composer vivaldi = new Composer();
            vivaldi.Id = Guid.NewGuid();
            vivaldi.Name = "Vivaldi";
            vivaldi.Born = DateTime.Parse("1678/03/04");
            vivaldi.Passed = DateTime.Parse("1741/07/28");
            //string result = JsonSerializer.Serialize(vivaldi);
            return vivaldi;
        }

        [HttpGet]
        [Route(nameof(GetPiecesByComposer))]
        public async Task<ApiResult<object>> GetPiecesByComposer()
        {
            ApiResult<object> apiResult = new ApiResult<object>();

            return apiResult;
        }
    }
}
