using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public int Status { get; set; }

        public string StatusDescricao => ((TaskManager.Domain.Enums.Status)Status).GetAttribute<DisplayAttribute>()?.Name ?? Status.ToString();
    }
}
