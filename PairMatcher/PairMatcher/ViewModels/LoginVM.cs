using System.ComponentModel.DataAnnotations;

namespace PairMatcher.ViewModels
{
    public class LoginVM
    {
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
