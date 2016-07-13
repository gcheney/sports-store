using System.ComponentModel.DataAnnotations;

namespace SportsStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Please enter a username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
    }
}