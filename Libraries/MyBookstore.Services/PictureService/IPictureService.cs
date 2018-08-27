using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookstore.Core;
using MyBookstore.Models;

namespace MyBookstore.Services
{
    public interface IPictureService
    {
        Task AddPicture(int bookId, IFormFile uploadedPicture, bool isMain);
        Task DeletePicture(int pictureId);
        Task DeleteMainPicture(int bookId);
    }
}
