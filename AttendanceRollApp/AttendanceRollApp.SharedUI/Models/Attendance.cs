using System.ComponentModel.DataAnnotations;
using AttendanceRollApp.SharedUI.Models.Interfaces;

namespace AttendanceRollApp.SharedUI.Models
{
    public class Attendance : ISynchronizableToServer
    {
        [Key]
        public int dbId { get; set; }
        public required DateTime DateTime { get; set; }
        public required Person Person { get; set; }
        public required AuthenticationMethod AuthMethod { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? LastTimeSynced { get; set; }
        public bool IsSynced { get; set; }

        public class AuthenticationMethod
        {
            [Key]
            public int dbId { get; set; }
            public required EType Type { get; set; }
            public required string Value { get; set; }

            public enum EType
            {
                NFC = 0,
                QR = 1
            }
        }
    }
}
