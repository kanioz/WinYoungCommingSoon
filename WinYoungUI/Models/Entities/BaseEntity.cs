using System;
using System.ComponentModel.DataAnnotations;

namespace WinYoungUI.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime ModifiedTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
