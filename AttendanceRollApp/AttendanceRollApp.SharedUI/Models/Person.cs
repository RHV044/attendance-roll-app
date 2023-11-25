using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static AttendanceRollApp.SharedUI.Models.Person;

namespace AttendanceRollApp.SharedUI.Models
{
    public class Person : Entity
    {
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Email { get; set; }
        public List<string> NfcSerialNumbers { get; set; } = [];


        public enum EGender
        {
            MALE = 0,
            FEMALE = 1,
            OTHER = 2,
            PREFER_NOT_TO_SAY = 3
        }




    }
    public static class EGenderExtensions
    {
        public static string ToFriendlyString(this EGender gender)
        {
            switch (gender)
            {
                case EGender.MALE: return "Masculino";
                case EGender.FEMALE: return "Femenino";
                case EGender.OTHER: return "Otro";
                case EGender.PREFER_NOT_TO_SAY: return "Prefiere no decirlo";
            }

            return gender.ToString();
        }
    }
}
