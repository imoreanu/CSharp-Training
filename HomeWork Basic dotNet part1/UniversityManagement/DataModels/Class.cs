using UniversityManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.DataModels
{
    public class Class
    {
        public int ClassId { get; set; }
        [MaxLength(50)]
        public string ClassName { get; set; }
        [Required]
        public int MaxClassSize { get; set; }
        public Language ClassLanguage { get; set; }
    }
}