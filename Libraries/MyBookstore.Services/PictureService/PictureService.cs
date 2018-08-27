using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Core;
using MyBookstore.Data;
using MyBookstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookstore.Services
{
    public class PictureService : IPictureService
    {

        private readonly ApplicationDbContext _dbContext;

        public PictureService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private const string pictureFolder = @"C:\Code\Repos\Presentation\MyBookstore.Web\wwwroot\Images\Uploads";

        public async Task AddPicture(int bookId, IFormFile uploadedPicture, bool isMain)
        {
            var picture = new Picture();
            picture.BookId = bookId;
            picture.Main = isMain;
            picture.Name = uploadedPicture.FileName;
            _dbContext.Pictures.Add(picture);
            await _dbContext.SaveChangesAsync();

            var filePath = Path.Combine(pictureFolder, 
                string.Format("{0}_{1}", picture.Id.ToString(), uploadedPicture.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploadedPicture.CopyToAsync(stream);
            }
        }

        public async Task DeletePicture(int pictureId)
        {
            var picture = await _dbContext.Pictures.Where(t => t.Id==pictureId).FirstOrDefaultAsync();

            if (picture != null)
            {
                var filePath = Path.Combine(pictureFolder,
                    string.Format("{0}_{1}", picture.Id.ToString(), picture.Name));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

               _dbContext.Pictures.Remove(picture);
                await _dbContext.SaveChangesAsync();
            }

        }


        public async Task DeleteMainPicture(int bookId)
        {
            var picture = await _dbContext.Pictures
                .Where(t => t.BookId == bookId && t.Main)
                .FirstOrDefaultAsync();
            if (picture != null)
            {
                await DeletePicture(picture.Id);
            }
        
           
        }

    }
}
