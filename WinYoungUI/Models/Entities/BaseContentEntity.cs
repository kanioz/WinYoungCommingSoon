using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WinYoungUI.Models.Entities
{
    public class BaseContentEntity : BaseEntity
    {
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Text { get; set; }
        [MaxLength(500)]
        public string MetaTags { get; set; }
        public int OrderValue { get; set; }
        public int ViewCount { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
