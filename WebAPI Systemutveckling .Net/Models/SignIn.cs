using System.ComponentModel.DataAnnotations;

namespace WebAPI_Systemutveckling_.Net.Models
{
    public class SignIn
    {
        [Required, RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z")]
        public string Email { get; set; }
        [Required, RegularExpression(@"((?=.*\d)(?=.*[A-Z]).{8,})")]
        public string Password { get; set; }
    }
}
