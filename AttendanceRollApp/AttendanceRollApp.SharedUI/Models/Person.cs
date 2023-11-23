using System.ComponentModel.DataAnnotations;

namespace AttendanceRollApp.SharedUI.Models
{
    public class Person : Entity
    {
        [Key]
        public required string NationalID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required EGender Gender { get; set; }

        public required List<string> NfcSerialNumbers { get; set; }


        public enum EGender
        {
            MALE = 0,
            FEMALE = 1,
            OTHER = 2,
            PREFER_NOT_TO_SAY = 3
        }


    }
}
