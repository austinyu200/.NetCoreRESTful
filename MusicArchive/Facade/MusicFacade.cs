using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualBasic.CompilerServices;
using MusicArchive.Entities;
using MusicArchive.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicArchive.Models;

namespace MusicArchive.Facade
{
    public class MusicFacade
    {
        private PieciesDbContext db;

        public MusicFacade(PieciesDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// 非同步取得作曲家列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Composer>> GetComposersAsync()
        {
            List<Composer> result = new List<Composer>();
            result = await db.Composer.ToListAsync();
            return result;
        }

        /// <summary>
        /// 由名稱搜尋作曲家
        /// </summary>
        /// <param name="composerName"></param>
        /// <returns></returns>
        public async Task<Composer> SearchComposersByNameAsync(string composerName)
        {
            Composer result = new Composer();
            result = await db.Composer.FirstOrDefaultAsync(x => x.ComposerName.Contains(composerName));
            return result;
        }

        /// <summary>
        /// 由作曲家搜尋曲目
        /// </summary>
        /// <param name="composerName"></param>
        /// <returns></returns>
        public async Task<List<Piece>> GetPieceByComposerAsync(string composerName)
        {
            List<Piece> result = null;
            Composer composer = (from i in db.Composer where i.ComposerName == composerName select i).FirstOrDefault();

            if (composer == null)
            {
                return null;
            }
            else
            {
                result = await (from i in db.Piece where i.ComposerId == composer.Id  select i).ToListAsync();
                foreach (var i in result)
                {
                    i.ComposerName = composer.ComposerName;
                }
            }
            return result;
        }

        /// <summary>
        /// 新增作曲家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal async Task<Composer> AddComposerAsync(AddComposerRequestModel model)
        {
            Composer composer = new Composer();
            composer.Id = Guid.NewGuid();
            composer.ComposerName = model.ComposerName;
            composer.Born = model.Born;
            composer.Passed = model.Passed;
            db.Composer.Add(composer);
            await db.SaveChangesAsync();
            return composer;
        }

        /// <summary>
        /// 更新作曲家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal async Task<bool> UpdateComposerAsync(UpdateComposerRequestModel model)
        {
            Composer composer = new Composer();
            var updateComposer = db.Composer.Where(i => i.ComposerName == model.Name).FirstOrDefault();
            if (updateComposer != null)
            {
                updateComposer.ComposerName = model.UpdateName;
                updateComposer.Born = model.Born;
                updateComposer.Passed = model.Passed;
                db.Composer.Update(updateComposer);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 刪除作曲家
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal async Task<bool> RemoveComposerAsync(string name)
        {
            var delComposer = db.Composer.Where(i => i.ComposerName == name).FirstOrDefault();
            if (delComposer != null)
            {
                db.Composer.Remove(delComposer);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 新增樂曲
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal async Task<Piece> AddPieceAsync(AddPieceRequestModel model)
        {
            Composer composer = db.Composer.Where(i => i.ComposerName == model.ComposerName).FirstOrDefault();
            if (composer == null)
            {
                AddComposerRequestModel addComposer = new AddComposerRequestModel();
                addComposer.ComposerName = model.ComposerName;
                composer = await AddComposerAsync(addComposer);
            }
            Piece piece = new Piece();
            piece.Id = Guid.NewGuid();
            piece.ComposerId = composer.Id;
            piece.CreateDate = model.CreateDate;
            piece.PieceName = model.PieceName;
            piece.Style = model.Style;
            piece.ComposerName = model.ComposerName;
            db.Piece.Add(piece);
            await db.SaveChangesAsync();
            return piece;
        }
    }
}
