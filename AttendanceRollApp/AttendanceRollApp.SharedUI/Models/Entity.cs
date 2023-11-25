using System.ComponentModel.DataAnnotations;

namespace AttendanceRollApp.SharedUI.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            LastUpdatedDate = CreatedDate = DateTime.Now;
        }
        [Key]
        public int? Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}