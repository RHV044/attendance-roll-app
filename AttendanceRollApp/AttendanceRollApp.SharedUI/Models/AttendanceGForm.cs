using static Microsoft.FluentUI.AspNetCore.Components.Emojis.TravelPlaces.Color.Default;

namespace AttendanceRollApp.SharedUI.Models
{
    public static class AttendanceGForm
    {
        public static string FormUrl { get; set; }
            = "https://docs.google.com/forms/d/e/1FAIpQLSfPbLOitjJZuNOz_A4dPyIffgaBabjQse-03PLP7yieD4UOkQ/formResponse";
        public static class Fields
        {
            public static string Year { get; set; } = "entry.1715627258_year";
            public static string Month { get; set; } = "entry.1715627258_month";
            public static string Day { get; set; } = "entry.1715627258_day";
            public static string Hour { get; set; } = "entry.1715627258_hour";
            public static string Minute { get; set; } = "entry.1715627258_minute";
            public static string NationalID { get; set; } = "entry.781912077";
            public static string FullName { get; set; } = "entry.1847308940";
            public static string Gender { get; set; } = "entry.1654532975";
            public static string BirthYear { get; set; } = "entry.980467212_year";
            public static string BirthMonth { get; set; } = "entry.980467212_month";
            public static string BirthDay { get; set; } = "entry.980467212_day";
            public static string AuthMethod { get; set; } = "entry.906053407";
            public static string Location { get; set; } = "entry.513961274";

        }
    }
}
