using System.ComponentModel.DataAnnotations;

namespace WinYoungUI.ViewModels
{
    public class NewsLetterVm
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
