using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public class BlobHelper : IBlobHelper
    {
        private readonly CloudBlobClient _blobClient;

        public BlobHelper(IConfiguration configuration)
        {
            string keys = configuration["Blob:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(keys);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<Guid> UploadBlobAsync(byte[] file, string containerName)
        {
            MemoryStream stream = new MemoryStream(file);
            return await UploadStreamAsync(stream, containerName);
        }

        public async Task<Guid> UploadBlobAsync(IFormFile file, string containerName)
        {
            Stream stream = file.OpenReadStream();
            return await UploadStreamAsync(stream, containerName);
        }

        public async Task<Guid> UploadBlobAsync(string image, string containerName)
        {
            Stream stream = File.OpenRead(image);
            return await UploadStreamAsync(stream, containerName);
        }

        public async Task<Guid> UploadBlobAsync(Stream stream, string containerName)
        {
            return await UploadStreamAsync(stream, containerName);
        }

        private async Task<Guid> UploadStreamAsync(Stream stream, string containerName)
        {
           //Guid name = Guid.NewGuid();
           //CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
           //CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{name}");
           // await blockBlob.UploadFromStreamAsync(stream);
           //return name;

            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.jpg";
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" + containerName, file);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + containerName, file);

            using (var streamSave = new FileStream(path, FileMode.Create))
            {
                await stream.CopyToAsync(streamSave);
            }
            return Guid.Parse(guid);
        }
    }
}
