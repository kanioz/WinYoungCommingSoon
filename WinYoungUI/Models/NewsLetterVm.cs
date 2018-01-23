using System.ComponentModel.DataAnnotations;

namespace WinYoungUI.Models
{
    public class NewsLetterVm
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
