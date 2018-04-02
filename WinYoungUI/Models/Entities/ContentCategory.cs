using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WinYoungUI.Models.Entities
{
    public class ContentCategory : BaseContentEntity
    {
        public ContentCategory()
        {
            Categories = new Collection<ContentCategory>();
            Contents = new Collection<Content>();
        }
        public virtual ContentCategory RootCategory { get; set; }
        public virtual ICollection<ContentCategory> Categories { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
