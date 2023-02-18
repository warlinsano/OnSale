﻿using Microsoft.AspNetCore.Identity;
using OnSale.Common.Entities;
using OnSale.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnSale.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Login Type")]
        public LoginType LoginType { get; set; }

        public string ImageFacebook { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath
        {
            get
            {
                if (LoginType == LoginType.Facebook && string.IsNullOrEmpty(ImageFacebook) ||
                    LoginType == LoginType.OnSale && ImageId == Guid.Empty)
                {
                    return $"https://localhost:44315/images/noimage.png";
                }

                if (LoginType == LoginType.Facebook)
                {
                    return ImageFacebook;
                }

                return $"https://localhost:44315/images/users/{ImageId}.jpg";
            }
        }

        [Display(Name = "User Type")]
        public UserType UserType { get; set; }

        public City City { get; set; }

        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "User")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        [DisplayFormat(DataFormatString = "{0:N4}")]
        public double Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:N4}")]
        public double Logitude { get; set; }
    }
}
