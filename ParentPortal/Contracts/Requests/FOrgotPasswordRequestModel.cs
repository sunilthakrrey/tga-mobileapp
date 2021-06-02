using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParentPortal.Contracts.Requests
{
    public class FOrgotPasswordRequestModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Enter Valid email address")]
        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
