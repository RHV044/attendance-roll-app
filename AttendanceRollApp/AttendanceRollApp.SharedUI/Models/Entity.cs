namespace AttendanceRollApp.SharedUI.Models
{
    public class Entity
    {
        public bool IsDeleted { get; set; } = false;
        public required DateTime CreatedDate { get; set; }
        public required DateTime LastUpdatedDate { get; set; }
    }
}