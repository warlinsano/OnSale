using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageDirectoryAsync(IFormFile imageFile, string folder);

        byte[] UploadImageDB(IFormFile Image);
    }
}
