using System;
using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
