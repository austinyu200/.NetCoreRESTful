using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using MusicArchive.Models;
using MusicArchive.Entities;
using MusicArchive.DbContext;
using MusicArchive.Facade;
using MusicArchive.Enumeration;

namespace MusicArchive.Controllers
{
    [ApiController]
    [Route("piece")]
    public class PieceController : ControllerBase
    {
        
        private readonly PieciesDbContext pieciesDb;
        private MusicFacade musicFacade = null;

        public PieceController(PieciesDbContext pieciesDb)
        {
            this.pieciesDb = pieciesDb;
            musicFacade = new MusicFacade(this.pieciesDb);
        }


        /// <summary>
        /// List all composers
        /// </summary>
        /// <returns>Return a List that contains Composer elements</returns>
        [HttpGet]
        [Route(nameof(GetComposers))]
        public async Task<ApiResult<List<Composer>>> GetComposers()
        {
            ApiResult<List<Composer>> result = new ApiResult<List<Composer>>();
            List<Composer> composer = null;
            try
            {
                composer = await musicFacade.GetComposersAsync();
            }
            catch (Exception e)
            {
                return result;
            }

            if (composer != null)
            {
                result.Code = ApiResultCode.Success;
                result.Data = composer;
            }
            else
            {
                result.Code = ApiResultCode.Error;
                result.Data = null;
            }            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(GetComposerByName))]
        public async Task<ApiResult<Composer>> GetComposerByName(GetComposerByNameRequestModel model)
        {
            ApiResult<Composer> result = new ApiResult<Composer>();
            Composer composer = null;

            try
            {
                composer = await musicFacade.SearchComposersByNameAsync(model.Name);
            }
            catch (Exception e)
            {
                result.Code = ApiResultCode.Error;
                return result;
            }
            result.Code = composer == null ? ApiResultCode.DataNotFound: ApiResultCode.Success;
            result.Data = composer;

            return result;
        }

        [HttpPost]
        [Route(nameof(GetPiecesByComposer))]
        public async Task<ApiResult<List<Piece>>> GetPiecesByComposer([FromBody] GetPiecesByComposerRequestModel model)
        {
            ApiResult<List<Piece>> result = new ApiResult<List<Piece>>();
            List<Piece> pieces = null;

            try
            {
                pieces = await musicFacade.GetPieceByComposerAsync(model.Composer);
            }
            catch (Exception e)
            {
                result.Code = ApiResultCode.Error;
                return result;
            }

            result.Code = pieces == null ? ApiResultCode.DataNotFound : ApiResultCode.Success;
            result.Data = pieces;

            
            return result;
        }

        [HttpPost]
        [Route(nameof(AddComposer))]
        public async Task<ApiResult<object>> AddComposer(UpdateComposerRequestModel model)
        {
            ApiResult<object> result = new ApiResult<object>();
            try
            {
                await musicFacade.UpdateComposerAsync(model);
            }
            catch (Exception e)
            {
                result.Code = ApiResultCode.Error;
                return result;
            }
            result.Code = ApiResultCode.Success;

            return result;
        }


        [HttpPatch]
        [Route(nameof(UpdateComposer))]
        public async Task<ApiResult<bool>> UpdateComposer(UpdateComposerRequestModel model)
        {
            ApiResult<bool> result = new ApiResult<bool>();
            try
            {
                result.Data = await musicFacade.UpdateComposerAsync(model);
                result.Code = result.Data ? ApiResultCode.Success : ApiResultCode.DBUpdateFail;
            }
            catch (Exception e)
            {
                result.Code = ApiResultCode.Error;
                return result;
            }
            return result;
        }

        [HttpDelete]
        [Route(nameof(RemoveComposer))]
        public async Task<ApiResult<bool>> RemoveComposer(RemoveComposerRequestModel model)
        {
            ApiResult<bool> result = new ApiResult<bool>();
            result.Data = await musicFacade.RemoveComposerAsync(model.ComposerName);
            result.Code = result.Data  ? ApiResultCode.Success : ApiResultCode.DBUpdateFail;
            return result;
        }

        [HttpPost]
        [Route(nameof(AddPiece))]
        public async Task<ApiResult<AddPieceResponseModel>> AddPiece(AddPieceRequestModel model)
        {
            ApiResult<AddPieceResponseModel> result = new ApiResult<AddPieceResponseModel>();
            AddPieceResponseModel responseModel = new AddPieceResponseModel();
            responseModel.IsAddSuccess = false;
            try
            {
                responseModel.Piece = await musicFacade.AddPieceAsync(model);
                responseModel.IsAddSuccess = true;
            }
            catch (Exception e)
            { }
            result.Data = responseModel;
            result.Code = result.Data.IsAddSuccess ? ApiResultCode.Success : ApiResultCode.DBUpdateFail;
            return result;
        }
    }
}
