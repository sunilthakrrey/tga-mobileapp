using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ParentPortal.Contracts.Requests
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Enter Valid email address")]
        [JsonProperty("username")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
