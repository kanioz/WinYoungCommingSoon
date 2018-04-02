using System.ComponentModel.DataAnnotations;

namespace WinYoungUI.Models.Entities
{
    public class Content : BaseContentEntity
    {
        public bool IsSlider { get; set; }
        public virtual ContentCategory Category { get; set; }
    }
}
