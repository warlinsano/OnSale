using System;
using System.ComponentModel.DataAnnotations;

namespace OnSale.Common.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"http://192.168.4.16:5000/images/noimage.png"
            : $"http://192.168.4.16:5000/images/products/{ImageId}.jpg"; 
    }
}
