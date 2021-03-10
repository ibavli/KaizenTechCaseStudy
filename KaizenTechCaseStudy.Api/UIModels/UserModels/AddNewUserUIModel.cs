﻿using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.UserModels
{
    public class AddNewUserUIModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
