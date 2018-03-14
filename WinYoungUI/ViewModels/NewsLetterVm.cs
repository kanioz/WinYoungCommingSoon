using System.ComponentModel.DataAnnotations;

namespace WinYoungUI.ViewModels
{
    public class NewsLetterVm
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
